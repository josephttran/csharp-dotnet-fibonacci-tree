using System;
using System.Collections.Generic;

using FibonacciLibrary;
using TreeLibrary;

namespace FibonacciTree
{
    class Program
    {
        static void VisitItem(int item) 
        {
            Console.Write(item);
            Console.Write(", ");
        }

        static void PrintFibonacciDetails(FibTree fibTree)
        {
            fibTree.PrintTreeLeftToRight();

            Console.WriteLine($"\nFibonacci tree height is {fibTree.GetHeight()}");

            Node r = fibTree.GetRoot();
            Console.WriteLine($"Root contain the number {r.GetItem()}");

            if (r.GetLeftChild() != null)
            {
                Console.WriteLine($"Root left child contain the number {r.GetLeftChild().GetItem()}");
            }
            if (r.GetRightChild() != null)
            {
                Console.WriteLine($"Root right child contain the number {r.GetRightChild().GetItem()}");
            }

            fibTree.LevelOrderTraverse();

            fibTree.InOrderTraverse(VisitItem);
        }

        static void PrintFibonacciList(List<int> fibonacciList, int number)
        {
            string s = String.Join(", ", fibonacciList.ToArray());
            Console.WriteLine($"Fibonacci Sequence of {number} is: ");
            Console.WriteLine(s);
        }
        static void Main(string[] args)
        {
            int number = 6;

            List<int> fibonacciList = Fibonacci.FibSequence(number);
            FibTree fibTree = new FibTree(number);

            PrintFibonacciList(fibonacciList, number);
            PrintFibonacciDetails(fibTree);

            Console.WriteLine("\n\nHello World!");
        }
    }
}
