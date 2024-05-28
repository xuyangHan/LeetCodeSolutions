using System;
using static LeetCode.DataStructures.TreeTests;

namespace LeetCode.DataStructures
{
    public class EmptyClass
    {
        public void Test()
        {
            var output = SummaryRanges(nums: new int[] { -2147483648, -2147483647, 2147483647 });
        }

        public int RemoveDuplicates(int[] nums)
        {
            int j = 0;
            int element_count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == nums[j])
                {
                    element_count += 1;
                }

                if (element_count <= 2)
                {
                    nums[j] = nums[i];
                    j++;
                }
                else
                {
                    element_count = 0;
                }
            }

            return j;
        }

        public IList<string> SummaryRanges(int[] nums)
        {
            List<string> output = new List<string>();

            if (nums.Length == 0)
            {
                return output;
            }

            int min = nums[0];
            int max = nums[0];

            for (int i = 0; i < nums.Length; i++)
            {
                int num = nums[i];
                if (i + 1 >= nums.Length)
                {
                    max = num;
                    output.Add(GetRangeString(min, max));
                    break;
                }
                int num_next = nums[i + 1];

                if ((long)num_next - num > 1)
                {
                    max = num;
                    output.Add(GetRangeString(min, max));
                    min = num_next;
                }
            }

            return output;
        }

        public string GetRangeString(int min, int max)
        {
            if (min == max)
            {
                return min.ToString();
            }

            return min.ToString() + "->" + max.ToString();
        }
    }
}

