using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ShitarusPrivate.Kavod.Vba.Compression
{
    internal static class Tokenizer
    {
        private class Node : IEnumerable<CopyToken>, IEnumerable
        {
            internal CopyToken Value { get; }

            internal Node NextNode { get; set; }

            internal long Length
            {
                get
                {
                    if (NextNode != null)
                    {
                        return Value.Length + NextNode.Length;
                    }
                    return Value.Length;
                }
            }

            public Node(CopyToken value, Node nextNode)
            {
                Value = value;
                NextNode = nextNode;
            }

            public IEnumerator<CopyToken> GetEnumerator()
            {
                return new NodeEnumerator(this);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        private class NodeEnumerator : IEnumerator<CopyToken>, IEnumerator, IDisposable
        {
            private Node _currentNode;

            private Node _nextNode;

            public CopyToken Current => _currentNode.Value;

            object IEnumerator.Current => Current;

            public NodeEnumerator(Node node)
            {
                _nextNode = node;
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (_nextNode == null)
                {
                    return false;
                }
                _currentNode = _nextNode;
                _nextNode = _nextNode.NextNode;
                return true;
            }

            public void Reset()
            {
                throw new NotSupportedException();
            }
        }

        internal static IEnumerable<TokenSequence> ToTokenSequences(this IEnumerable<IToken> tokens)
        {
            List<IToken> list = new List<IToken>();
            foreach (IToken token in tokens)
            {
                if (list.Count == 8)
                {
                    yield return new TokenSequence(list);
                    list.Clear();
                }
                list.Add(token);
            }
            if (list.Count != 0)
            {
                yield return new TokenSequence(list);
            }
        }

        internal static void DecompressTokenSequence(this IEnumerable<IToken> tokens, BinaryWriter writer)
        {
            foreach (IToken token in tokens)
            {
                token.DecompressToken(writer);
            }
        }

        internal static bool OverlapsWith(this CopyToken thisToken, CopyToken otherToken)
        {
            CopyToken copyToken = thisToken;
            CopyToken copyToken2 = otherToken;
            if (thisToken.Position > otherToken.Position)
            {
                copyToken = otherToken;
                copyToken2 = thisToken;
            }
            return copyToken.Position + copyToken.Length > copyToken2.Position;
        }

        internal static bool Contains(this CopyToken thisToken, CopyToken otherToken)
        {
            bool flag = thisToken.Position <= otherToken.Position;
            bool flag2 = thisToken.Position + thisToken.Length >= otherToken.Position + otherToken.Length;
            return flag && flag2;
        }

        internal static IEnumerable<IToken> TokenizeUncompressedData(byte[] uncompressedData)
        {
            IEnumerable<CopyToken> specificationCopyTokens = GetSpecificationCopyTokens(uncompressedData);
            IEnumerable<IToken> enumerable = WeaveTokens(specificationCopyTokens, uncompressedData);
            foreach (IToken item in enumerable)
            {
                yield return item;
            }
        }

        private static IEnumerable<CopyToken> GetSpecificationCopyTokens(byte[] uncompressedData)
        {
            long num = 0L;
            while (num < uncompressedData.Length)
            {
                ushort matchedOffset = 0;
                ushort matchedLength = 0;
                Match(uncompressedData, num, out matchedOffset, out matchedLength);
                if (matchedLength <= 0)
                {
                    num++;
                    continue;
                }
                yield return new CopyToken(num, matchedOffset, matchedLength);
                num += matchedLength;
            }
        }

        private static IEnumerable<CopyToken> AllPossibleCopyTokens(byte[] uncompressedData)
        {
            for (long num = 0L; num < uncompressedData.Length; num++)
            {
                ushort matchedOffset = 0;
                ushort matchedLength = 0;
                Match(uncompressedData, num, out matchedOffset, out matchedLength);
                if (matchedLength > 0)
                {
                    yield return new CopyToken(num, matchedOffset, matchedLength);
                }
            }
        }

        private static IEnumerable<CopyToken> NormalizeCopyTokens(IEnumerable<CopyToken> copyTokens)
        {
            List<CopyToken> tokens = RemoveRedundantTokens(copyTokens).ToList();
            return RemoveOverlappingTokens(tokens).ToList();
        }

        private static IEnumerable<CopyToken> RemoveRedundantTokens(IEnumerable<CopyToken> tokens)
        {
            CopyToken copyToken = null;
            foreach (CopyToken token in tokens)
            {
                if (copyToken == null)
                {
                    copyToken = token;
                }
                else if (copyToken.OverlapsWith(token))
                {
                    if (copyToken.Length >= token.Length)
                    {
                        yield return copyToken;
                    }
                    else
                    {
                        yield return token;
                    }
                }
                else
                {
                    yield return copyToken;
                    copyToken = token;
                }
            }
        }

        private static IEnumerable<CopyToken> RemoveOverlappingTokens(IEnumerable<CopyToken> tokens)
        {
            Node node = null;
            foreach (CopyToken item in tokens.Reverse())
            {
                node = new Node(item, node);
            }
            return FindBestPath(node);
        }

        private static Node FindBestPath(Node node)
        {
            Node node2 = null;
            foreach (Node overlappingNode in GetOverlappingNodes(node))
            {
                Node node3 = new Node(overlappingNode.Value, null);
                Node nextNonOverlappingNode = GetNextNonOverlappingNode(overlappingNode);
                if (nextNonOverlappingNode != null)
                {
                    node3.NextNode = FindBestPath(nextNonOverlappingNode);
                }
                if (node2 == null || node2.Length < node3.Length)
                {
                    node2 = node3;
                }
            }
            return node2;
        }

        private static IEnumerable<Node> GetOverlappingNodes(Node node)
        {
            Node node2 = node;
            while (node != null && node2.Value.OverlapsWith(node.Value))
            {
                yield return node;
                node = node.NextNode;
            }
        }

        private static Node GetNextNonOverlappingNode(Node node)
        {
            Node node2 = node;
            while (node != null && node2.Value.OverlapsWith(node.Value))
            {
                node = node.NextNode;
            }
            return node;
        }

        private static IEnumerable<IToken> WeaveTokens(IEnumerable<CopyToken> copyTokens, byte[] uncompressedData)
        {
            long num = 0L;
            foreach (CopyToken copyToken in copyTokens)
            {
                for (; num < copyToken.Position; num++)
                {
                    yield return new LiteralToken(uncompressedData[num]);
                }
                yield return copyToken;
                num += copyToken.Length;
            }
            for (; num < uncompressedData.Length; num++)
            {
                yield return new LiteralToken(uncompressedData[num]);
            }
        }

        internal static void Match(byte[] uncompressedData, long position, out ushort matchedOffset, out ushort matchedLength)
        {
            int num = uncompressedData.Length;
            long num2 = position - 1L;
            long num3 = 0L;
            long num4 = 0L;
            while (num2 >= 0L)
            {
                long num5 = num2;
                long num6 = position;
                int num7 = 0;
                for (; num6 < num && uncompressedData[num6] == uncompressedData[num5]; num6++)
                {
                    num7++;
                    num5++;
                }
                if (num7 > num3)
                {
                    num3 = num7;
                    num4 = num2;
                }
                num2--;
            }
            if (num3 >= 3L)
            {
                CopyToken.CopyTokenHelpResult copyTokenHelpResult = CopyToken.CopyTokenHelp(position);
                matchedLength = (ushort)num3;
                if (num3 > copyTokenHelpResult.MaximumLength)
                {
                    matchedLength = copyTokenHelpResult.MaximumLength;
                }
                matchedOffset = (ushort)(position - num4);
            }
            else
            {
                matchedLength = 0;
                matchedOffset = 0;
            }
        }
    }
}
