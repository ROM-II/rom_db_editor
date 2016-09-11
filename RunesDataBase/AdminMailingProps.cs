using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Design;
using System.Linq;
using System.Windows.Forms;
using RunesDataBase.Controls;
using RunesDataBase.Forms;
using RunesDataBase.Sql;
using RunesDataBase.Sql.World;
using RunesDataBase.TableObjects;

namespace RunesDataBase
{
    public class AdminMailingProps
    {
        [Category("1. Mail properties"), TypeConverter(typeof (EntitySelectConverter<RoleData>))]
        public RoleData Recipient { get; set; }
        [Category("1. Mail properties")]
        public string Sender { get; set; } = "System";
        [Category("1. Mail properties")]
        public string Title { get; set; } = "Sample text";
        [Category("1. Mail properties")]
        public string Message { get; set; }
        [Category("2. Money contents")]
        public int Gold { get; set; }
        [Category("2. Money contents")]
        public int Dias { get; set; }
        [Category("2. Money contents")]
        public int Rubies { get; set; }

        [Category("3. Item contents")] 
      //[Editor(typeof(AutocompleteEditor<BasicTableObject>), typeof(UITypeEditor))]
        public ItemObject Item { get; set; } = null;

        [Category("3. Item contents"), DisplayName("Items count"), Description("X > 1 will not actually work as intended for equipment and things with max count == 1")]
        public int ItemCount { get; set; } = 0;

        [Category("3. Item contents"), Range(0, 255), 
            DisplayName("Item durability"), Description("Range[0..255]")]
        public byte ItemDura { get; set; } = 0;

        [Category("3. Item contents"), Range(0, 31), 
            DisplayName("Item tier mod"), Description("Range[0..31] Not actualy tier but some modifier for it. 28-31 is often tier 20+")]
        public byte ItemTierModifier { get; set; } = 0;

        [Category("3. Item contents"), Range(0, 20), 
            DisplayName("Item enchanting"), Description("Range[0..20]. Item enchanting ( ITEMNAME +X )")]
        public byte ItemEnchanting { get; set; } = 0;

        [Category("3. Item contents"), Range(0, 4),
            DisplayName("Item rune slots"), Description("Range[0..4]. Item rune slots")]
        public byte ItemRuneSlots { get; set; } = 0;

        [Category("3. Item contents"),
            DisplayName("Item stats"), Description("Repeating stats ARE allowed!")]
        public StatObject[] ItemStats { get; } = new StatObject[6];
        [Category("3. Item contents"),
            DisplayName("Item runes"), Description("Repeating stats ARE allowed!")]
        public RuneObject[] ItemRunes { get; } = new RuneObject[4];

        public bool Send()
        {
            if (Recipient == null)
            {
                MessageBox.Show("Recipient was not specified - Mail was not sent.");
                return false;
            }

            try
            {
                DbRepository.Default.RomImportConnection.RunCommand(
                    "INSERT [dbo].[ImportMail] " +
                    "([WorldID], [ToName], [OrgObjID], [Count], [Durable], [ImageObjectID], [Title], [Content], [Money], [Money_Account], [Money_Bonus], [GmName], [Ability], [ExValue]) " +
                    "VALUES (1, @toName, @itemId, @itemCount, @itemDura, @itemId, @title, @message, @gold, @dias, @rubies, @sender, @ability, @exValue)",
                    new Dictionary<string, object>
                    {
                        {"toName", Recipient.RoleName},
                        {"itemId", (int)(Item?.Guid ?? 0) },
                        {"itemCount", ItemCount },
                        {"itemDura", (int)ItemDura },
                        {"title", Title },
                        {"message", Message },
                        {"gold", Gold },
                        {"dias", Dias },
                        {"rubies", Rubies },
                        {"sender", Sender },
                        {"ability", BuildAbility(ItemStats, ItemRunes) },
                        {"exValue", BuildExValue(ItemDura, ItemEnchanting, ItemTierModifier, ItemRuneSlots) },
                    });
            }
            catch (Exception ex)
            {
                MainForm.Instance.Log.WriteLine($"Exception on {nameof(Send)} - {ex}");
                MessageBox.Show($"Failed to send mail\r\n{ex}", "Error");
                return false;
            }
            return true;
        }

        private static int BuildExValue(byte dura, byte enchantment, byte tier, byte runeSlots)
            => BuildExValue(0, dura, tier, 0, enchantment, runeSlots);
        private static int BuildExValue(byte orgQuality, byte quality, byte powerQuality, byte rare, byte level, byte runeVolume)
        {
            int value = orgQuality;
            value |= quality << 8;
            value |= (powerQuality & ((1 << 5) - 1)) << 16;
            value |= (rare & ((1 << 3) - 1)) << 21;
            value |= (level & ((1 << 5) - 1)) << 24;
            value |= (runeVolume & ((1 << 3) - 1)) << 29;
            return value;
        }

        private static byte[] BuildAbility(StatObject[] itemStats, RuneObject[] runes)
        {
            var b = new List<byte>();
            AbilifyItems(itemStats.Select(x =>
            {
                var guid = x?.Guid ?? 0;
                return guid > 999999 ? 0 : guid;
            }).ToArray(), b);
            AbilifyItems(runes.Select(x =>
            {
                var guid = x?.Guid ?? 0;
                return guid > 999999 ? 0 : guid;
            }).ToArray(), b);//runes
            b.AddRange(Enumerable.Repeat((byte)0, 12));
            return b.ToArray();
        }

        private static void AbilifyItems(IEnumerable<uint> guids, List<byte> b)
        {
            foreach (var guid in guids)
            {
                ushort i = (ushort)(guid - 500000);
                var high = (byte)(i / 256);
                var low = (byte)(i - high * 256);
                b.Add(low);
                b.Add(high);
            }
        }
    }
}
