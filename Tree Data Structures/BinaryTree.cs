using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree_Data_Structures
{
    public class TreeNode
    {
        public int Value;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }


    public class BinaryTree
    {
        public TreeNode Root;

        public BinaryTree()
        {
            Root = null;
        }

    
        public void Insert(int value)
        {
            if (Root == null)
                Root = new TreeNode(value);
            else
                InsertRec(Root, value);
        }

        private void InsertRec(TreeNode node, int value)
        {
            if (value < node.Value)
            {
                if (node.Left == null)
                    node.Left = new TreeNode(value);
                else
                    InsertRec(node.Left, value);
            }
            else
            {
                if (node.Right == null)
                    node.Right = new TreeNode(value);
                else
                    InsertRec(node.Right, value);
            }
        }

       
        public bool IsBalanced()
        {
            return CheckHeight(Root) != -1;
        }

     
        private int CheckHeight(TreeNode node)
        {
            if (node == null)
                return 0;

            int leftHeight = CheckHeight(node.Left);
            if (leftHeight == -1) return -1; 

            int rightHeight = CheckHeight(node.Right);
            if (rightHeight == -1) return -1;

            if (Math.Abs(leftHeight - rightHeight) > 1)
                return -1;

            return Math.Max(leftHeight, rightHeight) + 1;
        }

        public void PrintInOrder(TreeNode node)
        {
            if (node == null) return;

            PrintInOrder(node.Left);
            Console.Write(node.Value + " ");
            PrintInOrder(node.Right);
        }
    }
}

