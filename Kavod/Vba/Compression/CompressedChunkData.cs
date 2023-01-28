using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ShitarusPrivate.Kavod.Vba.Compression
{
    internal class CompressedChunkData : IChunkData
    {
        [Serializable]
        [CompilerGenerated]
        private sealed class __c
        {
            public static readonly __c __9 = new __c();

            public static Func<IToken, long> __9__2_0;

            public static Func<TokenSequence, IEnumerable<byte>> __9__5_0;

            public static Func<TokenSequence, byte, byte> __9__5_1;

            internal long __002Ector_b__2_0(IToken t)
            {
                return t.Length;
            }

            internal IEnumerable<byte> _SerializeData_b__5_0(TokenSequence t)
            {
                return t.SerializeData();
            }

            internal byte _SerializeData_b__5_1(TokenSequence t, byte d)
            {
                return d;
            }
        }

        private readonly List<TokenSequence> _tokensequences = new List<TokenSequence>();

        internal IEnumerable<TokenSequence> TokenSequences => _tokensequences;

        public int Size => SerializeData().Length;

        internal CompressedChunkData(DecompressedChunk chunk)
        {
            IEnumerable<IToken> tokens = Tokenizer.TokenizeUncompressedData(chunk.Data);
            _tokensequences.AddRange(tokens.ToTokenSequences());
        }

        internal CompressedChunkData(BinaryReader dataReader, ushort compressedChunkDataSize)
        {
            byte[] buffer = dataReader.ReadBytes(compressedChunkDataSize);
            using BinaryReader binaryReader = new BinaryReader(new MemoryStream(buffer));
            int num = 0;
            while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
            {
                TokenSequence fromCompressedData = TokenSequence.GetFromCompressedData(binaryReader, num);
                _tokensequences.Add(fromCompressedData);
                num += (int)fromCompressedData.Tokens.Sum(__c.__9__2_0 ?? (__c.__9__2_0 = __c.__9.__002Ector_b__2_0));
            }
        }

        public byte[] SerializeData()
        {
            IEnumerable<byte> source = _tokensequences.SelectMany(__c.__9__5_0 ?? (__c.__9__5_0 = __c.__9._SerializeData_b__5_0), __c.__9__5_1 ?? (__c.__9__5_1 = __c.__9._SerializeData_b__5_1));
            return source.ToArray();
        }
    }
}
