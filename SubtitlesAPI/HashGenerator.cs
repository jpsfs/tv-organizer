using System.Text;
using System.IO;
using System.Security.Cryptography;
using System;

namespace tv_organizer.SubtitlesAPI
{
    /// <summary>
    /// HashGenerator Class implements the method to generate the hash to use wit SubtitlesAPI
    /// </summary>
    public class HashGenerator
    {
        /// <summary>
        /// HashBytes indicates the number of bytes to read at the begin and end of the file
        /// Default = 64 * 1024 (64KB)
        /// </summary>
        public static int HashBytes = 64 * 1024;
 
        /// <summary>
        /// Function to the hash of the last "hashBytes" of the file.
        /// </summary>
        /// <param name="path">Path of the file</param>
        /// <returns>The calculated hash, using md5</returns>
        public static string Get(string path){
            byte[] data = new byte[HashGenerator.HashBytes << 1];
            
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                //Read the first part
                fileStream.Read(data, 0, HashGenerator.HashBytes);

                //Read the last part
                fileStream.Position = fileStream.Length - HashBytes;
                fileStream.Read(data, HashGenerator.HashBytes, HashBytes);
            }

            return HashGenerator.ComputeHash(data).ToLowerInvariant();
        }

        private static string ComputeHash(byte[] data){
            HashAlgorithm algorithm = MD5.Create();
            byte[] nData = algorithm.ComputeHash(data);

            return BitConverter.ToString(nData).Replace("-", string.Empty);
        }
    }
}
