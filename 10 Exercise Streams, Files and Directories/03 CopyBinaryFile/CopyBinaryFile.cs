namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            var raider = new FileStream(inputFilePath, FileMode.Open);
            using (raider)
            {
                using (FileStream write=new FileStream(outputFilePath,FileMode.Create))
                {
                    while (true)
                    {

                        byte[] bufer = new byte[512];
                        int bytesRead = raider.Read(bufer, 0, bufer.Length);
                        if (bytesRead == 0)
                        {
                            break;
                        }
                        write.Write(bufer, 0, bytesRead);

                    }
                }
            }
        }
    }
}
