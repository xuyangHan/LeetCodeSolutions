using System;
using System.Reflection;

namespace LeetCode.DataStructures
{
    public class LinkedListTests
    {
        #region 21 归并两个有序的链表 - Merge Two Sorted Lists (Easy)
        public void LeetCode21()
        {

        }

        private ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null) return list2;
            if (list2 == null) return list1;

            if (list1.val < list2.val)
            {
                list1.next = MergeTwoLists(list1.next, list2);
                return list1;
            }
            else
            {
                list2.next = MergeTwoLists(list1, list2.next);
                return list2;
            }
        }

        private class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        #endregion

        #region 141. Linked List Cycle
        private bool HasCycle(ListNode head)
        {
            HashSet<ListNode> visitedNodes = new HashSet<ListNode>();
            while (head != null)
            {
                if (visitedNodes.Contains(head))
                {
                    return true;
                }
                visitedNodes.Add(head);
                head = head.next;
            }

            return false;
        }
        #endregion

        #region 206 链表反转 - Reverse Linked List (Easy)
        private ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            ListNode next = head.next;
            ListNode newHead = ReverseList(next);
            next.next = head;
            head.next = null;
            return newHead;
        }
        #endregion

        #region 876. Middle of the Linked List
        private ListNode MiddleNode(ListNode head)
        {
            List<ListNode> nodes = new List<ListNode>();

            while (head != null)
            {
                nodes.Add(head);
                head = head.next;
            }

            int idx = nodes.Count / 2;
            if (nodes.Count % 2 == 1)
            {
                idx += 1;
            }

            return nodes[idx];
        }

        #endregion

        #region 234. Palindrome Linked List
        public void LeetCode234()
        {

        }

        private bool IsPalindrome(ListNode head)
        {
            string a = "";
            while (head != null)
            {
                a += head.val;
                head = head.next;
            }

            return a == a.Reverse();
        }
        #endregion
    }
}

