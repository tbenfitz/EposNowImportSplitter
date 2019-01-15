using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EposNowImportSplitter
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "D:\\Users\\tbenf\\Documents\\its-complicated\\Bauers\\ExemptUpdate\\OriginalExport.csv";

            using (TextReader reader = File.OpenText(path))
            {
                int fileCount = 0;
                int lineCount = 0;

                string newFilePath =
                    $"D:\\Users\\tbenf\\Documents\\its-complicated\\Bauers\\ExemptUpdate\\ToImport\\Import_{ fileCount }.csv";

                string headerLine = reader.ReadLine();

                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    using (TextWriter writer = File.CreateText(newFilePath))
                    {                        
                        writer.WriteLine(headerLine);

                        writer.WriteLine(AddTaxExemptFlag(line));
                        Console.WriteLine(AddTaxExemptFlag(line));

                        for (lineCount = 0; lineCount < 3999; lineCount++)
                        {
                            line = reader.ReadLine();

                            if (line != null)
                            {                                
                                writer.WriteLine(AddTaxExemptFlag(line));
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    fileCount++;
                    newFilePath =
                        $"D:\\Users\\tbenf\\Documents\\its-complicated\\Bauers\\ExemptUpdate\\ToImport\\Import_{ fileCount }.csv";
                }                
            }

            Console.Read();
        }

        protected static string[] SplitData(string csvLine)
        {
            string[] variableArray =
                csvLine.Split(',');

            return variableArray;
        }

        protected static string AddTaxExemptFlag(string csvLine)
        {
            string[] variableArray = SplitData(csvLine);

            int length = variableArray.Length;

            Console.WriteLine(variableArray[length - 5]);

            variableArray[length - 5] = "y";

            Console.WriteLine(variableArray[length - 5]);

            return String.Join(",", variableArray);
        }
    }
}
