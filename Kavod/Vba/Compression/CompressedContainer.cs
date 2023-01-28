using System;
using System.Collections.Generic;
using System.IO;

namespace ShitarusPrivate.Kavod.Vba.Compression
{
    internal class CompressedContainer
    {
        private const byte SignatureByteSig = 1;

        private readonly List<CompressedChunk> _compressedChunks = new List<CompressedChunk>();

        internal IEnumerable<CompressedChunk> CompressedChunks => _compressedChunks;

        internal CompressedContainer(byte[] compressedData)
        {
            BinaryReader binaryReader = new BinaryReader(new MemoryStream(compressedData));
            if (binaryReader.ReadByte() != 1)
            {
                throw new Exception();
            }
            while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
            {
                _compressedChunks.Add(new CompressedChunk(binaryReader));
            }
        }

        internal CompressedContainer(DecompressedBuffer buffer)
        {
            foreach (DecompressedChunk decompressedChunk in buffer.DecompressedChunks)
            {
                _compressedChunks.Add(new CompressedChunk(decompressedChunk));
            }
        }

        internal byte[] SerializeData()
        {
            using BinaryWriter binaryWriter = new BinaryWriter(new MemoryStream());
            binaryWriter.Write((byte)1);
            foreach (CompressedChunk compressedChunk in CompressedChunks)
            {
                binaryWriter.Write(compressedChunk.SerializeData());
            }
            using BinaryReader binaryReader = new BinaryReader(binaryWriter.BaseStream);
            binaryReader.BaseStream.Position = 0L;
            return binaryReader.ReadBytes((int)binaryReader.BaseStream.Length);
        }
    }
}
