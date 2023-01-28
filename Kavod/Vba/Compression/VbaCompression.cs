namespace ShitarusPrivate.Kavod.Vba.Compression
{
    public static class VbaCompression
    {
        public static byte[] Compress(byte[] data)
        {
            DecompressedBuffer buffer = new DecompressedBuffer(data);
            CompressedContainer compressedContainer = new CompressedContainer(buffer);
            return compressedContainer.SerializeData();
        }

        public static byte[] Decompress(byte[] data)
        {
            CompressedContainer container = new CompressedContainer(data);
            DecompressedBuffer decompressedBuffer = new DecompressedBuffer(container);
            return decompressedBuffer.Data;
        }
    }
}
