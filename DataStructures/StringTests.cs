using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LeetCode.DataStructures
{
    public class StringTests
    {
        /// <summary>
        /// String Methods: 
        ///        string.Concat(); // Combines multiple strings. 
        ///        string.Join(); // Joins elements with a separator. 
        ///        str.Split(); // Splits a string based on delimiters. 
        ///        str.ToUpper(); // Converts to uppercase. 
        ///        str.ToLower(); // Converts to lowercase. 
        ///        str.Trim(); // Removes leading and trailing whitespace. 
        ///        str.Substring(); // Extracts a portion of the string.
        /// s = s1 + s2;
        /// string[] words = s1.Split(" ").ToArray();
        /// s = string.Join(" ", words);
        /// char[] charArray = originalString.ToCharArray();
        /// char a = stt[i];
        /// </summary>

        #region 字符串循环移位包含
        // 给定两个字符串 s1 和 s2，要求判定 s2 是否能够被 s1 做循环移位得到的字符串包含。
        // s1 = AABCD, s2 = CDAA
        // Return : true
        public void 字符串循环移位包含()
        {
            string 串1 = "AABCD";
            string 串2 = "CDAA";
            bool result = Is字符串循环移位包含(串1, 串2);
        }

        private bool Is字符串循环移位包含(string s1, string s2)
        {
            s1 += s1;
            return s1.Contains(s2);
        }

        #endregion

        #region 字符串循环移位
        // s = "abcd123" k = 3
        // Return "123abcd"
        public void 字符串循环移位()
        {
            string s1 = "abcd123";
            int k = 3;
            string result = 字符串循环移位(s1, k);
        }

        private string 字符串循环移位(string s1, int k)
        {
            return s1.Substring(s1.Length - k, k) + s1.Substring(0, s1.Length - k);
        }
        #endregion

        #region 字符串中单词的翻转
        // s = "I am a student"
        // Return "student a am I"
        public void 字符串中单词的翻转()
        {
            string s1 = "I am a student";
            string result = 字符串中单词的翻转(s1);
        }

        private string 字符串中单词的翻转(string s1)
        {
            string[] words = s1.Split(" ").ToArray();
            Array.Reverse(words);
            return string.Join(" ", words);
        }
        #endregion


        #region 9 判断一个整数是否是回文数 - Palindrome Number (Easy)

        // 判断一个整数是否是回文数 - Palindrome Number (Easy)
        //        Input: x = 121
        //        Output: true
        //        Explanation: 121 reads as 121 from left to right and from right to left.
        public void LeetCode9()
        {
            int x = 121;
            bool result = IsPalindromeNumber(x);
        }

        private bool IsPalindromeNumber(int x)
        {
            string x_str = x.ToString();
            char[] x_charArray = x_str.ToCharArray();
            Array.Reverse(x_charArray);
            string x_reversedStr = new string(x_charArray);

            return x_str == x_reversedStr;
        }


        // 看调转顺序后是否仍然和原字符串相同
        // 熟悉 string => char array => string 

        #endregion

        #region 67. Add Binary
        public string AddBinary(string a, string b)
        {
            StringBuilder result = new StringBuilder();

            int carry = 0;
            int i = a.Length - 1;
            int j = b.Length - 1;

            while (i >= 0 || j >= 0 || carry > 0)
            {
                int sum = carry;

                if (i >= 0)
                {
                    sum += a[i] - '0';
                    i--;
                }

                if (j >= 0)
                {
                    sum += b[j] - '0';
                    j--;
                }

                result.Insert(0, sum % 2);
                carry = sum / 2;
            }

            return result.ToString();
        }
        #endregion

        #region 125. Valid Palindrome (Easy)

        //        Input: s = "A man, a plan, a canal: Panama"
        //Output: true
        //Explanation: "amanaplanacanalpanama" is a palindrome.
        public void LeetCode125()
        {
            string x = "A man, a plan, a canal: Panama";
            bool result = IsPalindrome(x);
        }

        private bool IsPalindrome(string s)
        {
            string s1 = Regex.Replace(s, "[^a-zA-Z0-9]", "").ToLower();
            char[] s1_charArray = s1.ToCharArray();
            Array.Reverse(s1_charArray);
            string s2 = new string(s1_charArray);
            return s1 == s2;
        }

        #endregion

        #region 191. Number of 1 Bits
        public void LeetCode191()
        {
            uint n = 11;
            int ans = HammingWeight(n);
        }

        private int HammingWeight(uint n)
        {
            string binary = Convert.ToString(n, 2);
            return binary.Select(a => a == '1').Count();
        }
        #endregion

        #region 205 字符串同构 - Isomorphic Strings (Easy)

        // 字符串同构 - Isomorphic Strings (Easy)
        //        Given "egg", "add", return true.
        //        Given "foo", "bar", return false.
        //        Given "paper", "title", return true.
        public void LeetCode205()
        {
            string s = "eggg";
            string t = "adda";
            bool result = IsomorphicStrings(s, t);
        }

        private bool IsomorphicStrings(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            // char => idx 
            Dictionary<char, int> s_dict = new Dictionary<char, int>();
            Dictionary<char, int> t_dict = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                char char_in_s = s[i];
                char char_in_t = t[i];

                if (s_dict.ContainsKey(char_in_s) && t_dict.ContainsKey(char_in_t))
                {
                    if (s_dict[char_in_s] != t_dict[char_in_t])
                    {
                        return false;
                    }
                }
                else if (!s_dict.ContainsKey(char_in_s) && !t_dict.ContainsKey(char_in_t))
                {
                    s_dict.Add(char_in_s, i);
                    t_dict.Add(char_in_t, i);
                }
                else
                {
                    return false;
                }

                s_dict[char_in_s] = i;
                t_dict[char_in_t] = i;
            }
            return true;
        }


        // HashTable 记录一个字符上次出现的位置，如果两个字符串中的字符上次出现的位置一样，那么就属于同构。
        #endregion

        #region 242 两个字符串包含的字符是否完全相同 - Valid Anagram (Easy)

        // 两个字符串包含的字符是否完全相同 - Valid Anagram (Easy)
        // s = "anagram", t = "nagaram", return true.
        // s = "rat", t = "car", return false.
        public void LeetCode242()
        {
            string s = "anagram";
            string t = "nagaram";

            bool result = IsValidAnagram(s, t);
        }

        private bool IsValidAnagram(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            Dictionary<char, int> s_dict = new Dictionary<char, int>();
            foreach (char char_in_s in s)
            {
                if (s_dict.ContainsKey(char_in_s))
                {
                    s_dict[char_in_s] += 1;
                }
                else
                {
                    s_dict.Add(char_in_s, 1);
                }
            }

            foreach (char char_in_t in t)
            {
                if (s_dict.ContainsKey(char_in_t))
                {
                    if (s_dict[char_in_t] == 0)
                    {
                        return false;
                    }
                    else
                    {
                        s_dict[char_in_t] -= 1;
                    }

                }
                else
                {
                    return false;
                }
            }

            foreach (var kv in s_dict)
            {
                if (kv.Value != 0)
                {
                    return false;
                }
            }

            return true;
        }


        // 可以用 HashMap 来映射字符与出现次数，然后比较两个字符串出现的字符数量是否相同。

        #endregion

        #region 409 计算一组字符集合可以组成的回文字符串的最大长度 - Longest Palindrome (Easy)

        // 计算一组字符集合可以组成的回文字符串的最大长度 - Longest Palindrome (Easy)
        //        Input : "abccccdd"
        //        Output : 7
        //        Explanation : One longest palindrome that can be built is "dccaccd", whose length is 7.

        public void LeetCode409()
        {
            string s = "abccccdd";
            int result = LongestPalindrome(s);
        }

        private int LongestPalindrome(string s)
        {
            int result = 0;
            Dictionary<char, int> cnts = new Dictionary<char, int>();
            foreach (char char_in_s in s)
            {
                if (cnts.ContainsKey(char_in_s))
                {
                    cnts[char_in_s] += 1;
                }
                else
                {
                    cnts.Add(char_in_s, 1);
                }
            }

            bool flagOddAdded = false;
            foreach (var kv in cnts)
            {
                int cnt = kv.Value;
                if (cnt % 2 == 0)
                {
                    result += cnt;
                }
                else
                {
                    result += cnt - 1;
                    flagOddAdded = true;
                }
            }

            if (flagOddAdded)
            {
                result += 1;
            }

            return result;
        }


        // 每个字符有偶数个可以用来构成回文字符串。
        // 因为回文字符串最中间的那个字符可以单独出现，所以如果有单独的字符就把它放到最中间。
        #endregion

        #region 647 回文子字符串个数 - Palindromic Substrings (Medium)

        // 回文子字符串个数 - Palindromic Substrings (Medium)
        //        Input: "aaa"
        //        Output: 6
        //        Explanation: Six palindromic strings: "a", "a", "a", "aa", "aa", "aaa".
        public void LeetCode647()
        {
            string s = "aaa";
            int result = PalindromicSubstrings(s);
        }


        // solution 1 - brutal force
        private int PalindromicSubstrings1(string s)
        {
            int result = 0;
            for (int i = 0; i <= s.Length - 1; i++)
            {
                for (int j = i + 1; j <= s.Length; j++)
                {
                    string subString = s.Substring(i, j - i);
                    if (IsPalindromeString(subString))
                    {
                        result += 1;
                    }
                }
            }
            return result;
        }

        private bool IsPalindromeString(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            string reversedStr = new string(charArray);

            return s == reversedStr;
        }

        // 看调转顺序后是否仍然和原字符串相同
        // 熟悉 string => char array => string 


        // solution 2 - reuse sub PalindromeString
        private int PalindromicSubstrings(string s)
        {
            int result = 0;
            for (int center = 0; center < s.Length; center++)
            {
                // For odd-length palindromes
                result += CountPalindromes(s, center, center);

                // For even-length palindromes
                result += CountPalindromes(s, center, center + 1);
            }
            return result;
        }

        private int CountPalindromes(string s, int left, int right)
        {
            int count = 0;

            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                count += 1;
                left -= 1;
                right += 1;
            }

            return count;

        }

        // 从字符串的某一位开始，尝试着去扩展子字符串。
        // hint - How can we reuse a previously computed palindrome to compute a larger palindrome?
        // hint - If “aba” is a palindrome, is “xabax” a palindrome? Similarly is “xabay” a palindrome?
        // hint - Complexity based hint:
        // If we use brute force and check whether for every start and end position a substring is a palindrome we have O(n^2) start - end pairs and O(n) palindromic checks.Can we reduce the time for palindromic checks to O(1) by reusing some previous computation?
        #endregion

        #region 696 统计二进制字符串中连续 1 和连续 0 数量相同的子字符串个数 - Count Binary Substrings (Easy)

        // 统计二进制字符串中连续 1 和连续 0 数量相同的子字符串个数 - Count Binary Substrings (Easy)
        //        Input: "00110011"
        //        Output: 6
        //        Explanation: There are 6 substrings that have equal number of consecutive 1's and 0's: "0011", "01", "1100", "10", "0011", and "01".
        public void LeetCode696()
        {
            string s = "001100111";
            int result = BinarySubstringsCount(s);
        }

        private int BinarySubstringsCount(string s)
        {
            int count = 0;
            int prevRunLength = 0;
            int currRunLength = 1; // Initialize the current run length

            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == s[i - 1])
                {
                    currRunLength += 1;
                }
                else
                {
                    count += Math.Min(prevRunLength, currRunLength);
                    prevRunLength = currRunLength;
                    currRunLength = 1;
                }
            }

            return count + Math.Min(prevRunLength, currRunLength);
        }


        //  First, I count the number of 1 or 0 grouped consecutively.
        //  For example "0110001111" will be[1, 2, 3, 4].

        //  Second, for any possible substrings with 1 and 0 grouped consecutively, the number of valid substring will be the minimum number of 0 and 1.
        //  For example "0001111", will be min(3, 4) = 3, ("01", "0011", "000111")

        #endregion

        #region 1208. Get Equal Substrings Within Budget
        // Input: s = "abcd", t = "bcdf", maxCost = 3
        // Output: 3
        // Explanation: "abc" of s can change to "bcd".
        // That costs 3, so the maximum length is 3.

        public int EqualSubstring(string s, string t, int maxCost)
        {
            int n = s.Length;
            int[] cost = new int[n];
            for (int i = 0; i < n; i++)
            {
                cost[i] = Math.Abs(s[i] - t[i]);
            }

            int maxLength = 0;
            int start = 0;
            int end = 0;
            int sum = 0;
            while (end < n)
            {
                sum += cost[end];
                while (sum > maxCost)
                {
                    sum -= cost[start];
                    start++;
                }

                maxLength = Math.Max(maxLength, end - start + 1);
                end++;
            }

            return maxLength;
        }


        #endregion

        #region 1404. Number of Steps to Reduce a Number in Binary Representation to One
        // Input: s = "1101"
        // Output: 6
        // Explanation: "1101" corressponds to number 13 in their decimal representation.
        // Step 1) 13 is odd, add 1 and obtain 14.
        // Step 2) 14 is even, divide by 2 and obtain 7.
        // Step 3) 7 is odd, add 1 and obtain 8.
        // Step 4) 8 is even, divide by 2 and obtain 4.
        // Step 5) 4 is even, divide by 2 and obtain 2.
        // Step 6) 2 is even, divide by 2 and obtain 1.
        public int NumSteps(string s)
        {
            int steps = 0;
            int carry = 0;
            for (int i = s.Length - 1; i > 0; i--)
            {
                if (s[i] - '0' + carry == 1)
                {
                    steps += 2;
                    carry = 1;
                }
                else
                {
                    steps += 1;
                }
            }

            return steps + carry;
        }
        #endregion
    }
}

