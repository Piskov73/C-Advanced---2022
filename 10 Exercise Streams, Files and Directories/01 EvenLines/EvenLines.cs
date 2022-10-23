namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            var text = new StreamReader(inputFilePath);
            StringBuilder st = new StringBuilder();
            int count = 0;
            using (text)
            {
                string line = text.ReadLine();
                while (line!=null)
                {
                    if (count % 2 == 0)
                    {

                        string replace = ReplaceString(line);
                        string revers = ReversString(replace);
                        st.AppendLine(revers);
                    }
                    count++;

                    line = text.ReadLine();
                }
            }
            return st.ToString().TrimEnd();
        }

       
        private static string ReplaceString(string line)
        {
            string[] simbols ={"-",",",".","!","?"};
            foreach (var simbol in simbols)
            {
                line = line.Replace(simbol, "@");
            }
            return line;
        }
        private static string ReversString(string replace)
        {
            string[] revers = replace.Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();

            return string.Join(' ', revers);
        }

    }
}
