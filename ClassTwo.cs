using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace cSharpTest
{
    class ClassTwo
    {
        public void WriteOrRemove()
        {
            Console.WriteLine("Would you like to write or remove a line? (remove/write)");
            string response = Console.ReadLine();
            if (response == "write")
            {
                Write();
            }
            else if (response == "remove")
            {
                Remove();
            }
            else
            {
                Console.WriteLine("Invalid answer");
                WriteOrRemove();
            }
        }

        static string filePath = "C:/Users/Tobias Frederiksen/Desktop/cSharpTest/textFile.txt";
        static List<string> lines = File.ReadAllLines(filePath).ToList();
        void Remove()
        {
            Console.WriteLine("What line do you want to delete?");
            int lineNumber = Convert.ToInt32(Console.ReadLine());
            if (lineNumber < 1 || lines.Count < lineNumber)
            {
                Console.WriteLine("Invalid number");
                Remove();
            }
            else
            {
                lines.Remove(lines[lineNumber - 1]);
                listToFile();
            }
        }
        void Write()
        {
            Console.WriteLine("What do you want the new line to say?");
            string newLine = Console.ReadLine();
            lines.Add(newLine);
            listToFile();
        }
        static void listToFile()
        {
            File.WriteAllLines(filePath, lines);
            Console.WriteLine("The new file:");
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}