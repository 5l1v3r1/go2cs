//---------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. Changes to this
//     file may cause incorrect behavior and will be lost
//     if the code is regenerated.
//
//     Generated on 2018 July 12 19:15:05 UTC
// </auto-generated>
//---------------------------------------------------------
using System;
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using static go.BuiltInFunctions;
using fmt = go.fmt_package;

namespace go
{
    public static partial class main_package
    {
        [GeneratedCode("go2cs", "0.1.1.0")]
        public partial struct ColorList
        {
            // Constructors
            public ColorList(NilType _)
            {
                this.Total = default;
                this.Color = default;
                this.Next = default;
                this.NextNext = default;
            }

            public ColorList(long Total, GoString Color, ref Ptr<ColorList> Next, ref Ptr<Ptr<ColorList>> NextNext)
            {
                this.Total = Total;
                this.Color = Color;
                this.Next = Next;
                this.NextNext = NextNext;
            }

            // Enable comparisons between nil and ColorList struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(ColorList value, NilType nil) => value.Equals(default(ColorList));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(ColorList value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, ColorList value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, ColorList value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator ColorList(NilType nil) => default(ColorList);
        }
    }
}