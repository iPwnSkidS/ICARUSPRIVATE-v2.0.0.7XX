using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ShitarusPrivate.Kavod.Vba.Compression
{
    internal class CompressedChunk
    {
        internal CompressedChunkHeader Header { get; }

        internal IChunkData ChunkData { get; }

        internal CompressedChunk(DecompressedChunk decompressedChunk)
        {
            ChunkData = new CompressedChunkData(decompressedChunk);
            if (ChunkData.Size >= 4096)
            {
                ChunkData = new RawChunk(decompressedChunk.Data);
            }
            Header = new CompressedChunkHeader(ChunkData);
        }

        internal CompressedChunk(BinaryReader dataReader)
        { 
            Header = new CompressedChunkHeader(dataReader);
            if (Header.IsCompressed)
            {
                ChunkData = new CompressedChunkData(dataReader, Header.CompressedChunkDataSize);
            }
            else
            {
                ChunkData = new RawChunk(dataReader.ReadBytes(Header.CompressedChunkDataSize));
            }
        }

        internal byte[] SerializeData()
        {
            byte[] array = Header.SerializeData();
            byte[] array2 = ChunkData.SerializeData();
            IEnumerable<byte> enumerable = array.Concat(array2);
            if (!Header.IsCompressed)
            {
                long num = array.LongLength + array2.LongLength;
                long num2 = 4098L - num;
                IEnumerable<byte> second = Enumerable.Repeat((byte)0, (int)num2);
                enumerable = enumerable.Concat(second);
            }
            return enumerable.ToArray();
        }
    }
}
