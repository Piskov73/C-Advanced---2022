namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
           
           string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            var exstensionFiles=new SortedDictionary<string,List<FileInfo>>();
            string[] files = Directory.GetFiles(inputFolderPath);
            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                if (!exstensionFiles.ContainsKey(fileInfo.Extension))
                {
                    exstensionFiles[fileInfo.Extension] = new List<FileInfo>();
                }
                exstensionFiles[fileInfo.Extension].Add(fileInfo);

            }

            var sortedExtension = exstensionFiles.OrderByDescending(x => x.Value.Count);
            StringBuilder sb = new StringBuilder();

            foreach (var item in sortedExtension)
            {
                sb.AppendLine(item.Key);

                var sortedFiles = item.Value.OrderBy(x => x.Length);
                foreach (var file in sortedFiles)
                {
                    sb.AppendLine($"--{file.Name} - {(double)file.Length/1024:f3}kb");
                }

            }


            return sb.ToString().TrimEnd();

        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+reportFileName;

            File.WriteAllText(path, textContent);

        }
    }
}
