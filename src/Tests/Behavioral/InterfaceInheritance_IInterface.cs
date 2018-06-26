//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2018 June 26 10:56:13 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace go
{
    public static partial class main_package
    {
        [GeneratedCode("go2cs", "0.1.1.0")]        
        public partial interface I
        {
        }

        [GeneratedCode("go2cs", "0.1.1.0")]
        [PromotedInterface(typeof(I))]
        public struct I<T> : I
        {
            private T m_target;

            private delegate void MByVal(T value);
            private delegate void MByRef(ref T value);

            private static readonly MByVal s_MByVal;
            private static readonly MByRef s_MByRef;

            [DebuggerNonUserCode, MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void M() => s_MByRef?.Invoke(ref m_target) ?? s_MByVal(m_target);

            [DebuggerStepperBoundary]
            static I()
            {
                Type targetType = typeof(T);
                MethodInfo extensionMethod;

                extensionMethod = targetType.GetExtensionMethod("M");

                if ((object)extensionMethod != null)
                {
                    s_MByRef = extensionMethod.CreateStaticDelegate(typeof(MByRef)) as MByRef;

                    if ((object)s_MByRef == null)
                        s_MByVal = extensionMethod.CreateStaticDelegate(typeof(MByVal)) as MByVal;
                }

                // This run-time exception is a compile time error in Go, so it's not an expected exception if Go code compiles
                if ((object)s_MByRef == null && (object)s_MByVal == null)
                    throw new NotImplementedException($"{targetType.Name} does not implement I.M function");
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
            public static explicit operator I<T>(T target) => new I<T> { m_target = target };

            // Enable comparisons between nil and I<T> interface instance
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(I<T> value, NilType nil) => (object)value == null || Activator.CreateInstance<I<T>>().Equals(value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(I<T> value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, I<T> value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, I<T> value) => value != nil;
        }

        [GeneratedCode("go2cs", "0.1.1.0"), MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerNonUserCode]
        public static I I_cast<T>(T target)
        {
            if (typeof(I).IsAssignableFrom(typeof(T)))
                return target as I;

            return (I<T>)target;
        }
    }
}

namespace go
{
    public partial class NilType
    {
        // Enable comparisons between nil and I interface
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(go.main_package.I value, NilType nil) => (object)value == null || Activator.CreateInstance(value.GetType()).Equals(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(go.main_package.I value, NilType nil) => !(value == nil);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(NilType nil, go.main_package.I value) => value == nil;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(NilType nil, go.main_package.I value) => value != nil;
    }
}