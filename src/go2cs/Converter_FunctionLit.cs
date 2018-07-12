﻿//******************************************************************************************************
//  Converter_FunctionLit.cs - Gbtc
//
//  Copyright © 2018, Grid Protection Alliance.  All Rights Reserved.
//
//  Licensed to the Grid Protection Alliance (GPA) under one or more contributor license agreements. See
//  the NOTICE file distributed with this work for additional information regarding copyright ownership.
//  The GPA licenses this file to you under the MIT License (MIT), the "License"; you may not use this
//  file except in compliance with the License. You may obtain a copy of the License at:
//
//      http://opensource.org/licenses/MIT
//
//  Unless agreed to in writing, the subject software distributed under the License is distributed on an
//  "AS-IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. Refer to the
//  License for the specific language governing permissions and limitations.
//
//  Code Modification History:
//  ----------------------------------------------------------------------------------------------------
//  07/12/2018 - J. Ritchie Carroll
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using go2cs.Metadata;

namespace go2cs
{
    public partial class Converter
    {
        public const string FunctionLiteralParametersMarker = ">>MARKER:FUNCTIONLIT_PARAMETERS<<";

        public override void EnterFunctionLit(GolangParser.FunctionLitContext context)
        {
            PushBlock();
            m_targetFile.AppendLine($"{FunctionLiteralParametersMarker} =>");
        }

        public override void ExitFunctionLit(GolangParser.FunctionLitContext context)
        {
            // functionLit
            //     : 'func' function

            string parametersSignature = "()";

            if (Signatures.TryGetValue(context.function()?.signature(), out Signature signature))
            {
                parametersSignature = signature.GenerateParameterNameList();

                if (signature.Parameters.Length != 1)
                    parametersSignature = $"({parametersSignature})";
            }
            else
            {
                AddWarning(context, $"Failed to find signature for function literal inside \"{m_currentFunctionName}\" function");
            }

            // Replace marker for function literal
            m_targetFile.Replace(FunctionLiteralParametersMarker, parametersSignature);

            // operand
            //     : literal
            //     | operandName
            //     | methodExpr
            //     | '(' expression ')'

            // literal
            //     : basicLit
            //     | compositeLit
            //     | functionLit

            if (!(context.Parent.Parent is GolangParser.OperandContext operandContext))
            {
                AddWarning(context, $"Could not derive parent operand context from function literal inside \"{m_currentFunctionName}\" function: \"{context.GetText()}\"");
                PopBlock();
                return;
            }

            string lambdaExpression = PopBlock(false);

            // Simplify lambda expressions that consist of a single return statement
            if (m_firstStatementIsReturn)
            {
                int index = lambdaExpression.IndexOf("=>", StringComparison.Ordinal);

                if (index > -1)
                {
                    string startBlock = $"{{{Environment.NewLine}";
                    
                    index = lambdaExpression.IndexOf(startBlock, index, StringComparison.Ordinal);

                    if (index > -1)
                    {
                        string parameters = lambdaExpression.Substring(0, index).Trim();

                        lambdaExpression = lambdaExpression.Substring(index + startBlock.Length).Trim();

                        if (lambdaExpression.StartsWith("return ", StringComparison.Ordinal))
                            lambdaExpression = lambdaExpression.Substring(7).Trim();

                        if (lambdaExpression.EndsWith("}", StringComparison.Ordinal))
                            lambdaExpression = lambdaExpression.Substring(0, lambdaExpression.Length - 1).Trim();

                        if (lambdaExpression.EndsWith(";", StringComparison.Ordinal))
                            lambdaExpression = lambdaExpression.Substring(0, lambdaExpression.Length - 1).Trim();

                        lambdaExpression = $"{parameters} {lambdaExpression.Trim()}";
                    }
                }
            }
                
            // Update expression operand (managed in ScannerBase_Expression.cs)
            Operands[operandContext] = lambdaExpression;
        }
    }
}