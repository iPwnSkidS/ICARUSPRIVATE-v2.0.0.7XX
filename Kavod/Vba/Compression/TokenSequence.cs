using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ShitarusPrivate.Kavod.Vba.Compression
{
    internal class TokenSequence
    {
        [Serializable]
        [CompilerGenerated]
        private sealed class __c
        {
            public static readonly __c __9 = new __c();

            public static Func<IToken, long> __9__5_0;

            internal long _get_Length_b__5_0(IToken t)
            {
                return t.Length;
            }
        }

        private byte _flagByte;

        private readonly List<IToken> _tokens = new List<IToken>();

        internal long Length => Tokens.Sum(__c.__9__5_0 ?? (__c.__9__5_0 = __c.__9._get_Length_b__5_0));

        internal IReadOnlyList<IToken> Tokens => _tokens;

        public TokenSequence(IEnumerable<IToken> enumerable)
            : this()
        {
            _tokens.AddRange(enumerable);
            for (int i = 0; i < _tokens.Count; i++)
            {
                if (_tokens[i] is CopyToken)
                {
                    SetIsCopyToken(i, value: true);
                }
            }
        }

        private TokenSequence()
        {
        }

        internal static TokenSequence GetFromCompressedData(BinaryReader reader, long position)
        {
            TokenSequence tokenSequence = new TokenSequence
            {
                _flagByte = reader.ReadByte()
            };
            for (int i = 0; i <= 7; i++)
            {
                if (tokenSequence.GetIsCopyToken(i))
                {
                    CopyToken copyToken = new CopyToken(reader, position);
                    tokenSequence._tokens.Add(copyToken);
                    position += Convert.ToInt64(copyToken.Length);
                }
                else
                {
                    tokenSequence._tokens.Add(new LiteralToken(reader));
                    position++;
                }
            }
            return tokenSequence;
        }

        private void SetIsCopyToken(int index, bool value)
        {
            byte b = (byte)Math.Pow(2.0, index);
            _flagByte |= b;
        }

        private bool GetIsCopyToken(int index)
        {
            byte b = (byte)Math.Pow(2.0, index);
            return (b & _flagByte) != 0;
        }

        internal byte[] SerializeData()
        {
            IEnumerable<byte> enumerable = Enumerable.Repeat(_flagByte, 1);
            foreach (IToken token in Tokens)
            {
                enumerable = enumerable.Concat(token.SerializeData());
            }
            return enumerable.ToArray();
        }
    }
}
