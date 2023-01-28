namespace ShitarusPrivate.Kavod.Vba.Compression
{
    internal interface IChunkData
    {
        int Size { get; }

        byte[] SerializeData();
    }
}
