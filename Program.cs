using System;
using System.Collections.Generic;

namespace EX7A_CSV
{
    class Program
    {
        public static List<string> getCSV(string s)
        {
            List<string> temp = new List<string>();
            string substring = "";
            int i = 0;
            
            for (i = 0; i < s.Length; i++)
            {
                if (i < s.Length - 1 || s[s.Length - 1] != '\"')
                {
                    if (s[i] == '\"' && s[i + 1] != ',')
                    {                       
                        if (i == s.Length - 1 || substring != "")
                        {
                            temp.Add(substring);
                        }
                        substring = "";
                    }
                    else if (s[i] == '\"' && s[i + 1] == ',')
                    {
                        temp.Add(substring);
                        substring = "";

                        if (i == s.Length - 1 && substring != "")
                        {
                            temp.Add(substring);
                        }
                        i++;
                    }
                    else if (s[i] == ',' && s[i - (substring.Length + 1)] == '\"')
                    {
                        substring += s[i];
                    }
                    else if (s[i] == ',' && s[i - (substring.Length + 1)] != '\"')
                    {
                        temp.Add(substring);
                        substring = "";
                    }
                    else
                    {
                        substring += s[i];
                        if (i == s.Length - 1 && substring != "")
                        {
                            temp.Add(substring);
                        }
                    }
                }
                else
                {
                    temp.Add(substring);
                    i++;
                }              
            }
            return temp;
        }
        static void Main(string[] args)
        {
            /*************************
            * read CSV with embedded commas
            * parse CSV into separate fields and
            * ignore commas within quoted string
            * ***********************/
            Console.WriteLine("Reading CSV with embedded commas");
            List<string> myList = new List<string>();
            string input1 = "\"a,b\",c";
            myList.Add(input1);
            string input2 = "\"Obama, Barack\",\"August 4, 1961\",\"Washington, D.C.\"";
            myList.Add(input2);
            string input3 = "\"Ft. Benning, Georgia\",32.3632N,84.9493W," +
                "\"Ft. Stewart, Georgia\",31.8691N,81.6090W," +
                "\"Ft. Gordon, Georgia\",33.4302N,82.1267W";
            myList.Add(input3);
            foreach (string s in myList)
            {
                Console.WriteLine($"Current input is {s}");
                List<string> output = getCSV(s);
                int len = output.Count;
                Console.WriteLine($"This line has {len} fields. They are:");
                foreach (string s1 in output)
                    Console.WriteLine(s1);
            }
        }
    }
}
