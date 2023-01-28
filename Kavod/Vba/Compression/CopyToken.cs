using System;
using System.IO;
using System.Text;

namespace ShitarusPrivate.Kavod.Vba.Compression
{
    internal class CopyToken : IEquatable<IToken>, IEquatable<CopyToken>, IToken
    {
        internal struct CopyTokenHelpResult
        {
            internal ushort LengthMask { get; set; }

            internal ushort OffsetMask { get; set; }

            internal ushort BitCount { get; set; }

            internal ushort MaximumLength { get; set; }

            internal ushort LengthBitCount => (ushort)(16 - BitCount);
        }

        private readonly ushort _tokenOffset;

        private readonly ushort _tokenLength;

        public long Length => _tokenLength;

        internal ushort Offset => _tokenOffset;

        internal long Position { get; }

        internal CopyToken(long tokenPosition, ushort tokenOffset, ushort tokenLength)
        {
            Position = tokenPosition;
            _tokenOffset = tokenOffset;
            _tokenLength = tokenLength;
        }

        internal CopyToken(BinaryReader dataReader, long position)
        {
            Position = position;
            UnPack(dataReader.ReadUInt16(), Position, out _tokenOffset, out _tokenLength);
        }

        internal static ushort Pack(long position, ushort offset, ushort length)
        {
            CopyTokenHelpResult copyTokenHelpResult = CopyTokenHelp(position);
            if (length > copyTokenHelpResult.MaximumLength)
            {
                throw new Exception();
            }
            ushort num = (ushort)(offset - 1);
            ushort num2 = (ushort)(16 - copyTokenHelpResult.BitCount);
            ushort num3 = (ushort)(length - 3);
            return (ushort)((num << (int)num2) | num3);
        }

        public void DecompressToken(BinaryWriter writer)
        {
            long position = writer.BaseStream.Position;
            BinaryReader binaryReader = new BinaryReader(writer.BaseStream, Encoding.Unicode, leaveOpen: true);
            binaryReader.BaseStream.Position = position - _tokenOffset;
            byte[] array = binaryReader.ReadBytes(Math.Min(_tokenOffset, _tokenLength));
            Array.Resize(ref array, _tokenLength);
            for (int i = _tokenOffset; i <= _tokenLength - 1; i++)
            {
                byte b = array[i % (int)_tokenOffset];
                array[i] = b;
            }
            writer.BaseStream.Position = position;
            writer.Write(array);
        }

        internal static void UnPack(ushort packedToken, long position, out ushort unpackedOffset, out ushort unpackedLength)
        {
            CopyTokenHelpResult copyTokenHelpResult = CopyTokenHelp(position);
            unpackedLength = (ushort)((packedToken & copyTokenHelpResult.LengthMask) + 3);
            ushort num = (ushort)(packedToken & copyTokenHelpResult.OffsetMask);
            ushort num2 = (ushort)(16 - copyTokenHelpResult.BitCount);
            unpackedOffset = (ushort)((num >> (int)num2) + 1);
        }

        internal static CopyTokenHelpResult CopyTokenHelp(long difference)
        {
            CopyTokenHelpResult result = default(CopyTokenHelpResult);
            result.BitCount = 0;
            while (1 << (int)result.BitCount < difference)
            {
                result.BitCount++;
            }
            if (result.BitCount < 4)
            {
                result.BitCount = 4;
            }
            if (result.BitCount > 12)
            {
                throw new Exception();
            }
            result.LengthMask = (ushort)(65535 >> (int)result.BitCount);
            result.OffsetMask = (ushort)(~result.LengthMask);
            result.MaximumLength = (ushort)((65535 >> (int)result.BitCount) + 3);
            return result;
        }

        public byte[] SerializeData()
        {
            ushort value = Pack(Position, _tokenOffset, _tokenLength);
            return BitConverter.GetBytes(value);
        }

        public static bool operator !=(CopyToken first, CopyToken second)
        {
            return !(first == second);
        }

        public static bool operator ==(CopyToken first, CopyToken second)
        {
            return object.Equals(first, second);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as CopyToken);
        }

        public bool Equals(IToken other)
        {
            return Equals(other as CopyToken);
        }

        public bool Equals(CopyToken other)
        {
            if ((object)other == null)
            {
                return false;
            }
            if (other.Position == Position && other.Length == Length)
            {
                return other.Offset == Offset;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Position.GetHashCode() ^ Length.GetHashCode() ^ Offset.GetHashCode();
        }
    }
}
