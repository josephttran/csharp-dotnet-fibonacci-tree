using System;

using FibonacciLibrary;

namespace TreeLibrary
{
    public class Node
    {
        int item;
        Node leftChild, rightChild;
        public Node(int data)
        {
            item = data;
        }
        public int GetItem()
        {
            return item;
        }
        public Node GetLeftChild()
        {
            return leftChild;
        }
        public Node GetRightChild()
        {
            return rightChild;
        }
        public void SetItem(int n)
        {
            item = n;
        }
        public void SetLeftChild(Node left)
        {
            leftChild = left;
        }
        public void SetRightChild(Node right)
        {
            rightChild = right;
        }
    }

    public class BinaryTree
    {
        protected Node root;

        protected int GetHeightHelper(Node binaryNode)
        {
            if (binaryNode == null)
            {
                return 0;
            }
            else
            {
                return 1 + Math.Max(
                    GetHeightHelper(binaryNode.GetLeftChild()), 
                    GetHeightHelper(binaryNode.GetRightChild())
                );
            }
        }
        protected Node InsertInOrder(Node tree, Node newNode)
        {
            if (tree == null)
            {
                return newNode;
            }
            else
            {
                Node left = tree.GetLeftChild();
                Node right = tree.GetRightChild();

                if (tree.GetItem() > newNode.GetItem())
                {
                    tree.SetLeftChild(InsertInOrder(left, newNode));
                }
                else
                {
                    tree.SetRightChild(InsertInOrder(right, newNode));
                }
            }

            return tree;
        }
        protected void InOrder(Action<int> display, Node binaryNode)
        {
            if (binaryNode != null)
            {
                InOrder(display, binaryNode.GetLeftChild());
                int item = binaryNode.GetItem();
                display(item);
                InOrder(display, binaryNode.GetRightChild());
            }
        }
        protected void LevelOrder(Node binaryNode, int level, int newLine)
        {
            if (binaryNode == null)
            {
                return;
            }

            if (level == 1)
            {
                Console.Write(binaryNode.GetItem());
                Console.Write("  ");
            }
            else if (level > 1)
            {
                LevelOrder(binaryNode.GetLeftChild(), level - 1, newLine);
                LevelOrder(binaryNode.GetRightChild(), level - 1, newLine);
            }
        }

        protected void ReverseInOrder(Node binaryNode, int space, int indent)
        {
            if (binaryNode != null)
            {
                space += indent;

                ReverseInOrder(binaryNode.GetRightChild(), space, indent);

                for (int i = indent; i < space; i++)
                {
                    Console.Write(" ");
                }

                int item = binaryNode.GetItem();
                Console.WriteLine(item);

                ReverseInOrder(binaryNode.GetLeftChild(), space, indent);
            }
        }
        public int GetHeight()
        {
            return GetHeightHelper(root);
        }
        public Node GetRoot()
        {
            return root;
        }
        public bool InsertItem(int item)
        {
            Node newNode = new Node(item);
            root = InsertInOrder(root, newNode);
            return true;
        }
        public void InOrderTraverse(Action<int> display)
        {
            Console.WriteLine("\n------------------");
            Console.WriteLine("In order traversal");
            Console.WriteLine("------------------");
            InOrder(display, root);
        }

        public void LevelOrderTraverse()
        {
            int height = GetHeight();
            Console.WriteLine("\n----------------------");
            Console.WriteLine("Level order traversal");
            Console.WriteLine("----------------------");
            for (int i = 1; i <= height; i++)
            {
                Console.Write($"Level{i}: ");
                LevelOrder(root, i, 0);
                Console.WriteLine();
            }
        }
        public void PrintTreeLeftToRight()
        {
            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("Printing Tree from left to right");
            Console.WriteLine("---------------------------------");
            ReverseInOrder(root, 0, 8);
        }
    }

    public class FibTree: BinaryTree
    {
        public FibTree(int n)
        {
            root = new Node(Fibonacci.nthFib(n));
            CreateFibonacciTree(n);
        }
        public void CreateFibonacciTree(int n)
        {
            if (n < 2)
            {
                root = new Node(Fibonacci.nthFib(n));
                return;
            }

            root = new Node(Fibonacci.nthFib(n));

            Node leftNode = new Node(Fibonacci.nthFib(n - 1));
            Node rightNode = new Node(Fibonacci.nthFib(n - 2));

            root.SetLeftChild(leftNode);
            root.SetRightChild(rightNode);

            CreateLeftComplete(root, n);
            CreateRightComplete(root, n);
        }

        void CreateLeftComplete(Node binaryNode, int n)
        {
            if (n < 3)
            {
                binaryNode.SetLeftChild(new Node(Fibonacci.nthFib(1)));
                binaryNode.SetRightChild(new Node(Fibonacci.nthFib(0)));
                return;
            }

            Node leftNode = new Node(Fibonacci.nthFib(n - 1));

            binaryNode.SetLeftChild(leftNode);

            CreateLeftComplete(binaryNode.GetLeftChild(), n - 1);
            CreateRightComplete(binaryNode.GetLeftChild(), n - 1);
        }
        void CreateRightComplete(Node binaryNode, int n)
        {
            if (n < 3)
            {
                binaryNode.SetLeftChild(new Node(Fibonacci.nthFib(1)));
                binaryNode.SetRightChild(new Node(Fibonacci.nthFib(0)));
                return;
            }

            Node rightNode = new Node(Fibonacci.nthFib(n - 2));

            binaryNode.SetRightChild(rightNode);
            CreateRightComplete(binaryNode.GetRightChild(), n - 2);
            CreateLeftComplete(binaryNode.GetRightChild(), n - 2);
        }
    }

}
