using System;
using System.Linq;
using System.Collections.Generic;
using RunesDataBase.TableObjects;
using RunesDataBase.SubScript;
using Runes.Net.Shared;
public class Main
{
    public static void Run(RunesDataBase.SubScript.RunesDataBase db)
    {
        /*
        // Don`t forget to remember that object was modified if you had actualy modified it:
         
        var obj = db.GetObjectByGuid(200927);
        // ... object modification ...
        obj.RememberModified();
         
        */

        {
            db.UI_ShowObjectList(db.Armor.Where(at => at.Type == ArmorType.Cloth && at.Limits.MinLevel >= 55 && at.Limits.MinLevel <= 60).OrderByDescending(x => x.ActualDefenceMag), x => x.GetDescription() + "; mdef:" + x.ActualDefenceMag);
        }

        {
            var list = db.Armor.Where(item =>
                item.Limits.MinLevel <= 60 &&
                item.Pos == ArmorPos.Necklace
                )
                .OrderByDescending(x => x.Limits.MinLevel)
                .ThenByDescending(x => x.Rarity);
            db.UI_ShowObjectList(list, o => string.Format("level: {0}", o.Limits.MinLevel));
        }

        /* Show daggers below 70 level in descending order by their DPS */
        {
            // SCRIPT BEGIN
            var list = db.Weapons.Where(item =>
                item.Limits.MinLevel <= 70 &&
                item.Type == WeaponType.Dagger &&
                item.ActualDPS > 0
                ).ToList();
            list.Sort((a, b) => a.ActualDPS > b.ActualDPS ? -1 : (a.ActualDPS < b.ActualDPS ? 1 : 0));
            db.UI_ShowObjectList(list, o => string.Format("level: {1}; dps: {0:F2}", o.ActualDPS, o.Limits.MinLevel));
            // SCRIPT END
        }

        /* Show ranged weapons below 70 level in descending order by their DPS */
        {
            // SCRIPT BEGIN
            var list = db.Weapons.Where(item =>
                item.Limits.MinLevel <= 70 &&
                (item.Type == WeaponType.Bow || item.Type == WeaponType.CrossBow) &&
                item.ActualDPS > 0
                ).ToList();
            list.Sort((a, b) => a.ActualDPS > b.ActualDPS ? -1 : (a.ActualDPS < b.ActualDPS ? 1 : 0));
            db.UI_ShowObjectList(list, o => string.Format("level: {1}; dps: {0:F2}", o.ActualDPS, o.Limits.MinLevel));
            // SCRIPT END
        }
        /* Show 2h axes for 90 level in descending order by their DPS */
        {
            // SCRIPT BEGIN
            var list = db.Weapons.Where(item =>
                item.Limits.MinLevel == 90 &&
                (item.Type == WeaponType.TwoHandedAxe) &&
                item.ActualDPS > 0
                ).ToList();
            list.Sort((a, b) => a.ActualDPS > b.ActualDPS ? -1 : (a.ActualDPS < b.ActualDPS ? 1 : 0));
            db.UI_ShowObjectList(list, o => string.Format("level: {1}; dps: {0:F2}", o.ActualDPS, o.Limits.MinLevel));
            // SCRIPT END
        }

        /* Show all Int-MAttk stats sorted descending */
        {
            // SCRIPT BEGIN
            var list = db.Stats.Where(stat =>
                stat.Stats.Any(e => e.Type == WearEquipmentType.Dexterity) &&
                stat.Stats.Any(e => e.Type == WearEquipmentType.PhysAttack)
                ).OrderByDescending(x => x.Stats.First().Value);
            db.UI_ShowObjectList(list, o => string.Join("; ", o.Stats.Where(e => !e.IsEmpty)) + "; " + ((double)o.Stats[0].Value / o.Stats[1].Value).ToString("P"));
            // SCRIPT END
        }

        /* Show all Dex-PAttk stats sorted descending */
        {
            // SCRIPT BEGIN
            var list = db.Stats.Where(stat =>
                stat.Stats.Any(e => e.Type == WearEquipmentType.Dexterity) &&
                stat.Stats.Any(e => e.Type == WearEquipmentType.PhysAttack)
                ).ToList();
            list.Sort((a, b) => a.Stats[0].Value > b.Stats[0].Value ? -1 : (a.Stats[0].Value < b.Stats[0].Value ? 1 : 0));
            db.UI_ShowObjectList(list, o => string.Join("; ", o.Stats.Where(e => !e.IsEmpty)));
            // SCRIPT END
        }

        /* Show all items with a specified stat (200927) */
        {
            // SCRIPT BEGIN
            const uint statGUID = 514335;
            var list = db.Equipment
                .Where(item => item.CanHaveStat(statGUID))
                .ToList();
            db.UI_ShowObjectList(list, o => o.GetDescription());
            // SCRIPT END
        }
        /* Show all items with a specified stat (200927) */
        {
            // SCRIPT BEGIN
            const uint guid = 620178;
            var list = db.Spells.Where(spell =>
                spell.Magic.Any(m =>
                    m.Arg0 == guid || m.Arg1 == guid
                    )
                ).ToList();
            var list2 = new List<MagicObject>();
            foreach (var magic in list.Select(spell => 
                spell.Magic.Where(
                m => m.Arg0 == guid || m.Arg1 == guid)
                .Select(m =>
                    (MagicObject)db.GetObjectByGuid((uint)m.MagicBaseID))))
            {
                list2.AddRange(magic);
            }
            db.UI_ShowObjectList(list2, o => o.GetDescription());
            // SCRIPT END
        }
    }

    
}
