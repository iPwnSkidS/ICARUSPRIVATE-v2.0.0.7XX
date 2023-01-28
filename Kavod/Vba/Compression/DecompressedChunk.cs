using System;
using System.Collections.Generic;
using System.IO;

namespace ShitarusPrivate.Kavod.Vba.Compression
{
    internal class DecompressedChunk
    {
        internal byte[] Data { get; }

        internal DecompressedChunk(CompressedChunk compressedChunk)
        {
            if (compressedChunk.Header.IsCompressed)
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(new MemoryStream()))
                {
                    IEnumerable<TokenSequence> tokenSequences = ((CompressedChunkData)compressedChunk.ChunkData).TokenSequences;
                    foreach (TokenSequence item in tokenSequences)
                    {
                        item.Tokens.DecompressTokenSequence(binaryWriter);
                    }
                    MemoryStream memoryStream = (MemoryStream)binaryWriter.BaseStream;
                    byte[] array = memoryStream.GetBuffer();
                    Array.Resize(ref array, (int)memoryStream.Length);
                    Data = array;
                    return;
                }
            }
            Data = compressedChunk.ChunkData.SerializeData();
        }

        internal DecompressedChunk(BinaryReader reader)
        {
            long num = reader.BaseStream.Length - reader.BaseStream.Position;
            if (num > 4096L)
            {
                num = 4096L;
            }
            Data = reader.ReadBytes((int)num);
        }
    }
}
