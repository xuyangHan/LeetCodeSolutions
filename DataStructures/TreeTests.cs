using System;
using static LeetCode.DataStructures.TreeTests;

namespace LeetCode.DataStructures
{
    public class TreeTests
    {

        #region 110. Balanced Binary Tree
        //        Input: root = [3,9,20,null,null,15,7]
        //  Output: true
        public bool IsBalanced(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            return Math.Abs(GetHeight(root.left) - GetHeight(root.right)) <= 1 && IsBalanced(root.left) && IsBalanced(root.right);
        }

        private int GetHeight(TreeNode treeNode)
        {
            if (treeNode == null)
            {
                return 0;
            }
            return 1 + Math.Max(GetHeight(treeNode.left), GetHeight(treeNode.right));
        }
        #endregion


        #region 226. Invert Binary Tree
        public void LeetCode226()
        {
            int[] nodes = { 1, 2 };

            BinaryTree tree = new BinaryTree();
            TreeNode root = tree.InitializeBinaryTree(nodes);
            TreeNode invertedTree = InvertTree(root);
        }
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }
            TreeNode temp = root.left;
            root.left = InvertTree(root.right);
            root.right = InvertTree(temp);

            return root;
        }
        public class BinaryTree
        {
            // Function to insert a node into the binary tree
            public TreeNode Insert(TreeNode root, int val)
            {
                if (root == null)
                {
                    root = new TreeNode(val);
                }
                else if (val < root.val)
                {
                    root.left = Insert(root.left, val);
                }
                else
                {
                    root.right = Insert(root.right, val);
                }

                return root;
            }

            // Function to initialize the binary tree with given nodes
            public TreeNode InitializeBinaryTree(int[] nodes)
            {
                TreeNode root = null;
                BinaryTree tree = new BinaryTree();

                foreach (int node in nodes)
                {
                    root = tree.Insert(root, node);
                }

                return root;
            }

            // Function to perform inorder traversal of the binary tree (for verification)
            public void InorderTraversal(TreeNode root)
            {
                if (root != null)
                {
                    InorderTraversal(root.left);
                    Console.Write(root.val + " ");
                    InorderTraversal(root.right);
                }
            }
        }
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        #endregion

        #region 235. Lowest Common Ancestor of a Binary Search Tree
        //        Input: root = [6,2,8,0,4,7,9,null,null,3,5], p = 2, q = 8
        //Output: 6
        //Explanation: The LCA of nodes 2 and 8 is 6.
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (p.val > root.val && q.val > root.val)
                return LowestCommonAncestor(root.right, p, q);
            else if (p.val < root.val && q.val < root.val)
                return LowestCommonAncestor(root.left, p, q);
            else
                return root;
        }
        #endregion

        #region 100. Same Tree
        public void LeetCode100()
        {
            TreeNode p = new TreeNode(val: 1, left: new TreeNode(), right: new TreeNode(3));
            TreeNode q = new TreeNode(val: 1, left: new TreeNode(2), right: new TreeNode());
            IsSameTree(p, q);
        }
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
            {
                return true;
            }

            if (p != null && q == null)
            {
                return false;
            }

            if (p == null && q != null)
            {
                return false;
            }

            if (p.val != q.val)
            {
                return false;
            }


            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }

        #endregion
    }
}

