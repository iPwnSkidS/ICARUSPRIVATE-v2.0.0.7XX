using System;
using System.IO;

namespace ShitarusPrivate.Kavod.Vba.Compression
{
    internal interface IToken : IEquatable<IToken>
    {
        long Length { get; }

        void DecompressToken(BinaryWriter writer);

        byte[] SerializeData();
    }
}
