using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunesDataBase.Sql
{
    public class ShopRecord
    {
        public int GUID { get; set; }
        public int SortNumber { get; set; }
        public int NeedMemberID { get; set; }
        public int SellType { get; set; }
        public int SellType1 { get; set; }
        public int SellType2 { get; set; }
        public DateTime Sell_BeginTime { get; set; }
        public DateTime Sell_EndTime { get; set; }
        public int Sell_Count { get; set; }
        public int Sell_MaxCount { get; set; }
        public int Sell_Cost { get; set; }
        public int Sell_Cost_Bonus { get; set; }
        public int Sell_Cost_Free { get; set; }
        public int Sell_Get_Bonus { get; set; }
        public int Icon { get; set; }
        public int Item_DisplayerObjID { get; set; }
        public string Item_Name { get; set; }
        public string Item_Note { get; set; }
        public int Item_OrgObjID1 { get; set; }
        public int Item_OrgObjID2 { get; set; }
        public int Item_OrgObjID3 { get; set; }
        public int Item_OrgObjID4 { get; set; }
        public int Item_OrgObjID5 { get; set; }
        public int Item_OrgObjID6 { get; set; }
        public int Item_OrgObjID7 { get; set; }
        public int Item_OrgObjID8 { get; set; }
        public int Item_Count1 { get; set; }
        public int Item_Count2 { get; set; }
        public int Item_Count3 { get; set; }
        public int Item_Count4 { get; set; }
        public int Item_Count5 { get; set; }
        public int Item_Count6 { get; set; }
        public int Item_Count7 { get; set; }
        public int Item_Count8 { get; set; }
        public short Gamble_Count { get; set; }
        public short Gamble_Rate1 { get; set; }
        public short Gamble_Rate2 { get; set; }
        public short Gamble_Rate3 { get; set; }
        public short Gamble_Rate4 { get; set; }
        public short Gamble_Rate5 { get; set; }
        public short Gamble_Rate6 { get; set; }
        public short Gamble_Rate7 { get; set; }
        public short Gamble_Rate8 { get; set; }
        public int EffectDay { get; set; }
    }
}
