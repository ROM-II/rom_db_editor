using RunesDataBase.TableObjects;

namespace RunesDataBase.SubScript
{
    public class ResultsItem
    {
        public ResultsItem(bool isOdd, string itemName, uint itemGuid, string additionalInfo, BasicTableObject item)
        {
            IsOdd = isOdd;
            ItemName = itemName;
            ItemGuid = itemGuid;
            AdditionalInfo = additionalInfo;
            Item = item;
        }

        public bool IsOdd { get; }
        public string ItemName { get; }
        public uint ItemGuid { get; }
        public string AdditionalInfo { get; }
        public BasicTableObject Item { get; }
    }
}
