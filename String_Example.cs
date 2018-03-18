using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    // Written By: Antwoin Davis
    // Title: Playing with Strings
    class String_Example
    {
        static void Main(string[] args)
        {
            // Create String s
            String s = "Hello World...";
            Console.WriteLine(s);
  
            // Append char
            s += "First Manipulation...";
            Console.WriteLine(s);

            s += "Second Manipulation."+ "Test...";
            Console.WriteLine(s);

            // Note that with each appending, string s points to a new array of s strings.
            Console.WriteLine();
            
            //Insert word
            Console.WriteLine("Insert word into string.");
            s=s.Insert((s.IndexOf("...") + 3), "Insert Value...");
            Console.WriteLine(s);
            Console.WriteLine();

            // Find second word in string s
            // First, get the position of where the second word begins
            int startPosition = s.IndexOf(" ") + 1;
            Console.WriteLine("Second word starts at byte position:"+ startPosition);
            
            // Second, use substring to get the next word.
            string word2 = s.Substring(startPosition, s.IndexOf("...", startPosition) - startPosition);
            Console.WriteLine("Second word: " + word2);
            Console.WriteLine();            
           
            // Since each time String s is appended it creates a new value on the stack it is called nonmutable or read-only. 
            // When performing many string appends can theoritically cause you to run out of memory. To many string appends will force the garbage collecter
            // to disposed of "unused" / not currently being referenced values and affect program speed.
            // Note, that the garbage collector does not run to pick up every time a value on the stack is left unused, because it is a relatively time consuming
            // operation.

            // So, the best pratice is to use Stringbuilder for large string appends because it is mutable. You can concatenate, append, or delete substrings from a string
            StringBuilder string1 = new StringBuilder(String.Empty);
            Console.WriteLine("-------------------");

            string1.Append("<Start Of Strings>");
            for (int i = 0; i < 1000; i++)
            {
                // Every 5 characters write 0 else write X 
                if (i % 5 == 0)
                {
                    string1.Append("0");
                }
                else 
                {
                    string1.Append("X");
                }
            }
            string1.Append("<End of Strings>");
            Console.WriteLine(string1);
            Console.WriteLine();

            // Set a variable to the My Documents path.
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(mydocpath + @"\WriteLines.txt"))
            {
                   outputFile.WriteLine(string1);
            }

            Console.ReadLine();
        }
    }
}
