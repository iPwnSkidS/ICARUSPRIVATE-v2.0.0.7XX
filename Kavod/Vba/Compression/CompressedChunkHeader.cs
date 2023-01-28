using System;
using System.IO;

namespace ShitarusPrivate.Kavod.Vba.Compression
{
    internal class CompressedChunkHeader
    {
        internal bool IsCompressed { get; private set; }

        internal ushort CompressedChunkSize { get; private set; }

        internal ushort CompressedChunkDataSize => (ushort)(CompressedChunkSize - 2);

        internal CompressedChunkHeader(IChunkData chunkData)
        {
            IsCompressed = chunkData is CompressedChunkData;
            CompressedChunkSize = (ushort)(chunkData.Size + 2);
        }

        internal CompressedChunkHeader(ushort header)
        {
            DecodeHeader(header);
        }

        internal CompressedChunkHeader(BinaryReader dataReader)
        {
            ushort header = dataReader.ReadUInt16();
            DecodeHeader(header);
        }

        private void DecodeHeader(ushort header)
        {
            switch ((ushort)(header & 0xF000))
            {
                case 45056:
                    IsCompressed = true;
                    break;
                default:
                    throw new Exception();
                case 12288:
                    IsCompressed = false;
                    break;
            }
            CompressedChunkSize = (ushort)((header & 0xFFF) + 3);
            ValidateChunkSizeAndCompressedFlag();
        }

        internal byte[] SerializeData()
        {
            ValidateChunkSizeAndCompressedFlag();
            ushort value = ((!IsCompressed) ? ((ushort)(0x3000u | (uint)(CompressedChunkSize - 3))) : ((ushort)(0xB000u | (uint)(CompressedChunkSize - 3))));
            return BitConverter.GetBytes(value);
        }

        private void ValidateChunkSizeAndCompressedFlag()
        {
            if (IsCompressed && CompressedChunkSize > 4098)
            {
                throw new Exception();
            }
            if (!IsCompressed && CompressedChunkSize != 4098)
            {
                throw new Exception();
            }
        }
    }
}
