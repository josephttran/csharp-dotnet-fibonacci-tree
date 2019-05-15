using System;
using System.Collections.Generic;

using FibonacciLibrary;
using TreeLibrary;

namespace FibonacciTree
{
    class Program
    {
        static int Menu()
        {
            Console.WriteLine("\n################################");
            Console.WriteLine("#  Fibonacci Tree Application  #");
            Console.WriteLine("################################\n");

            Console.WriteLine("Enter a negative number to quit.");
            Console.Write("Enter a positive number: ");

            string input = Console.ReadLine();

            int number;

            while (!int.TryParse(input, out number))
            {
                Console.Write("Please enter a positive number: ");
                input = Console.ReadLine();
            }

            return number;
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
            Console.WriteLine();
        }

        static void PrintFibonacciList(List<int> fibonacciList, int number)
        {
            string s = String.Join(", ", fibonacciList.ToArray());
            Console.WriteLine("______________________________________");
            Console.WriteLine($"\nFibonacci Sequence of {number} is: ");
            Console.WriteLine(s);
        }
        static void VisitItem(int item) 
        {
            Console.Write(item);
            Console.Write(", ");
        }
        static void Main(string[] args)
        {
            while (true)
            {
                int number = Menu();
                
                if (number < 0)
                {
                    Console.WriteLine("Program exit.");
                    break;
                }

                List<int> fibonacciList = Fibonacci.FibSequence(number);
                FibTree fibTree = new FibTree(number);

                PrintFibonacciList(fibonacciList, number);
                PrintFibonacciDetails(fibTree);
            }
        }
    }
}
