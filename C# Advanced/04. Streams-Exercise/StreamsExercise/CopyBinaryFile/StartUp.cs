using System;
using System.IO;

namespace CopyBinaryFile
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string binaryFile = @"..\..\..\..\Files\copyMe.png";
            string copiedFile = @"..\..\..\..\Files\newMe.png";

            using (FileStream reader = new FileStream(binaryFile, FileMode.Open))
            {
                using (FileStream writer = new FileStream(copiedFile, FileMode.Create))
                {
                    byte[] buffer = new byte[4096];

                    while (true)
                    {
                        int readBytes = reader.Read(buffer, 0, buffer.Length);
                        
                        if (readBytes == 0)
                        {
                            break;
                        }

                        writer.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
