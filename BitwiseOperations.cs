using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCalc
{
    public static class BitwiseOperations
    {
        public static int And(int a, int b) => a & b;
        public static int Or(int a, int b) => a | b;
        public static int Xor(int a, int b) => a ^ b;
        public static int Not(int a) => ~a;
    }

}
