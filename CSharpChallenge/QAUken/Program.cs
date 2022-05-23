using System;
using System.IO;
using System.Collections.Generic;

namespace QAUken
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("1.txt");
            Test("2.txt");
            Test("3.txt");
            Test("4.txt");
            Test("5.txt");
        }
        //To Add - make this take a string that can be added on to the relative path of the text so that I can just call all the tests.
        public static void Test(string fileName)
        {
            //To Add: Make this relative
            string path = Path.Combine(Environment.CurrentDirectory, @"src\", fileName);
            if (!File.Exists(path))
            {
                Console.WriteLine("NOTHING EXISTS O-O. (Unable to load file)");
            }

            Dictionary<int, int> dict = new Dictionary<int, int>();
            
            // Open the file to read from.
            using StreamReader sr = File.OpenText(path);
            string s;
            
            //Read the value, check to make sure the conversion works correctly
            while ((s = sr.ReadLine()) != null)
            {
                int myVal = -1;
                try
                {
                   myVal = Convert.ToInt32(s);
                }
                catch
                {
                    Console.WriteLine("Conversion Error - Investigate Line 35");
                }
                //Check if key exists and increase the value if so, otherwise add a new key.
                if (dict.ContainsKey(myVal))
                {
                    int value = dict[myVal];
                    value++;
                    dict[myVal] = value;
                }
                else
                {
                    dict.Add(myVal, 1);
                }

            }
            //Create a dictionary key and value that is maximum so that it can compare to something
            int smallestKey = int.MaxValue;
            dict[int.MaxValue] = smallestKey;

            //Check if the value is larger than the current 'smallest', whilst also checking if value is equal.
            foreach (int q in dict.Keys)
            {
                if (dict[q] <= dict[smallestKey])
                {
                    if (dict[q] < dict[smallestKey] || q < smallestKey)
                    {
                        smallestKey = q;
                    }
                }
            }

            Console.WriteLine("File: "+ fileName + ", Number: " + smallestKey + ", Repeated: " + dict[smallestKey] + " times.");
        }
    }
    
}
