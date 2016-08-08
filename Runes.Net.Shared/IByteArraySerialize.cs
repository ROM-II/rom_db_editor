namespace Runes.Net.Shared
{
    public interface IByteArraySerialize
    {
        byte[] ToBytes();
        void FromBytes(byte[] bts);
    }
}