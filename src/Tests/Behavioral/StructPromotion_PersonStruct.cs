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
        public partial struct Person
        {
            // Constructors
            public Person(NilType _)
            {
                this.name = default;
                this.age = default;
            }

            public Person(GoString name, int age)
            {
                this.name = name;
                this.age = age;
            }

            // Enable comparisons between nil and Person struct
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(Person value, NilType nil) => value.Equals(default(Person));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(Person value, NilType nil) => !(value == nil);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(NilType nil, Person value) => value == nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(NilType nil, Person value) => value != nil;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Person(NilType nil) => default(Person);
        }
    }
}