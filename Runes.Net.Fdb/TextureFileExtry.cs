using System.IO;

namespace Runes.Net.Fdb
{
    public sealed class TextureFileExtry : FileEntry
    {
        public FdbTextureCompressionType TextureCompressionType { get; set; } 
        public int TextureWidth { get; set; }
        public int TextureHeight { get; set; }
        public int MipmapCount { get; set; }
        public override void Read(BinaryReader r)
        {
            base.Read(r);
            TextureCompressionType = (FdbTextureCompressionType) r.ReadInt32();
            TextureWidth = r.ReadInt32();
            TextureHeight = r.ReadInt32();
            MipmapCount = r.ReadInt32();
            FileDataAddress = (uint)r.BaseStream.Position;
            ActualDataSize -= 16;
        }
    }

    public enum FdbTextureCompressionType : int
    {
        None = 0x02,
        DXT1_0x05 = 0x05,
        DXT1_0x06 = 0x06,
        DXT5 = 0x08,
    }
}
