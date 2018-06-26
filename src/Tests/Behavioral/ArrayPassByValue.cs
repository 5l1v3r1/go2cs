// package main -- go2cs converted at 2018 June 26 10:56:12 UTC
// Original source: C:\Projects\go2cs\src\Tests\Behavioral\ArrayPassByValue.go

using fmt = go.fmt_package;
using static go.BuiltInFunctions;

namespace go
{
    public static partial class main_package
    {
        private static void Main()
        {
            vara[2]stringa[0]="Hello"a[1]="World"test(a)fmt.Println(a[0],a[1])fmt.Println()a[0]="Hello"test2(&a)fmt.Println(a[0],a[1])fmt.Println()a[0]="Hello"test3(a[:])fmt.Println(a[0],a[1])fmt.Println()primes:=[6]int{2,3,5,7,11,13}fmt.Println(primes)
        }

        // Arrays are passed by value (a full copy)
        private static void test(string[2][2] a)
        {
            fmt.Println(a[0],a[1])a[0]="Goodbye"fmt.Println(a[0],a[1])
        }

        private static void test2(ref string[2][2] a)
        {
            fmt.Println(a[0],a[1])a[0]="Goodbye"fmt.Println(a[0],a[1])
        }

        private static void test3(Slice<string> a)
        {
            fmt.Println(a[0],a[1])a[0]="Goodbye"fmt.Println(a[0],a[1])
        }
    }
}
