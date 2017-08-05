using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace Distroir.CustomSDKLauncher.Core
{
    public class Compressor
    {
        public static void GZipCompress(string inputFileName, string outputFileName)
        {
            using (FileStream input = File.OpenRead(inputFileName))
            using (FileStream output = File.Create(outputFileName))
            using (GZipStream compressor = new GZipStream(output, CompressionMode.Compress))
            {
                input.CopyTo(compressor);
            }
        }

        /// <summary>
        /// Compresses stream with GZip
        /// </summary>
        /// <param name="input">Stream to compress</param>
        /// <returns>Compressed stream</returns>
        public static void GZipCompress(Stream input, Stream output)
        {
            using (GZipStream compressor = new GZipStream(output, CompressionMode.Compress))
            {
                input.CopyTo(compressor);
            }
        }

        public static void GZipDecompress(string inputFileName, string outputFileName)
        {
            using (FileStream input = File.OpenRead(inputFileName))
            using (FileStream output = File.Create(outputFileName))
            using (GZipStream decompressor = new GZipStream(input, CompressionMode.Decompress))
            {
                decompressor.CopyTo(output);
            }
        }

        /// <summary>
        /// Decompresses stream with GZip
        /// </summary>
        /// <param name="input">Stream to decompress</param>
        /// <returns>Decompressed stream</returns>
        public static void GZipDecompress(Stream input, Stream output)
        {
            using (GZipStream compressor = new GZipStream(output, CompressionMode.Decompress))
            {
                input.CopyTo(compressor);
            }
        }
    }
}
