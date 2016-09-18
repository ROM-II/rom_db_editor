using System.Drawing;

namespace Runes.Net.Shared
{
    public static class Colors
    {
        public static Color GetColorForWearEffect(WearEquipmentType type, double value, int effectsCount, StatRarity rarity, bool isItemsOwnEffect)
        {
            switch (type)
            {
                case WearEquipmentType.AtkSpeed:                // "攻擊速度(%)"
                case WearEquipmentType.SpellSpeedAllMagic:     // "施法速度 所有(%)"
                case WearEquipmentType.AttackSpeedAllRange:    // "遠程武器速度(%) 所有"
                case WearEquipmentType.AttackSpeedBow:         // "遠程武器速度(%) 弓"
                case WearEquipmentType.AttackSpeedCossbow:     // "遠程武器速度(%) 十字弓"
                case WearEquipmentType.AttackSpeedGun:         // "遠程武器速度(%) 槍" 
                case WearEquipmentType.AttackSpeedAllWeapon:   // "近戰武器速度(%) 所有"
                case WearEquipmentType.AttackSpeedUnarmed:     // "近戰武器速度(%) 空手"
                case WearEquipmentType.AttackSpeedBlade:       // "近戰武器速度(%) 劍"
                case WearEquipmentType.AttackSpeedDagger:      // "近戰武器速度(%) 匕首"
                case WearEquipmentType.AttackSpeedWand:        // "近戰武器速度(%) 權杖"
                case WearEquipmentType.AttackSpeedAxe:         // "近戰武器速度(%) 斧"
                case WearEquipmentType.AttackSpeedBludgeon:    // "近戰武器速度(%) 鎚棍棒"
                case WearEquipmentType.AttackSpeedClaymore:    // "近戰武器速度(%) 雙手劍"
                case WearEquipmentType.AttackSpeedStaff:       // "近戰武器速度(%) 杖"
                case WearEquipmentType.AttackSpeed_2HAxe:      // "近戰武器速度(%) 雙手斧"
                case WearEquipmentType.AttackSpeed_2HHammer:   // "近戰武器速度(%) 雙手鎚"
                case WearEquipmentType.AttackSpeedPolearm:     // "近戰武器速度(%) 槍(長矛)"
                case WearEquipmentType.PlayerDefRate:           // "(守)被玩家(or玩家寵物)攻擊威力加減",
                case WearEquipmentType.NPCDefRate:              // "(守)被NPC攻擊威力加減",
                case WearEquipmentType.AeMagicDefRate:          // "(守)被AC法術攻擊威力加減",
                    value = -value;
                    break;
            }

            if (value < 0)
                return Color.Red;

            if (rarity > 0)
            {
                switch (rarity)
                {
                    case StatRarity.Green:
                        return Color.Lime;
                    case StatRarity.Yellow:
                        return Color.FromArgb(255, 255, 0);
                    case StatRarity.Orange:
                        return Color.FromArgb(240, 97, 13);
                    case StatRarity.Purple4:
                    case StatRarity.Purple5:
                    case StatRarity.Purple6:
                    case StatRarity.Purple7:
                    case StatRarity.Purple8:
                        return Color.FromArgb(239, 20, 224);
                }
            }

            if (!isItemsOwnEffect)
                return Color.Lime;

            switch (effectsCount)
            {
                case 2:
                    return Color.FromArgb(255, 255, 0);
                case 3:
                    return Color.FromArgb(240, 97, 13);
            }
            return Color.Lime;
        }

        public static Color GetColorForStat(int effectsCount, StatRarity rarity)
            => GetColorForWearEffect(WearEquipmentType.AllState, 1, effectsCount, rarity, false);
    }
}
