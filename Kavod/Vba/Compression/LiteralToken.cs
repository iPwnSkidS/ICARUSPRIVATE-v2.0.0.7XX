using System;
using System.IO;
using System.Linq;

namespace ShitarusPrivate.Kavod.Vba.Compression
{
    internal class LiteralToken : IEquatable<IToken>, IEquatable<LiteralToken>, IToken
    {
        private readonly byte[] _data;

        public long Length => 1L;

        internal LiteralToken(BinaryReader dataReader)
        {
            _data = dataReader.ReadBytes(1);
        }

        internal LiteralToken(byte data)
        {
            _data = new byte[1] { data };
        }

        public void DecompressToken(BinaryWriter writer)
        {
            writer.Write(_data);
            writer.Flush();
        }

        public byte[] SerializeData()
        {
            return _data;
        }

        public static bool operator !=(LiteralToken first, LiteralToken second)
        {
            return !(first == second);
        }

        public static bool operator ==(LiteralToken first, LiteralToken second)
        {
            return object.Equals(first, second);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as LiteralToken);
        }

        public bool Equals(IToken other)
        {
            return Equals(other as LiteralToken);
        }

        public bool Equals(LiteralToken other)
        {
            return other?._data.SequenceEqual(_data) ?? false;
        }

        public override int GetHashCode()
        {
            return _data.GetHashCode();
        }
    }
}
