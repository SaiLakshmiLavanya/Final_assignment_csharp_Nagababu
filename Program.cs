
/*
 Time_Taken:Approximately 12 Hours
 Corner Cases: Verified against all the test cases mentioned in the Word Document
 Descriptive comments:Explained all the logic inside the methods
 Self-Reflection:CI am half-aware of methods hence I had to write long,repetative and 
complicated time due to which I had to compromise on runtime

*/

using System;
using System.Linq;
using System.Collections.Generic;
namespace DIS_Assignmnet1_SPRING_2022
{
    class Program
    {
        //Question 1
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1: Enter the string:");
            string s = Console.ReadLine();
            string final_string = RemoveVowels(s);
            Console.WriteLine("Final string after removing the Vowels: {0}", final_string);
            Console.WriteLine();

            //Question 2
            string[] bulls_string1 = new string[] { "University", "of", "SouthFlorida" };
            string[] bulls_string2 = new string[] { "UniversityofSouthFlorida" };
            bool flag = ArrayStringsAreEqual(bulls_string1, bulls_string2);
            Console.WriteLine("Q2");
            if (flag)
            {
                Console.WriteLine("Yes, Both the array’s represent the same string");
            }
            else
            {
                Console.WriteLine("No, Both the array’s don’t represent the same string ");
            }
            Console.WriteLine();

            //Question 3
            int[] bull_bucks = new int[] { 1, 2, 3, 4, 5 };
            int unique_sum = SumOfUnique(bull_bucks);
            Console.WriteLine("Q3:");
            Console.WriteLine("Sum of Unique Elements in the array are :{0}", unique_sum);
            Console.WriteLine();

            //Question 4:
            int[,] bulls_grid = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Console.WriteLine("Q4:");
            int diagSum = DiagonalSum(bulls_grid);
            Console.WriteLine("The sum of diagonal elements in the bulls grid is {0}:", diagSum);
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Q5:");
            String bulls_string = "USF";
            int[] indices = { 1, 0, 2 };
            String rotated_string = RestoreString(bulls_string, indices);
            Console.WriteLine("The  Final string after rotation is :{0}", rotated_string);
            Console.WriteLine();

            //Question 6:
            string bulls_string6 = "zimmermanschoolofadvertising";
            char ch = 'x';
            string reversed_string = ReversePrefix(bulls_string6, ch);
            Console.WriteLine("Q6:");
            Console.WriteLine("Resultant string are reversing the prefix:{0}", reversed_string);
            Console.WriteLine();

        }

        //Question 1

        private static string RemoveVowels(string s)
        {
            try
            {
                if (s.Length < 10000)
                {

                    //initialises the final_string to an empty string
                    String final_string = "";
                    //for loop is used to iterate across the string
                    for (int i = 0; i < s.Length; i++)
                    {
                        /*The if-else block  will add the character in the string s to final_string in case it is not equal to a vowel otherwise it moves on 
                            and checks if the next character in string is vowel or not*/
                        if (s[i] != 'a' & s[i] != 'e' & s[i] != 'o' & s[i] != 'i' & s[i] != 'u' & s[i] != 'A' & s[i] != 'E' & s[i] != 'O' & s[i] != 'I' & s[i] != 'U')
                        {
                            final_string = final_string + s[i].ToString();
                        }
                        else
                        {
                            continue;
                        }
                    }

                    return final_string;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("The string length must be below 10000");
                throw;

            }

        }
        //Question 2
        private static bool ArrayStringsAreEqual(string[] bulls_string1, string[] bulls_string2)
        {
            try
            {
                string s1 = "";
                string s2 = "";
                int l1 = bulls_string1.Length;
                int l2 = bulls_string2.Length;
                //The below for loop combines all the string elements in array 1 which is bulls_string1 and combined string is stored in s1
                for (int i = 0; i < l1; i++)
                {
                    s1 = s1 + bulls_string1[i];
                }
                //The below for loop combines all the string elements in array 2 which is bulls_string2 and combined string is stored in s2
                for (int i = 0; i < l2; i++)
                {
                    s2 = s2 + bulls_string2[i];
                }
                // The string.Compare function returns 0 when both the strings are equal and the Convert.ToBoolean converts the value 0 to False
                /*Therefore when two strings are equal below statement becomes if (negation(Convert.ToBoolean(0)) i.e., if true the boolean value true is
                returned to the boolean variable flag in Main method*/
                if (!(Convert.ToBoolean(string.Compare(s1, s2))))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        //Question 3
        private static int SumOfUnique(int[] bull_bucks)
        {
            try
            {
                //converts my array that is passed as an argument to a list
                List<int> bulls = new List<int>(bull_bucks);
                //initialisation of an empty list
                List<int> empty = new List<int>();
                /*puts same elements under the same group using GroupBy clause and counts the number of times the element occured in each group using the
                    .count method and finally converts it into a dictionary with key being the number and value being the number of times element occured*/
                var frequency = bulls.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
                //if count of an element within a list is only 1 i..e, the unique element is added to the empty list empty
                foreach (int key in frequency.Keys)
                {
                    if (frequency[key] == 1)
                    {
                        empty.Add(key);
                    }
                    else
                    {
                        continue;
                    }
                }
                //converts my list named empty to an array
                int[] emptyarray = empty.ToArray();
                int sum = 0;
                //the elements in the array named emptyarray are added and the sum is returned in case the array is not empty else it returns a zero
                if (emptyarray.Length != 0)
                {
                    for (int i = 0; i < emptyarray.Length; i++)
                    {
                        sum = sum + empty[i];
                    }
                    return sum;
                }
                else
                {

                    return 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Question 4
        private static int DiagonalSum(int[,] bulls_grid)
        {
            try
            {

                int sum = 0;
                int l = (bulls_grid.GetLength(0)) - 1;

                for (int i = 0; i <= l; i++)
                {

                    /*This if block will make sure that elements that appear in both primary secondary diagnol
                    of a matrix  do not get added twice while calculating sum*/
                    if (i != (l - i))
                    {
                        sum = sum + bulls_grid[i, (l - i)] + bulls_grid[i, i];
                    }
                    else
                    {
                        sum = sum + bulls_grid[i, i];
                    }


                }

                return sum;
            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }


        }
        //Question 5

        private static string RestoreString(string bulls_string, int[] indices)
        {
            string s = "";
            /* creates a string s where each character in bull_string gets populated in the corresponding
             index that is populated in the indices array*/
            for (int i = 0; i < (bulls_string.Length); i++)
            {
                s = s + bulls_string[Array.IndexOf(indices, i)];

            }
            return s;

        }

        //Question 6
        private static string ReversePrefix(string bulls_string6, char ch)
        {
            try
            {

                if (bulls_string6.Contains(ch))
                {
                    String prefix_string = "";
                    int i;
                    for (i = 0; i < bulls_string6.Length; i++)
                    {
                        if (bulls_string6[i] == ch)
                        {
                            break;
                        }

                    }
                    //The new_string is basically the bulls_string after the part till character ch is removed
                    String new_string = bulls_string6.Remove(0, i + 1);
                    string reversed = "";
                    int j;
                    //This part reverses the part of bulls_string6
                    for (j = i; j >= 0; j--)
                    {
                        reversed = reversed + bulls_string6[j];
                    }
                    /*This part adds the reversed part to the new_string that is obtained
                    after snipping the part of bulls_string till character ch*/
                    prefix_string = new_string.Insert(0, reversed);
                    return prefix_string;
                }
                else
                {
                    return bulls_string6;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }


        }

    }

}
