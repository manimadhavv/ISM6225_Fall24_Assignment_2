using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                // Create a boolean array to track the presence of numbers
                bool[] isCurrent = new bool[nums.Length + 1]; // +1 to handle 1-based index
            
            // Mark the numbers that are present in the input array
            foreach (int num in nums)
            {
                if (num >= 1 && num <= nums.Length)
                {
                    isCurrent[num] = true;
                }
            }
            
            // Create a list to store missing numbers
            List<int> missingNumbers = new List<int>();
            
            // Find the numbers that are missing
            for (int i = 1; i <= nums.Length; i++)
            {
                if (!isCurrent[i])
                {
                    missingNumbers.Add(i);
                }
            }

                return missingNumbers;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                // Two pointers approach
                int left = 0;                   // Pointer for even numbers
                int right = nums.Length - 1;    // Pointer for odd numbers

                while (left < right)
                {
                    // If the left number is even, just move the left pointer
                    if (nums[left] % 2 == 0)
                    {
                        left++;
                    }
                    // If the right number is odd, just move the right pointer
                    else if (nums[right] % 2 == 1)
                    {
                        right--;
                    }
                    // Otherwise, swap the left odd number with the right even number
                    else
                    {
                        int temp = nums[left];
                        nums[left] = nums[right];
                        nums[right] = temp;
                        left++;
                        right--;
                    }
                }

                return nums;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                // Create a dictionary to store number and its index
                Dictionary<int, int> numDict = new Dictionary<int, int>();

                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i]; // Calculate the complement

                    // Check if the complement exists in the dictionary
                    if (numDict.ContainsKey(complement))
                    {
                        return new int[] { numDict[complement], i }; // Return indices
                    }

                    // Add the current number and its index to the dictionary
                    if (!numDict.ContainsKey(nums[i])) // Avoid overwriting
                    {
                        numDict[nums[i]] = i;
                    }
                }

                // Return an empty array if no solution is found (though per problem statement there should be one)
                return new int[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                // Initialize the variables to track the largest and smallest numbers
                int[] max = { int.MinValue, int.MinValue, int.MinValue }; // For the largest three
                int[] min = { int.MaxValue, int.MaxValue };             // For the smallest two

                // Traverse the array to find the required values
                foreach (int num in nums)
                {
                    // Update the largest three
                    if (num > max[0])
                    {
                        max[2] = max[1];
                        max[1] = max[0];
                        max[0] = num;
                    }
                    else if (num > max[1])
                    {
                        max[2] = max[1];
                        max[1] = num;
                    }
                    else if (num > max[2])
                    {
                        max[2] = num;
                    }

                    // Update the smallest two
                    if (num < min[0])
                    {
                        min[1] = min[0];
                        min[0] = num;
                    }
                    else if (num < min[1])
                    {
                        min[1] = num;
                    }
                }

                // Calculate the maximum product of three numbers
                int product1 = max[0] * max[1] * max[2]; // Product of the three largest numbers
                int product2 = min[0] * min[1] * max[0];  // Product of the two smallest and the largest

                return Math.Max(product1, product2); // Return the maximum of the two products
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                if (decimalNumber == 0) return "0"; // Handle the edge case for 0

                string res = string.Empty;

                // Use bit manipulation to convert to binary
                while (decimalNumber > 0)
                {
                    int remainder = decimalNumber % 2; // Get the remainder (0 or 1)
                    res = remainder + res; // Prepend the remainder to the binary string
                    decimalNumber /= 2; // Divide the number by 2
                }

                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                // Handle edge case for empty array
                if (nums.Length == 0)
                {
                    throw new ArgumentException("Array cannot be empty.");
                }

                // Initialize min with the first element
                int min = nums[0];

                // Iterate through the array to find the minimum
                for (int i = 1; i < nums.Length; i++)
                {
                    if (nums[i] < min)
                    {
                        min = nums[i];
                    }
                }

                return min;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Negative numbers and numbers ending with 0 (except 0 itself) are not palindromes
                if (x < 0 || (x % 10 == 0 && x != 0))
                    return false;

                int revHalf = 0;

                // Reverse the last half of the number
                while (x > revHalf)
                {
                    int digit = x % 10; // Get the last digit
                    revHalf = revHalf * 10 + digit; // Build the reversed half
                    x /= 10; // Remove the last digit from x
                }

                // Compare the two halves
                // For even-length numbers, x should be equal to reversedHalf
                // For odd-length numbers, x should be equal to reversedHalf / 10 (to remove the middle digit)
                return x == revHalf || x == revHalf / 10;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                // Handle base cases
                if (n == 0) return 0;
                if (n == 1) return 1;

                
                int a = 0; 
                int b = 1; 
                int next = 0; 

                // Calculate Fibonacci iteratively
                for (int i = 2; i <= n; i++)
                {
                    next = a + b; 
                    a = b; 
                    b = next; 
                }

                return next; // Return F(n)
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
