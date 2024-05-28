using System;

namespace LeetCode.DataStructures
{
    public class StacksQueueTests
    {
        /// <summary>
        /// Methods of Stacks 
        /// stack.Push() - adds element to the top of the stack
        /// stack.Pop() - removes and returns an element from the top of the stack
        /// stack.Peek() - returns an element from the top of the stack without removing
        ///
        /// Methods of Queues 
        /// queue.Enqueue() - adds an element to the end of the queue
        /// queue.Dequeue() - removes and returns an element from the beginning of the queue
        /// queue.Peek() - returns an element from the beginning of the queue without removing
        /// </summary>



        #region 20 用栈实现括号匹配 - Valid Parentheses (Easy)
        public void LeetCode20()
        {
            string s = "()";
            bool res = IsValidParentheses(s);
        }

        private bool IsValidParentheses(string s)
        {
            Dictionary<char, char> parenthesesPairs = new Dictionary<char, char>()
            {
                { '(', ')' },
                { '{', '}' },
                { '[', ']' },
            };


            Stack<char> chars_s = new Stack<char>();

            foreach (char c in s)
            {
                if (chars_s.Count == 0)
                {
                    chars_s.Push(c);
                }
                else // compare if the last element is a pair with new element 
                {
                    char lastChar = chars_s.Peek();
                    if (!parenthesesPairs.ContainsKey(lastChar))
                    {
                        return false;
                    }// because )}] cannot be canceled anymore 


                    if (parenthesesPairs[lastChar] == c)
                    {
                        chars_s.Pop();
                    }
                    else
                    {
                        chars_s.Push(c);
                    }
                }
            }


            return chars_s.Count == 0;
        }
        #endregion

        #region 155 最小值栈 - Min Stack (Easy)
        public class MinStack
        {
            private Stack<int> nums = new Stack<int>();
            private Stack<int> mins = new Stack<int>();
            private int min = int.MaxValue;

            public MinStack()
            {

            }

            public void Push(int val)
            {
                nums.Push(val);
                min = Math.Min(min, val);
                mins.Push(min);
            }

            public void Pop()
            {
                nums.Pop();
                mins.Pop();

                if (mins.Count > 0)
                {
                    min = mins.Peek();
                }
                else
                {
                    min = int.MaxValue;
                }
            }

            public int Top()
            {
                return nums.Peek();
            }

            public int GetMin()
            {
                return min;
            }
        }

        /**
         * Your MinStack object will be instantiated and called as such:
         * MinStack obj = new MinStack();
         * obj.Push(val);
         * obj.Pop();
         * int param_3 = obj.Top();
         * int param_4 = obj.GetMin();
         */
        #endregion

        #region 225 用队列实现栈 - Implement Stack using Queues (Easy)
        public void LeetCode225()
        {
            MyStack obj = new MyStack();
            obj.Push(1);
            obj.Push(2);
            int param_1 = obj.Top();
            int param_2 = obj.Pop();
            int param_3 = obj.Pop();
            bool param_4 = obj.Empty();
        }
        public class MyStack
        {
            private Queue<int> nums { get; set; } = new Queue<int>();

            public MyStack()
            {

            }

            public void Push(int x)
            {
                nums.Enqueue(x);
            }

            public int Pop()
            {
                for (int i = 0; i < nums.Count - 1; i++)
                {
                    Push(nums.Dequeue());
                }
                return nums.Dequeue();
            }

            public int Top()
            {
                for (int i = 0; i < nums.Count - 1; i++)
                {
                    Push(nums.Dequeue());
                }
                int res = nums.Dequeue();
                Push(res);
                return res;
            }

            public bool Empty()
            {
                return nums.Count == 0;
            }
        }

        /**
         * Your MyStack object will be instantiated and called as such:
         * MyStack obj = new MyStack();
         * obj.Push(x);
         * int param_2 = obj.Pop();
         * int param_3 = obj.Top();
         * bool param_4 = obj.Empty();
         */
        #endregion

        #region 232 用栈实现队列 - Implement Queue using Stacks (Easy)
        public void LeetCode232()
        {
            MyQueue obj = new MyQueue();
            obj.Push(1);
            obj.Push(2);
            int param_2 = obj.Pop();
            int param_3 = obj.Peek();
            bool param_4 = obj.Empty();
        }
        public class MyQueue
        {
            private Stack<int> nums { get; set; } = new Stack<int>();

            public MyQueue()
            {

            }

            public void Push(int x)
            {
                nums.Push(x);
            }

            public int Pop()
            {
                Stack<int> reversedStack = ReverseStack(nums);
                int res = reversedStack.Pop();
                nums = ReverseStack(reversedStack);
                return res;
            }

            public int Peek()
            {
                Stack<int> reversedStack = ReverseStack(nums);
                int res = reversedStack.Peek();
                nums = ReverseStack(reversedStack);
                return res;
            }

            public bool Empty()
            {
                return nums.Count == 0;
            }

            private Stack<int> ReverseStack(Stack<int> nums)
            {
                Stack<int> reversedStack = new Stack<int>();
                while (nums.Count > 0)
                {
                    reversedStack.Push(nums.Pop());
                }

                return reversedStack;
            }
        }

        /**
         * Your MyQueue object will be instantiated and called as such:
         * MyQueue obj = new MyQueue();
         * obj.Push(x);
         * int param_2 = obj.Pop();
         * int param_3 = obj.Peek();
         * bool param_4 = obj.Empty();
         */
        #endregion

        #region 503 循环数组中比当前元素大的下一个元素 - Next Greater Element II (Medium)
        public void LeetCode503()
        {
            int[] temperatures = new int[]
            {
                1,2,3,4,3
            };
            int[] res = NextGreaterElements(temperatures);
        }

        public int[] NextGreaterElements(int[] nums)
        {
            int[] res = new int[nums.Length * 2];

            Stack<int> idx = new Stack<int>();
            int[] nums_concat = nums.Concat(nums).ToArray();
            for (int i = 0; i < nums_concat.Length; i++)
            {
                res[i] = -1;
                while (idx.Count > 0 && nums_concat[idx.Peek()] < nums_concat[i])
                {
                    res[idx.Peek()] = nums_concat[i];
                    idx.Pop();
                }

                idx.Push(i);
            }

            return res.Take(nums.Length).ToArray();
        }
        #endregion

        #region 739 数组中元素与下一个比它大的元素之间的距离 - Daily Temperatures (Medium)
        public void LeetCode739()
        {
            int[] temperatures = new int[]
            {
                73,74,75,71,69,72,76,73
            };
            int[] res = DailyWarmerTemperatures_Stack(temperatures);
        }

        public int[] DailyWarmerTemperatures_ForLoop(int[] temperatures)
        {
            int[] res = new int[temperatures.Length];

            for (int i = 0; i < temperatures.Length; i++)
            {
                for (int j = i + 1; j < temperatures.Length; j++)
                {
                    if (temperatures[j] > temperatures[i])
                    {
                        res[i] = j - i;
                        break;
                    }
                }
            }
            return res;
        }

        public int[] DailyWarmerTemperatures_Stack(int[] temperatures)
        {
            int[] res = new int[temperatures.Length];
            Stack<int> idx = new Stack<int>();

            for (int i = 0; i < temperatures.Length; i++)
            {
                while (idx.Count != 0 && temperatures[i] > temperatures[idx.Peek()])
                {
                    res[idx.Peek()] = i - idx.Pop();
                }

                idx.Push(i);
            }

            return res;
        }
        #endregion

    }
}

