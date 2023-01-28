using System.Collections.Generic;
using System.IO;

namespace ShitarusPrivate.Kavod.Vba.Compression
{
    internal class DecompressedBuffer
    {
        internal List<DecompressedChunk> DecompressedChunks { get; }

        internal byte[] Data
        {
            get
            {
                using BinaryWriter binaryWriter = new BinaryWriter(new MemoryStream());
                foreach (DecompressedChunk decompressedChunk in DecompressedChunks)
                {
                    binaryWriter.Write(decompressedChunk.Data);
                }
                using BinaryReader binaryReader = new BinaryReader(binaryWriter.BaseStream);
                binaryReader.BaseStream.Position = 0L;
                return binaryReader.ReadBytes((int)binaryReader.BaseStream.Length);
            }
        }

        internal DecompressedBuffer(byte[] uncompressedData)
        {
            DecompressedChunks = new List<DecompressedChunk>();
            using BinaryReader binaryReader = new BinaryReader(new MemoryStream(uncompressedData));
            while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
            {
                DecompressedChunk item = new DecompressedChunk(binaryReader);
                DecompressedChunks.Add(item);
            }
        }

        internal DecompressedBuffer(CompressedContainer container)
        {
            DecompressedChunks = new List<DecompressedChunk>();
            foreach (CompressedChunk compressedChunk in container.CompressedChunks)
            {
                DecompressedChunks.Add(new DecompressedChunk(compressedChunk));
            }
        }
    }
}
