using System;
using System.IO;
using System.Net.NetworkInformation;
using System.Text;
using System.Collections.Generic;

namespace Day_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> numbers = new Dictionary<string, string>
            {
                { "one", "1" },
                { "two", "2" },
                { "three", "3" },
                { "four", "4" },
                { "five", "5" },
                { "six", "6" },
                { "seven", "7" },
                { "eight", "8" },
                { "nine", "9" }
            };

            string fileName = @"C:\Users\Tim\Advent_of_Code\Advent-Of-Code\Advent_of_Code_2023\Tim\Day_1\Data.txt";


            using (StreamReader reader = new StreamReader(fileName))
            {
                int result = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    #region Part 1
                    char firstnumber = ' ';
                    char lastnumber = ' '; 
                    string allUsedChar ="";                   
                    for (int i = 0; i < line.Length; i++)
                    {
                        allUsedChar += line[i];
                        if (Char.IsDigit(line[i]))
                        {
                            firstnumber = line[i];
                            break;
                        }
                        else if (foundNumberText(allUsedChar, numbers))
                        {
                            firstnumber = getNumberFromText(allUsedChar,numbers);
                            break;
                        }                 
                    }
                    allUsedChar =""; 
                    for (int i = line.Length -1; i >= 0; i--)
                    {
                        allUsedChar = line[i] + allUsedChar;
                        if (Char.IsDigit(line[i]))
                        {
                            lastnumber = line[i];
                            break;
                        }
                        else if (foundNumberText(allUsedChar, numbers))
                        {
                            lastnumber = getNumberFromText(allUsedChar,numbers);
                            break;
                        }
                    }
                    result += Convert.ToInt32(firstnumber+""+lastnumber);
                    Console.WriteLine(firstnumber + " " + lastnumber);
                    #endregion
                }
                Console.WriteLine(result);
            }
        }

        public static bool foundNumberText (string text, Dictionary<string,string> numbers)
        {
            foreach (var item in numbers)
            {
                if (text.Contains(item.Key))
                {
                    return true;
                }
            }
            return false;
        }
        public static char getNumberFromText(string text, Dictionary<string,string> numbers)
        {
            foreach (var item in numbers)
            {
                if (text.Contains(item.Key))
                {
                   return Convert.ToChar(item.Value);
                }
            }
            return ' ';
        }
    }
}
