namespace RunesDataBase.Sql
{
    public enum RomDbCategory : int
    {
        Consumables = 1,
        Upgrading,
        Mounts,
        Pets,
        Costumes,
        Housing,
        Crafting,
        Encyclopedias,
        Packages,
        SepcialOffers
    }
    public enum RomDbConsumablesCategory : int
    {
        ExpTp = 1,
        Transportation,
        MustHaves,
        Days30,
        Days180,
        Charms,
        Tickets,
        TransofrmationPotions,
        Fun
    }
    public enum RomDbUpgradingCategory : int
    {
        Weapons = 1,
        Armour,
        Accessories,
        Back,
        Runes,
    }
    public enum RomDbMountsCategory : int
    {
        Day1 = 1,
        Day7,
        Day30,
        Permanent,
    }
}