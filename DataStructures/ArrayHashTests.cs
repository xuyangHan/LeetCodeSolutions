using System;
using System.Linq;

namespace LeetCode.DataStructures
{
    public class ArrayHashTests
    {
        /// <summary>
        /// Methods of Arrays
        ///  Initiation: int[] res = new int[5]; int[] res = new int[]{};
        ///  nums.Take(10).ToArray();
        /// </summary>
        #region 1 数组中两个数的和为给定值 - Two Sum (Easy)
        // 数组中两个数的和为给定值
        // Input: nums = [2,7,11,15], target = 9
        // Output: [0,1]
        // Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].

        public void LeetCode1()
        {
            int[] nums = new int[]
            {
                2,7,11,15
            };
            int target = 18;
            int[] result = TwoSum(nums, target);
        }

        private int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> nums_dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int num = nums[i];
                if (nums_dict.ContainsKey(target - num))
                {
                    return new int[]
                    {
                        nums_dict[target - num], i
                    };
                }
                else
                {
                    if (!nums_dict.ContainsKey(num))
                    {
                        nums_dict.Add(num, i);
                    }
                }
            }

            int[] result = new int[]
            {

            };
            return result;
        }

        // 用 HashMap 存储数组元素和索引的映射，在访问到 nums[i] 时，判断 HashMap 中是否存在 target - nums[i]，如果存在说明 target - nums[i] 所在的索引和 i 就是要找的两个数。
        #endregion

        #region 11 Container With Most Water (Medium)
        // Input: height = [1,8,6,2,5,4,8,3,7]
        // Output: 49
        public void LeetCode11()
        {
            int[] height = new int[]
            {
                1,8,6,2,5,4,8,3,7
            };
            int result = MaxArea(height);
        }

        private int MaxArea(int[] height)
        {
            int left = 0;
            int right = height.Length - 1;

            int ans = 0;
            while (left < right)
            {

                int area = (right - left) * Math.Min(height[left], height[right]);

                if (area > ans)
                {
                    ans = area;
                }

                if (height[left] > height[right])
                {
                    right--;

                    while (left < right && height[right] < height[right + 1]) // for sure smaller than previous one 
                    {
                        right--;
                    }
                }
                else
                {
                    left++;

                    while (left < right && height[left] < height[left - 1]) // for sure smaller than previous one 
                    {
                        left++;
                    }
                }
            }
            return ans;
        }
        // Two pointers with optimizations 
        #endregion

        #region 15 Three Sum (Medium)
        // Input: nums = [-1,0,1,2,-1,-4]
        // Output: [[-1,-1,2],[-1,0,1]]
        public void LeetCode15()
        {
            int[] nums = new int[]
            {
                -1,0,1,2,-1,-4
            };
            IList<IList<int>> result = ThreeSum(nums);
        }

        private IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            if (nums.Length < 3)
            {
                return ans;
            }

            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (nums[i] > 0) break; // if the first number is greater than 0, then the sum cannot be 0

                if (i > 0 && nums[i] == nums[i - 1]) continue; // skipping repeated numbers to avoid repeating triples

                int left = i + 1;
                int right = nums.Length - 1;

                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];

                    if (sum == 0)
                    {
                        ans.Add(new List<int>() { nums[i], nums[left], nums[right] });
                        while (left < right && nums[left] == nums[left + 1]) left++; // skipping repeated numbers to avoid repeating triples
                        while (left < right && nums[right] == nums[right - 1]) right--; // skipping repeated numbers to avoid repeating triples
                        left++;
                        right--;
                    }
                    else if (sum < 0)
                    {
                        left++;
                    }
                    else // sum > 0
                    {
                        right--;
                    }
                }

            }

            return ans;
        }


        // for i + two pointers with optimizations 
        // IList<int> ans = new List<int>()
        #endregion

        #region 33 Search in Rotated Sorted Array (Medium)
        // Input: nums = [4,5,6,7,0,1,2], target = 0
        // Output: 4
        // return Array.FindIndex(nums, element => element == target);
        #endregion

        #region 53 Maximum Subarray (Medium)
        // Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
        // Output: 6
        // Explanation: The subarray[4, -1, 2, 1] has the largest sum 6.
        public void LeetCode53()
        {
            int[] nums = new int[]
            {
                -2,1,-3,4,-1,2,1,-5,4
            };
            int result = MaxSubArray(nums);
        }

        private int MaxSubArray(int[] nums)
        {
            int maxSum = nums[0];
            int currentSum = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                currentSum = Math.Max(nums[i], currentSum + nums[i]);
                maxSum = Math.Max(maxSum, currentSum);
            }

            return maxSum;
        }

        #endregion

        #region 66. Plus One
        public void LeetCode66()
        {
            int[] originalArray = new int[]
            {
                9, 9
            };
            int newElement = 1;
            int[] newArray = PlusOne(originalArray);
        }
        public int[] PlusOne(int[] digits)
        {
            digits[digits.Length - 1] += 1;
            if (digits[digits.Length - 1] != 10)
            {
                return digits;
            }

            digits[digits.Length - 1] = 0;
            bool addCarry = true;
            int idx = digits.Length - 2;
            while (addCarry && idx >= 0)
            {
                if (digits[idx] == 9)
                {
                    digits[idx] = 0;
                }
                else
                {
                    digits[idx] += 1;
                    addCarry = false;
                }
                idx -= 1;
            }

            if (addCarry)
            {
                return AddElementToBeginning(digits, 1);
            }

            return digits;
        }

        private int[] AddElementToBeginning(int[] originalArray, int newElement)
        {
            // Create a new array with a size increased by 1
            int[] newArray = new int[originalArray.Length + 1];

            // Copy elements from the original array to the new array, shifting them to make space
            newArray[0] = newElement;
            for (int i = 0; i < originalArray.Length; i++)
            {
                newArray[i + 1] = originalArray[i];
            }
            return newArray;
        }
        #endregion

        #region 118. Pascal's Triangle
        public void LeetCode118()
        {
            var ans = GeneratePascalTriangle(14);
        }

        public IList<IList<int>> GeneratePascalTriangle(int numRows)
        {
            List<IList<int>> ans = new List<IList<int>>();
            for (int i = 1; i <= numRows; i++)
            {
                ans.Add(GetPascalRow(i));
            }

            return ans;
        }

        private List<int> GetPascalRow(int n)
        {
            List<int> ans = new List<int>();
            long numerator = Factorial(n - 1);
            for (int i = 0; i < n; i++)
            {
                long denominator = Factorial(i) * Factorial(n - i - 1);
                int val = (int)(numerator / denominator);
                ans.Add(val);
            }
            return ans;
        }

        private long Factorial(int num)
        {
            long result = 1;
            for (int i = 2; i <= num; i++)
            {
                result *= i;
            }
            return result;

        }
        #endregion


        #region 121 Best Time to Buy and Sell Stock
        //        Input: prices = [7,1,5,3,6,4]
        //        Output: 5
        //Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        //Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.
        public void LeetCode121()
        {
            int[] prices = new int[]
            {
                7,1,5,3,6,4
            };
            int result = MaxProfit(prices);
        }

        public int MaxProfit(int[] prices)
        {
            int maxProfit = 0;

            for (int i = 0; i < prices.Length - 1; i++)
            {
                for (int j = i + 1; j < prices.Length; j++)
                {
                    int profit = prices[j] - prices[i];
                    if (profit <= 0)
                    {
                        break;
                    }
                    maxProfit = Math.Max(maxProfit, profit);
                }
            }

            return maxProfit;
        }

        // 用 HashMap 存储数组元素和索引的映射，在访问到 nums[i] 时，判断 HashMap 中是否存在 target - nums[i]，如果存在说明 target - nums[i] 所在的索引和 i 就是要找的两个数。
        #endregion



        #region 128 最长连续序列 - Longest Consecutive Sequence (Medium)
        // Given [100, 4, 200, 1, 3, 2],
        // The longest consecutive elements sequence is [1, 2, 3, 4]. Return its length: 4.
        public void LeetCode128()
        {
            int[] nums = new int[]
            {
                1,2,0,1
            };
            int result = LongestConsecutive(nums);
        }

        private int LongestConsecutive(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            int[] orderedNums = nums.OrderBy(a => a).ToArray();

            int res = 1;

            int res_temp = 1;
            int pre = orderedNums[0];
            for (int i = 1; i < orderedNums.Length; i++)
            {
                if (orderedNums[i] == pre)
                {
                    continue;
                }
                if (orderedNums[i] == pre + 1)
                {
                    res_temp += 1;
                }
                else
                {
                    res = Math.Max(res, res_temp);
                    res_temp = 1;
                }

                pre = orderedNums[i];
            }
            res = Math.Max(res, res_temp);
            return res;
        }
        #endregion

        #region 217 Contains Duplicate (Easy)
        // Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct.

        public void LeetCode217()
        {
            int[] nums = new int[]
            {
                1, 2, 3, 1
            };
            bool result = ContainsDuplicate(nums);
        }

        private bool ContainsDuplicate(int[] nums)
        {
            Dictionary<int, int> nums_dict = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (nums_dict.ContainsKey(num))
                {
                    return true;
                }
                else
                {
                    nums_dict.Add(num, 0);
                }
            }

            return false;
        }

        // 用 HashMap 存储数组元素和索引的映射，在访问到 nums[i] 时，判断 HashMap 中是否存在 


        #endregion

        #region 283 把数组中的 0 移到末尾 - Move Zeroes (Easy)
        // For example, given nums = [0, 1, 0, 3, 12], after calling your function, nums should be [1, 3, 12, 0, 0].

        public void LeetCode283()
        {
            int[] nums = new int[]
            {
                0, 1, 0, 3, 12
            };
            MoveZeroes2(nums);
        }

        public void MoveZeroes(ref int[] nums)
        {
            List<int> res = new List<int>();
            int zeroCnt = 0;
            foreach (int num in nums)
            {
                if (num != 0)
                {
                    res.Add(num);
                }
                else
                {
                    zeroCnt += 1;
                }
            }

            while (zeroCnt > 0)
            {
                res.Add(0);
                zeroCnt -= 1;
            }

            nums = res.ToArray();

        }


        public void MoveZeroes2(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        if (nums[j] != 0)
                        {
                            (nums[j], nums[i]) = (nums[i], nums[j]); // swap by using tuple 
                            break;
                        }
                    }
                }
            }
        }
        #endregion

        #region 594 最长和谐序列 - Longest Harmonious Subsequence (Easy)
        //        Input: [1,3,2,2,5,2,3,7]
        //        Output: 5
        //        Explanation: The longest harmonious subsequence is [3,2,2,2,3].
        //和谐序列中最大数和最小数之差正好为 1，应该注意的是序列的元素不一定是数组的连续元素。

        public void LeetCode594()
        {
            int[] nums = new int[]
            {
               1,3,2,2,5,2,3,7
            };
            int result = FindLHS(nums);
        }

        private int FindLHS(int[] nums)
        {
            Dictionary<int, int> nums_cnts = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (nums_cnts.ContainsKey(num))
                {
                    nums_cnts[num] += 1;
                }
                else
                {
                    nums_cnts.Add(num, 1);
                }
            }

            int LHS = 0;
            foreach (var kv in nums_cnts)
            {
                int num = kv.Key;

                if (nums_cnts.ContainsKey(num + 1))
                {
                    int LHS_temp = kv.Value + nums_cnts[num + 1];
                    LHS = Math.Max(LHS, LHS_temp);
                }
            }

            return LHS;
        }

        // 用 HashMap 存储数组元素的个数， 寻找相差1的元素
        #endregion


        #region 704. Binary Search
        // Input: nums = [-1,0,3,5,9,12], target = 9
        // Output: 4
        // Explanation: 9 exists in nums and its index is 4
        public void LeetCode704()
        {
            int[] nums = new int[]
            {
                -1,0,5
            };
            int target = 0;
            int result = Search(nums, target);
        }
        public int Search(int[] nums, int target)
        {
            return Array.IndexOf(nums, target);
        }
        #endregion

        #region 733. Flood Fill
        // Input: image = [[1,1,1],[1,1,0],[1,0,1]], sr = 1, sc = 1, color = 2
        // Output: [[2,2,2],[2,2,0],[2,0,1]]
        public void LeetCode733()
        {
            int[][] image = new int[][]
            {
                new int[]{ 1, 1, 1 },
                new int[]{ 1, 1, 0 },
                new int[]{ 1, 0, 1 }
            };
            int sr = 1, sc = 1, color = 2;
            int[][] result = FloodFill(image, sr, sc, color);
        }
        public int[][] FloodFill(int[][] image, int sr, int sc, int color)
        {
            int targetColor = image[sr][sc];
            if (targetColor == color)
            {
                return image;
            }
            image[sr][sc] = color;
            if (sc + 1 < image[sr].Length && image[sr][sc + 1] == targetColor)
            {
                image = FloodFill(image, sr, sc + 1, color);
            }
            if (sc - 1 >= 0 && image[sr][sc - 1] == targetColor)
            {
                image = FloodFill(image, sr, sc - 1, color);
            }
            if (sr + 1 < image.Length && image[sr + 1][sc] == targetColor)
            {
                image = FloodFill(image, sr + 1, sc, color);
            }
            if (sr - 1 >= 0 && image[sr - 1][sc] == targetColor)
            {
                image = FloodFill(image, sr - 1, sc, color);
            }
            return image;
        }
        #endregion

        #region 26. Remove Duplicates from Sorted Array
        public void LeetCode26()
        {
            int[] nums = new int[]
            {
                0,0,1,1,1,2,2,3,3,4
            };
            int l = RemoveDuplicates(nums);
        }

        public int RemoveDuplicates(int[] nums)
        {
            List<int> filterNums = new List<int>(){
            nums[0]
        };
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[i - 1])
                {
                    filterNums.Add(nums[i]);
                }
            }

            nums = filterNums.ToArray();
            return nums.Length;
        }
        #endregion
    }
}

