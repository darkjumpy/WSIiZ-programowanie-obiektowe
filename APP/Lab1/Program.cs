using System;
using Lab1.Constructions;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var constr = new Construction(32, 23, 3, 6, "brik");
            constr.BuildMaterial = "eee";
            Console.WriteLine(constr.BuildMaterial);
        }
    }
}