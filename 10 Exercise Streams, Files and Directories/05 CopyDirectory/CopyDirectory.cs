namespace CopyDirectory
{
    using System;
    using System.IO;

    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath =  @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath);
            }
            Directory.CreateDirectory(outputPath);

            string[] files= Directory.GetFiles(inputPath);
            foreach (var item in files)
            {
                string nameFile = Path.GetFileName(item);
                string path = Path.Combine(outputPath, nameFile);
                File.Copy(item,path);
            }
            
        }
    }
}
