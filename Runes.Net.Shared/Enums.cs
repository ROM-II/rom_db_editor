using System;
using System.ComponentModel;

namespace Runes.Net.Shared
{

    public enum GameObjectClassification
    {
        None = -1,
        Player = 0,
        NPC,     // 1	
        Item,        //Є««~	ёЛіЖ ЄZѕ№ Єчїъ 2
        MagicBase,       // 3 
        BodyObj,     // 4 
        Attribute,       //ґ_Ґ[ДЭ©К	
        QuestCollect,
        QuestDetail,
        Title,       //АY»О
        KeyItem,     //­«­nЄ««~
        Recipe,      //°t¤иЄн
        Mine,        //ДqІЈ
        Flag,        //єX¤lёк®Ж
        Image,       //№П¶Hёк®Ж
        QuestNPC,        //Ґф°И
        LearnMagic,      //ЄkіNѕЗІЯ
        Shop,        //°У©±
        Suit,        //®MёЛ
        LuaScript,       //ј@±Ў
        Camp,        //°}Аз
        Treasure,        //Д_Ѕc
        MagicCollect,        //ЄkіN¶°¦X
        EqRefineAbility,     //ёЛіЖєл·ТЄн
        Zone,        //°П°м
        CreateRole,      //«ШЁ¤Є«Ґу
        PE,      //PEјЛЄO
        Phantom,     //¤ЫЖF

        Max
    }

    public enum Relation
    {
        Self, //¦Ы¤v
        Member, //¶¤¤Н

        SelfPet, //¦Ы¤v(pet)
        MemberPet, //¶¤¤Н(pet)

        Friend, //¤Н¤и,(№пЄ±®a «h¬°©Т¦іЄ±®a   №п¤ЈДЭ©уЄ±®aЄєNPC «h¬°¤ЈДЭ©уЄ±®aЄєNPC)
        FriendNpc, //¤Н¤иЄєГdЄ«(¦pГdЄ«ЎAҐlікҐXЁУЄєЎAДЭ©уётАH¦Ы¤vЄєNPC)

        Enemy, //©Т¦іҐi¬е±юЄє№п¶µ
        Player, //©Т¦іЄ±®a
        All, //©Т¦іЄ«Ґу

        GuildPlayer, //¦P¤Ѕ·|Є±®a
        NotGuildPlayer, //¤Ј¦P¤Ѕ·|Є±®a

        CountryPlayer, //¦P°к®aЄ±®a
        NoCountryPlayer, //¤Ј¦P°к®aЄ±®a

        Corpse, //«НЕй
        NpcCorpse, //NPC«НЕй
        PlayerCorpse, //Є±®a«НЕй
        Locatoin, //«ь©w¦мёm( ЅdітЄkіN )

        PetOwner, //¦Ы¤vЄєҐD¤H
        Wagon, //ёьЁг
    }

    public enum SpellEffectType
    {
        Magic,
        Physic,
        Equipment,
        PetEquipemnt
    }

    [Flags]
    public enum SexFlags    
    {
        Male =1,
        Female=2,
        BigMonster=4,
        King=8,
        WorldKing=16
    };
    public enum Sex
    {
        Male = 0,
        Female,
        BigMonster,
        King,
        WorldKing
    };

    [Flags]
    public enum CharacterClassFlags
    {
        GM = 1,
        Warrior=2,
        Scout=4,
        Rogue=8,
        Mage=0x10,
        Priest=0x20,
        Knight=0x40,
        Warden=0x80,
        Druid=0x100,
        Warlock=0x200,
        Champion=0x400,
        Class11=0x800,
        Class12=0x1000,
        Class13=0x2000,
        Class14=0x4000,
        Class15=0x8000,
        Class16=0x10000,
    }
    public enum CharacterClass
    {
        None = -1,
        GM = 0,
        Warrior,
        Scout,
        Rogue,
        Mage,
        Priest,
        Knight,
        Warden,
        Druid,
        Warlock,
        Champion,
        Class11,
        Class12,
        Class13,
        Class14,
        Class15,
        Class16,
    }
    public enum Race
    {
        None = -1,
        Race0 = 0,
        Race1,
        Race2,
        Race3,
        Race4,
        UndeadRace,
        Race6,
        Race7,
        Race8,
        Race9,
        Race10,
        Race11,
        Race12,
        Race13,
        Race14,
        Race15
    }
    [Flags]
    public enum RaceFlags
    {
        Race0 = 1,
        Race1=2,
        Race2=4,
        Race3=8,
        Race4=16,
        UndeadRace=32,
        Race6=64,
        Race7=128,
        Race8=256,
        Race9=512,
        Race10=1024,
        Race11=2048,
        Race12=4096,
        Race13=8192,
        Race14=16384,
        Race15=32768
    }

    public enum SpellRightTime
    {
        None,
        Normal,
        OnAttack,
        Attack,
        AttackHpHalf,
        AttackHpQuarter,
        FriendDead,
        KeepDistance
    }

    public enum SpellTarget
    {
        Self, //¦Ы¤v
        Target, //ҐШјР
        TargetHpHalf, //ҐШјР(HP 1/2)
        TargetHpQuarter, //ҐШјР(HP 1/4)
        TargetDistance30, //ҐШјР(¶ZВч30ҐH¤W )
        TargetEscape, //ҐШјР(°k¶])

        Friend, //¤Н¤и
        FriendHpHalf, //¤Н¤и(HP 1/2)
        FriendHpQuarter, //¤Н¤и(HP 1/4)
        Enemy, //јД¤и
        EnemyHpHalf, //јД¤и(HP 1/2)
        EnemyHpQuarter, //јД¤и(HP 1/4)

        TargetSpell, //ҐШјР¬IЄk	  
        EnemyRangeEnemySpell, //¤і«лЄн¤єЄє¬IЄkҐШјР 
        EnemySecond, //¤і«лІД¤G
        EnemyLast, //¤і«ліМ¤p
        EnemyNearest, //¤і«лЄніМЄсЄє
        EnemyFarest, //¤і«лЄніМ»·Єє

        Master, //ҐD¤H
        MasterHpHalf, //ҐD¤H(HP 1/2)
        MasterHpQuarter
    }

    public enum EffectRangeType
    {
        Target, //ҐШјР¦і®Д
        GoodRange, //¦nЄєЅdітЄkіN
        GoodMember, //¦nЄє¦Ё­ыЄkіN
        BadRange, //ГaЄєЅdітЄkіN
        AllObj,
        AllPlayer,
        AllMonster,
        AllPlayerEnemy, //©Т¦іјД¤иЄ±®a
        AllPlayerFriend
    }

    public enum SpellSellectType
    {
        Circle, //圓形
        Line1, //直線( 目標面向  有效距離)
        Line2, //直線( 施法者 -> 目標 )
        Line3, //直線( 施法者向目標  有效距離 )
        Fan, //扇形
        Lighting1, //連鎖電
        Lighting2, //連鎖電( 可重覆選 )
        Horizontal, //橫線
        Box, //方型
    }

    public enum HitRateFunc
    {
        Base, //定值
        LevelDifference, //等級差
        LevelDifferenceSquared, //等級差平方
        DecPerPerson, //依人次降低
        Shoot, //射擊計算

    }

    public enum SpellCostType
    {
        None, //無消耗
        Hp, //消耗 HP
        Mp, //消耗 MP
        HpPercent, //消耗 HP百分比
        MpPercent, //消耗 MP百分比
        Rage, //消耗 SP 戰士(-1表示全部)
        Concentration, //消耗 SP 遊俠(-1表示全部)
        Energy, //消耗 SP 盜賊(-1表示全部)
        StomachPoint, //消耗 飽食度
        Item, //消耗 物品
        AmmoGun, //消耗 子彈
        AmmoBow, //消耗 弓箭矢
        AmmoCossBow, //消耗 十字弓箭矢
        AmmoThrow, //消耗 投擲物
        AmmoAll //消耗 所有的遠程彈藥
    }

    public enum SpellNeedType
    {
        None, //無需求
        Weapon, //需求 自己裝 武器
        Equipment, //需求 自己裝 裝備
        Suit, //需求 自己裝 套裝
        Buf, //需求 自己有 法術Buf
        BufTarget, //需求 目標有 法術Buf
        NoBuf, //需求 自己沒有 法術Buf
        NoBufTarget, //需求 目標沒有 法術Buf
        WeaponTypeUnarmed, //需求 自己裝 武器類型 空手
        WeaponTypeBlade, //需求 自己裝 武器類型 單手劍
        WeaponTypeDagger, //需求 自己裝 武器類型 匕首
        WeaponTypeWand, //需求 自己裝 武器類型 權杖
        WeaponTypeAxe, //需求 自己裝 武器類型 單手斧
        WeaponTypeBludgeon, //需求 自己裝 武器類型 鎚棍棒
        WeaponTypeClaymore, //需求 自己裝 武器類型 雙手劍
        WeaponTypeStaff, //需求 自己裝 武器類型 杖
        WeaponType2HAxe, //需求 自己裝 武器類型 雙手斧
        WeaponType2HHammer, //需求 自己裝 武器類型 雙手鎚
        WeaponTypePolearm, //需求 自己裝 武器類型 槍(長矛)
        WeaponTypeSwordType, //需求 自己裝 武器類型 劍類(單雙手)
        WeaponTypeAxeType, //需求 自己裝 武器類型 斧類(單雙手)
        WeaponTypeShield, //需求 自己裝 武器類型 盾
        Distance, //需求 距離目標
        NotAttak, //需求 自己非戰鬥
        Attack, //需求 自己戰鬥
        Critical, //需求 自己爆擊
        BeCritical, //需求 自己被爆擊
        Dodge, //需求 自己閃避
        BeDodge, //需求 自己被閃避
        Miss, //需求 自己Miss
        Parry, //需求 自己格擋
        BeParry, //需求 自己被格擋
        NotAttackTarget, //需求 目標非戰鬥
        AttackTarget, //需求 目標戰鬥	
        SelfHpSmallerPercent, //需求 HP百分比小於
        SelfHpGreaterPercent, //需求 HP百分比大於
        SelfJob, //需求 職業
        WeaponTypeLongDistWeapon, //需求 自己裝 武器類型 長距離武器
        WeaponType2HWeapon, //需求 自己裝 武器類型 雙手武器
        WeaponTypeHammer, //需求 自己裝 武器類型 鎚類(單雙手)
        BuffGroup, //需求 自己擁有某 Buff Group
        ShieldBlock, //需求 自己盾擋
        BeShieldBlock, //需求 自己被盾擋
        WeaponType_1HWeapon, //需求 自己裝 武器類型 單手武器
        NoBuffGroup, //需求 自己沒有某 Buff Group
        TargetBuffGroup, //需求 目標擁有某 Buff Group
        TargetNoBuffGroup, //需求 目標沒有某 Buff Group
        MagicCritical, //需求 自己爆擊
        BeMagicCritical, //需求 自己被爆擊
        SelfMainJob, //需求 主職業

    }

    public enum CooldownClass
    {
        None,
        Class,
        Equipment,
        Item
    }

    [Flags]
    public enum SpellFlags
    {
        InterruptOnMove = 0x00000001,
        InterruptOnAttack = 0x00000002,
        SpellBack = 0x00000004, //敵人背後才可施展
        SpellFront = 0x00000008,
        SpellLookAtTarget = 0x00000010, //面向敵人才可施展
        ReferenceWeaponBow = 0x00000020, //參照弓 攻速 攻擊距離 ( 冷卻時間距離)
        ReferenceWeaponThrow = 0x00000040, //參照暗器 攻速 攻擊距離 ( 冷卻時間距離)
        Dash = 0x00000010, //衝撞
        AllColdownReferenceWeapon = 0x00000080, //共用冷卻 參考武器攻速
        NoInterrupt = 0x00000100, //不會被技能中斷
        HideCastingBar = 0x00000200, //不顯示施法條
        InterruptSpellOtherMagic = 0x00000400, //施展其它的法術中斷
        IgnoreObstruct = 0x00000800, //忽視阻檔物(範圍法術)
        ReferenceWeaponBowSpellTime = 0x00001000, //參照弓 攻速 攻擊距離 ( 施法時間距離)
        ReferenceWeaponThrowSpellTime = 0x00002000, //參照暗器 攻速 攻擊距離 ( 施法時間距離)
        IgnoreFightingLog = 0x00004000, //忽略戰鬥記錄
        NoObjectInMagicEffectRange = 0x00008000, //範圍內不可以有物件
        DescDurable = 0x00010000, //損耗耐久度
        ForceDisplayEffect = 0x00020000
    }

    public enum MagicCheckFunction
    {
        None, //"無"									
        Rand, //"亂數"									
        SelfEq, //"自己裝備( 機率 , 裝備號碼 )"			
        TargetEq, //"目標裝備( 機率 , 裝備號碼 )"			
        SelfEqType, //"自己裝備類型( 機率 , 裝備類型 )"			
        TargetEqType, //"目標裝備類型( 機率 , 裝備類型 )"			
        SelfItem, //"自己物品( 機率 , 物品 or 重要物品 )"	
        TargetItem, //"目標物品( 機率 , 物品 or 重要物品 )"	
        SelfBuff, //"自己Buff( 機率 , 擁有某Buff )"			
        TargetBuff, //"目標Buff( 機率 , 擁有某Buff )"			
        SelfPosition, //"自己位置( 機率 , 位置辨別碼 )"			
        TargetPosition, //"目標位置( 機率 , 位置辨別碼 )"			
        SelfFight, //"自己戰鬥( 機率 , 0非戰鬥/1戰鬥  )"		
        TargetFight, //"目標戰鬥( 機率 , 0非戰鬥/1戰鬥  )"		
        TargetRace, //"目標種族( 機率 , 種族ID  )"			
        SelfHp, //"自己HP低於( 機率 , HP百分比 )"		
        Time, //"時間( 機率 , 時間 )"					
        Weather, //"氣候( 機率 , 氣候辨別碼 )"				
        SelfBuffGroup, //"自己Buff Group( 機率 , 擁有某Buff群組 )"			
        TargetBuffGroup, //"目標Buff Group( 機率 , 擁有某Buff群組 )"			
        SelfSkill, //"自己學會某技能( 機率 , 法術ID )"	
        BaseLv, //"需求等級( 機率 , LV )"	
    }

    public enum WearEquipmentType
    {
        None, // "無效果",
        Durable, // "耐久度",
        Strength, // "屬性 STR 力量",
        Stamina, // "屬性 STA 耐力",			
        Inteligence, // "屬性 INT 智力",			
        Wisdom, // "屬性 MND 靈力",
        Dexterity, // "屬性 AGI 敏捷",			
        AllState, // "屬性 所有(基本五個屬性)",
        MaxHp, // "上限 HP",
        MaxMp, // "上限 MP",
        RegenHp, // "回復率 HP",
        RegenMp, // "回復率 MP",
        PhysAttack, // "ATK 攻擊力",
        PhysDefence, // "DEF 防禦力",
        MagicDefence, // "MDEF 魔法防禦",
        MagicAttack, // "MATK 魔法攻擊",
        HitPoint, // "命中",
        DodgePoint, // "迴避",
        CritRate, // "暴擊等級",
        CritPower, // "暴擊威力加強(%)",
        MagicCritRate, // "法術暴擊等級",
        MagicCritPower, // "法術暴擊威力加強(%)",
        ParryRate, // "格擋等級",
        AtkSpeed, // "攻擊速度(%)",
        MoveSpeed, // "移動速度(%)",
        PhysDamage, // "武器威力 所有近戰或遠程 ( DMG )",
        AllResist, // "抗性 所有",
        ResistEarth, // "抗性 地",
        ResistWater, // "抗性 水",
        ResistFire, // "抗性 火",
        ResistWind, // "抗性 風",
        ResistLight, // "抗性 光",
        ResistDarkness, // "抗性 闇",
        ManaDecrease, // "MP消耗減少(%)",
        Exp, // "經驗值",
        Treasure, // "掉寶率",
        SecHandHitRate, // "副手 命中率",
        SecHandDmgPer, // "副手 傷害力(DMG%)",
        DefHeavyArmed, // "防禦加強 鎧甲(%)",
        DefLightArmed, // "防禦加強 鎖甲(%)",
        DefLeather, // "防禦加強 皮甲(%)",
        DefClothes, // "防禦加強 衣服(%)",
        DefRobe, // "防禦加強 長袍(%)",
        DefShield, // "防禦加強 盾(%)",
        MagicPowAllMagic, // "魔法威力 所有(%)",
        MagicPowEarth, // "魔法威力 地(%)",
        MagicPowWater, // "魔法威力 水(%)",
        MagicPowFire, // "魔法威力 火(%)",
        MagicPowWind, // "魔法威力 風(%)",
        MagicPowLight, // "魔法威力 光(%)",
        MagicPowDarkness, // "魔法威力 闇(%)",
        SpellSpeedAllMagic, // "施法速度 所有(%)",
        DmgAllRange, // "遠程武器威力(%) 所有",
        DmgBow, // "遠程武器威力(%) 弓",
        DmgCossbow, // "遠程武器威力(%) 十字弓",
        DmgGun, // "遠程武器威力(%) 槍",
        DmgAllWeapon, // "近戰武器威力(%) 所有",
        DmgUnarmed, // "近戰武器威力(%) 空手",
        DmgBlade, // "近戰武器威力(%) 劍",
        DmgDagger, // "近戰武器威力(%) 匕首",
        DmgWand, // "近戰武器威力(%) 權杖",
        DmgAxe, // "近戰武器威力(%) 斧",
        DmgBludgeon, // "近戰武器威力(%) 鎚棍棒",
        DmgClaymore, // "近戰武器威力(%) 雙手劍",
        DmgStaff, // "近戰武器威力(%) 杖",
        Dmg_2HAxe, // "近戰武器威力(%) 雙手斧",
        Dmg_2HHammer, // "近戰武器威力(%) 雙手鎚",
        DmgPolearm, // "近戰武器威力(%) 槍(長矛)",
        AttackSpeedAllRange, // "遠程武器速度(%) 所有",
        AttackSpeedBow, // "遠程武器速度(%) 弓",
        AttackSpeedCossbow, // "遠程武器速度(%) 十字弓",
        AttackSpeedGun, // "遠程武器速度(%) 槍", 
        AttackSpeedAllWeapon, // "近戰武器速度(%) 所有",
        AttackSpeedUnarmed, // "近戰武器速度(%) 空手",
        AttackSpeedBlade, // "近戰武器速度(%) 劍",
        AttackSpeedDagger, // "近戰武器速度(%) 匕首",
        AttackSpeedWand, // "近戰武器速度(%) 權杖",
        AttackSpeedAxe, // "近戰武器速度(%) 斧",
        AttackSpeedBludgeon, // "近戰武器速度(%) 鎚棍棒",
        AttackSpeedClaymore, // "近戰武器速度(%) 雙手劍",
        AttackSpeedStaff, // "近戰武器速度(%) 杖",
        AttackSpeed_2HAxe, // "近戰武器速度(%) 雙手斧",
        AttackSpeed_2HHammer, // "近戰武器速度(%) 雙手鎚",
        AttackSpeedPolearm, // "近戰武器速度(%) 槍(長矛)",
        WearEqAbilityUnarmed, // "裝備能力 空手",
        WearEqAbilityBlade, // "裝備能力 劍",	  	  	
        WearEqAbilityDagger, // "裝備能力 匕首",
        WearEqAbilityWand, // "裝備能力 權杖",  	
        WearEqAbilityAxe, // "裝備能力 斧",	  	
        WearEqAbilityBludgeon, // "裝備能力 鎚棍棒",
        WearEqAbilityClaymore, // "裝備能力 雙手劍",
        WearEqAbilityStaff, // "裝備能力 杖",
        WearEqAbilityAxe_2H, // "裝備能力 雙手斧",
        WearEqAbilityHammer_2H, // "裝備能力 雙手鎚",
        WearEqAbilityPolearm, // "裝備能力 槍(長矛)",
        WearEqAbilityBow, // "裝備能力 弓",
        WearEqAbilityCossBow, // "裝備能力 十字弓",
        WearEqAbilityGun, // "裝備能力 槍",
        WearEqAbilityThrow, // "裝備能力 投擲",
        WearEqAbilityHeavyArmed, // "裝備能力 鎧甲",
        WearEqAbilityLightArmed, // "裝備能力 鎖甲",
        WearEqAbilityLeather, // "裝備能力 皮甲",
        WearEqAbilityClothes, // "裝備能力 衣服",
        WearEqAbilityRobe, // "裝備能力 長袍",
        WearEqAbilityShield, // "裝備能力 盾",
        WearEqAbilityImplement, // "裝備能力 手持法器",
        WearEqAbilitySecondHand, // "裝備能力 雙手持",
        SkillValueUnarmed, // "技能上升 Unarmed空手",
        SkillValueBlade, // "技能上升 劍",
        SkillValueDagger, // "技能上升 匕首",
        SkillValueWand, // "技能上升 權杖",
        SkillValueAxe, // "技能上升 斧",
        SkillValueBludgeon, // "技能上升 鎚棍棒",
        SkillValueClaymore, // "技能上升 雙手劍",
        SkillValueStaff, // "技能上升 杖",
        SkillValue_2HAxe, // "技能上升 雙手斧",
        SkillValue_2HHammer, // "技能上升 雙手鎚",
        SkillValuePolearm, // "技能上升 槍(長矛)",
        SkillValueBow, // "技能上升 遠程武器 弓",
        SkillValueCossBow, // "技能上升 遠程武器 十字弓",
        SkillValueGun, // "技能上升 遠程武器 槍",
        SkillValueDefine, // "技能上升 防禦",
        SkillValueBlackSmith, // "技能上升 打鐵",
        SkillValueCarpenter, // "技能上升 木工",
        SkillValueMakeArmor, // "技能上升 製甲",
        SkillValueTailor, // "技能上升 裁縫",
        SkillValueCook, // "技能上升 烹飪",
        SkillValueAlchemy, // "技能上升 煉金",
        HqBlackSmith, // "HQ品機率上升 打鐵(%)",
        HqCarpenter, // "HQ品機率上升上升 木工(%)",
        HqMakeArmor, // "HQ品機率上升上升 製甲(%)",
        HqTailor, // "HQ品機率上升上升 裁縫(%)",
        HqCook, // "HQ品機率上升上升 烹飪(%)",
        HqAlchemy, // "HQ品機率上升上升 煉金(%)",	
        AtkPer, // "ATK 攻擊力 (%)",
        DefPer, // "DEF 防禦力 (%)",
        StealRate, // "偷竊成功率 (%)",
        DropMoneyRate, // "金錢掉落率 (%)",
        HateRate, // "仇恨度增加 (%)",
        ReSpPerWarrior, // "戰士SP 回復加百分比",
        ReSpPerRanger, // "遊俠SP 回復加百分比",
        ReSpPerRogue, // "盜賊SP 回復加百分比",
        MAbsorbRate, // "魔法吸收率",
        AbsorbRate, // "防禦吸收率",
        HealAbsorbRate, // "治療吸收率",
        MAbsorb, // "魔法吸收點數",
        Absorb, // "防禦吸收點數",
        HealAbsorb, // "治療吸收點數",
        MagicDamagePoint, // "魔法傷害加點",
        HealPowerRate, // "治療威力增加率",
        HealPoint, // "治療威力增加點數",
        RangeAttackRange, // "遠程武器攻擊距離增加",

        SkillValueLumbering, // "技能上升 筏木",
        SkillValueHerbalism, // "技能上升 採藥",
        SkillValueMining, // "技能上升 挖礦",
        SkillValueFishing, // "技能上升 釣魚",

        HqLumbering, // "HQ品機率上升 筏木",
        HqHerbalism, // "HQ品機率上升 採藥",
        HqMining, // "HQ品機率上升 挖礦",
        HqFishing, // "HQ品機率上升 釣魚",

        SkillValueGatherRate, // "採集成功率",

        StrengthMultiplier, // "屬性 STR 力量(%)",
        StaminaMultiplier, // "屬性 STA 耐力(%)",			
        InteligenceMultiplier, // "屬性 INT 智力(%)",			
        WisdomMultiplier, // "屬性 MND 靈力(%)",
        DexterirtyMultiplier, // "屬性 AGI 敏捷(%)",			
        AllStateMultiplier, // "屬性 所有(%)(基本五個屬性)",
        MaxHpMultiplier, // "上限 HP(%)",
        MaxMpMultiplier, // "上限 MP(%)",
        RideSpeed, // "騎乘速度(%)",
        MagicDefenceMultiplier, // "MDEF(%) 魔法防禦",
        MagicAttackMultiplier, // "MATK(%) 魔法攻擊",
        ShieldBlockRate, // "盾擋等級",
        PhysDamageMultiplier, // "武器威力 所有近戰或遠程 ( DMG% )",
        ExpSubJob, // "副職經驗值"
        TpRate, // "TP經驗值"

        SkillValueLumberingRate, // "筏木成功率",
        SkillValueHerbalismRate, // "採藥成功率",
        SkillValueMiningRate, // "挖礦成功率",
        SkillValueFishingRate, // "釣魚成功率",
        Gravity, // "重力修正"  ,

        DoubleAttack, // "兩次攻擊" ,

        ResistCritRate, // "抗暴等擊",
        ResistMagicCritRate, // "底抗魔法致命一擊率",

        //固定法術效果
        MagicEarthPower, // "地屬性攻擊" ,
        MagicWaterhPower, // "水屬性攻擊" ,
        MagicFirePower, // "火屬性攻擊" ,
        MagicWindhPower, // "風屬性攻擊" ,
        MagicLightPower, // "光屬性攻擊" ,
        MagicDarkPower, // "暗屬性攻擊" ,

        JumpRate, // "跳躍比率"   ,
        MagicDamage, // "魔法殤害點數"	,
        MagicDamageMultiplier, // "魔法殤害比率"	,

        ResistShieldBlock, // "刺穿盾檔",
        ResistParry, // "刺穿格擋",

        MagicHitPoint, // "魔法命中",
        MagicDodgePoint, // "魔法閃避",

        PhysHitRate, // "物理命中率",
        PhysDodgeRate, // "物理閃避率",
        MagicHitRate, // "魔法命中率",
        MagicDodgeRate, // "魔法閃避率",

        GatherGenerateRate, // "採集產出量增加率",
        GatherSpeedRate, // "採集速度增加率",
        GatherExpRate, // "採集經驗值增加率",

        AttackPlayerPowerRate, // "(攻)攻擊玩家(or玩家寵物)威力加減",
        AttackNPCPowerRate, // "(攻)攻擊NPC威力加減",
        PlayerDefRate, // "(守)被玩家(or玩家寵物)攻擊威力加減",
        NPCDefRate, // "(守)被NPC攻擊威力加減",
        AeMagicPowerRate, // "(攻)AE法術攻擊威力加減",
        AeMagicDefRate, // "(守)被AC法術攻擊威力加減",

        CraftSpeedRate, // "生產速度增加率"
        CraftExpRate, // "生產經驗值增加率"
        AddPlotExpRate, // "增加劇情給予的經驗值率"
        AddPlotTpRate, // "增加劇情給予的TP率"

        SpWarriorConsume, // "戰意消耗減少(%)"
        SpRogueConsume, // "精力消耗減少(%)"
        SpRangerConsume, // "專注消耗減少(%)"

        NPCExpRate, // "NPC 經驗值修正(%)"
        NPCTpRate, // "NPC TP經驗值修正(%)"

        MaxCount,
    }

    public enum MagicFunc
    {
        HpMp = 0,
        Assist, //輔助
        Teleport, //傳送
        SummonCreature, //招換生物(寵物)
        SummonItem, //招換物品
        Steal, //偷竊
        ItemRunPlot, //產生物品並且執行劇情
        RunPlot, //執行劇情
        Resurrect //復活
    }

    public enum MagicResist
    {
        None = -1,
        Earth,
        Water,
        Fire,
        Wind,
        Light,
        Darkness
    }

    public enum PhysicalResist
    {
        None = -1, //無
        Hit, //打擊
        Cut, //砍擊
        Puncture
    }

    public enum DotMagicType
    {
        HP, //HP
        MP, //MP
        Rage, //戰士SP
        Concentration, //遊俠SP
        Energy, //盜賊SP
        HPPercent, //HP百分比
        MPPercent, //MP百分比

    }

    public enum MagicAttackType
    {
        HP,
        MP,
        Rage,
        Concentration,
        Energy,
        StomachPoint
    }

    public enum MagicAttackCal
    {
        None,
        MPow,
        Weapon, // (本身DMG + 主手DMG)
        Shoot, //  射擊類( 本身DMG + 弓DMG + 彈藥DMG)
        Throw, //  投擲類( 本身DMG + 彈藥DMG)
        INT,
        STR,
        AGI,
        STA,
        MND,
        LastSkillDmg,
        LastPhyDmg,
        ShieldDef,
    }

    [Flags]
    public enum MagicSetting : uint
    {
        GoodMagic = 0x00000001, //好的法術
        ShowBuf = 0x00000002, //顯示Buf
        ContinueMagic = 0x00000004, //連續產生法術
        DotMagic = 0x00000008, //DOT法術
        FaceOffMagic = 0x00000010, //變身術 			
        CancelBuff = 0x00000020, //可取消
        ShowBuffTime = 0x00000040, //Client端顯示Buff時間
        SpecialMagic = 0x00000080, //產生特殊法術
        MagicShield = 0x00000100, //魔法盾
        DeadNotClear = 0x00000200, //死亡不清除
        OfflineBuffTime = 0x00000400, //下線Buff時間計算
        OnPlayerAttackAddTime = 0x00000800, //攻擊玩家增加buff時間
        OnKillAddTime = 0x00001000, //殺死物件增加buff時間
        SelfBuff = 0x00002000, //私人Buf,不會與其他人的Buf互刺
        FaceOffMagicShowEq = 0x00004000, //變身時顯示原本裝備武器
        ShowPowerLv = 0x00008000, //顯示PowerLv
        DotMagicNoKill = 0x00010000, //Dot法術殺不死人
        BuffSkill = 0x00020000, //Buff擁有技能
        MaxMagicLvEquRoleLv = 0x00040000, //Buff最高等級最多同玩家等級
        DisableShowMagicInfo = 0x00080000, //Client 端不顯示加減血的資訓
        FixDotPower = 0x00100000, //Dot不計算裝備能力(不算攻防比)
        RideCanAttack = 0x00200000, //攻擊不會下馬
        RidePetAttack = 0x00400000, //騎乘寵物做攻擊動作
        CancelBadMagic = 0x00800000, //清除目標是自己的壞的法術
        NpcEndFightNotClearBuff = 0x01000000, //戰鬥結束不會消失的Buff
        DualNoClearBuff = 0x02000000, //比試結束不清除的buff
        IgnoreSpellCureMagicClear = 0x04000000, //忽略施展治療消失
        IgnoreSpellAttackMagicClear = 0x08000000, //忽略施展攻擊消失
        IgnoreBuffMessage = 0x10000000, //忽略施展攻擊消失(client 端顯像用 )
        OnlyYouCanSee = 0x20000000, //只有自己看的到特效
        NoEffect = 0x40000000, //(Client 顯示處理用)
        ForceDisplayEffect = 0x80000000, //強制顯示特效
    }

    [Flags]
    public enum MagicAttackSpecialAction
    {
        None = 0x00000001, //保留
        StrikeBack = 0x00000002, //震退
        SpellInterrupt = 0x00000004, //施法中斷
        IgnoreDefine = 0x00000008, //無視防禦or抗性
        EraseHate = 0x00000010, //清除仇恨( 會轉嫁 同加血計算 )
        HateOnePoint = 0x00000020, //仇恨清除為1
        Bomb = 0x00000040, //炸飛
    }

    [Flags]
    public enum MagicEffect : ulong
    {
        NoFlags                 = 0x0000000000000000,
        UseMagicDisable         = 0x0000000000000001, //不可用法術攻擊
        UsePhyDisable           = 0x0000000000000002, //不可用物理攻擊
        BadMagicInvincible      = 0x0000000000000004, //壞的法術無效(法術技能無效)
        BadPhyInvincible        = 0x0000000000000008, //壞的物理無效(物理技能與一般攻擊無效)
        UseItemDisable          = 0x0000000000000010, //不可使用物品
        SearchEmenyDisable      = 0x0000000000000020, //不可索敵
        Stop                    = 0x0000000000000040, //不可移動
        Cover                   = 0x0000000000000080, //隱形
        DetectCover             = 0x0000000000000100, //偵測隱形
        Sneak                   = 0x0000000000000200, //潛行
        DetectSneak             = 0x0000000000000400, //偵測潛行
        Blind                   = 0x0000000000000800, //失明(螢幕全黑)
        HitDown                 = 0x0000000000001000, //倒地
        Trace                   = 0x0000000000002000, //追蹤			
        PlayDead                = 0x0000000000004000, //裝死
        Insure                  = 0x0000000000008000, //保險(抵死一次)
        Chaos                   = 0x0000000000010000, //混亂
        Fear                    = 0x0000000000020000, //恐懼
        LockTarget              = 0x0000000000040000, //攻擊目標索定			
        WeaponIgnore            = 0x0000000000080000, //武器無效化
        ArmorIgnore             = 0x0000000000100000, //防具無效化			
        Ride                    = 0x0000000000200000, //騎乘
        Raise                   = 0x0000000000400000, //重生
        ExpProtect              = 0x0000000000800000, //死亡經驗值不扣
        ClientDizzy             = 0x0000000001000000, //暈眩(Client 行為) 
        ClientSleep             = 0x0000000002000000, //睡眠(Client 行為)
        PKFlag                  = 0x0000000004000000, //PK狀態(有開啟的人就可以PK)
        TeleportDisable         = 0x0000000008000000, //禁止傳送
        GPS                     = 0x0000000010000000, //位置定位器致能
        PKFlagDisabled          = 0x0000000020000000, //PK禁制令
        AILowAttackPriority     = 0x0000000040000000, //被怪ai攻擊-優先降到最低
        StopOntimeCure          = 0x0000000080000000, //停止HPMPSP定時回復
        Silence                 = 0x0000000100000000, //禁止說話(GM)
        CliOutofContorl         = 0x0000000200000000, //Client不可控制
        Freeze                  = 0x0000000400000000, //Client玩家冰凍
        GoodMagicInvincible     = 0x0000000800000000, //好的法術無效(法術技能無效)
        GoodPhyInvincible       = 0x0000001000000000, //好的物理無效(物理技能與一般攻擊無效)
        Guilty                  = 0x0000002000000000, //有罪
        Critial                 = 0x0000004000000000, //絕對致命一擊
        Hunter                  = 0x0000008000000000, //獵殺者
        NoEscape                = 0x0000010000000000, //不可逃跑
        DisableJobSkill         = 0x0000020000000000, //不能使用原本職業技能
        IgnoreDeadGoodEvil      = 0x0000040000000000, //不處理死亡善惡值
        ExchangeZoneDamageEvent = 0x0000080000000000, //取代區域傷害
        Fly                     = 0x0000100000000000, //飛行
        WaterWalk               = 0x0000200000000000, //水上行走
        GravityDisable          = 0x0000400000000000, //暫時無重力
        DisableStrikeBack       = 0x0000800000000000, //震退無效
        DisableWagon            = 0x0001000000000000, //不能上載具
        IgnoreInstancePlayer    = 0x0002000000000000,
    }

    [Flags]
    public enum MagicClearTime : uint
    {
        Attack = 0x00000001, //攻擊消失
        UnderAtk = 0x00000002, //被攻擊消失
        Move = 0x00000004, //移動消失
        Spell = 0x00000008, //施法/用物理技/使用物品消失
        ChangeZone = 0x00000010, //換區消失
        Logout = 0x00000020, //離線消失
        Random = 0x00000040, //亂數消失 Max/3 ~ Max
        WarriorSP = 0x00000080, //戰士SP為0消失
        RangerSP = 0x00000100, //遊俠SP為0消失
        RogueSP = 0x00000200, //盜賊SP為0消失
        HP = 0x00000400, //HP為0消失
        MP = 0x00000800, //MP為0消失
        SpellMagicAttack = 0x00001000, //施攻擊法術消失
        SpellPhyAttack = 0x00002000, //施攻擊技能消失
        SpellCure = 0x00004000, //施攻回復魔法消失
        TargetOnAttack = 0x00008000, //目標是攻擊模式or看的到目標 攻擊消失
        OnStopAttackMode = 0x00010000, //停止攻擊
        OnWater = 0x00020000, //水中消失
        OnNoWater = 0x00040000, //路上消失
        SpellMagic = 0x00080000, //施放法術技能消失
        SpellPhy = 0x00100000 //施放物理技能消失
    }

    public enum SummonCreatureType
    {
        Pet,
        Guard,
        GuardNoAttack
    }

    public enum MagicItemRunPlotType
    {
        Plot, //劇情類
        Mine, //地雷類
        Staff, //插杖類
    }

    public enum MagicItemRunPlotTargetType
    {
        Enemy,
        Friend,
        Player,
        NPC,
        All,
        FriendNoSelf,
        PlayerNoSelf,
        AllNoSelf
    }

    [Flags]
    public enum RunPlotMode
    {
        Mark = 0x00000001,
        Fight = 0x00000002,
        DontShowHpMp = 0x00000004,
        EnemyHide = 0x00000008,
        DontRelyOnOwnerPower = 0x00000010
    }

    public enum MagicShieldType
    {
        MP, //MP抵消HP
        Times, //抵消次數
        Point, //抵消法數設定的點數
        Percent, //抵銷百分比
    };

    public enum MagicShieldEffect
    {
        All, //所有攻擊
        Phy, //物理攻擊
        Magic, //法術攻擊
        Earth, //地系法術攻擊
        Water, //水系法術攻擊
        Fire, //火系法術攻擊
        Wind, //風系法術攻擊
        Light, //光系法術攻擊
        Darkness, //暗系法術攻擊
    }

    public enum MagicAttackCalBase
    {
        Physics, //物理計算
        Magic, //法術計算
        Throw, //投擲計算
        Shoot, //射擊計算
        Fix, //定值
        HolyHeal, //神聖治療計算( 負值表示Miss  )
        DarkHeal, //不死系療計算( 負值表示Miss  )
        SpecialAction, //沒攻擊只有特殊行為
        FixPer, //百分比
        PhysicsPoint, //物理計算
        MagicEx //法數計算 比例*MDmg * MDmg_MagArg 
    }

    public enum SpecailMagicEventType
    {
        None, //無
        SelfCritial, //自己 攻擊致命一擊(普攻)
        TargetCritial, //目標 攻擊致命一擊(普攻)
        SelfDodge, //自己 閃避
        TargetDodge, //目標 閃避
        SelfMiss, //自己 Miss
        TargetMiss, //目標 Miss
        ZoneDamage, //區域傷害事件
        PhySelfCritial, //自己 攻擊致命一擊(物理)
        PhyTargetCritial, //目標 攻擊致命一擊(物理)
        MagSelfCritial, //自己 攻擊致命一擊(法術)
        MagTargetCritial, //目標 攻擊致命一擊(法術)
    }

    public enum ItemClass
    {
        Misc = 0,
        Money,
        Weapon,
        Armor,
        Rune,
        Card
    }

    public enum ItemType
    {
        Normal, //一般
        Plot, //劇情物品
        Food, //食物
        SweetFood, //甜食
        Water, //藥水
        Ore, //礦石
        Wood, //木材
        Herb, //藥草
        Hunt, //獵物
        Seed, //種子
        Flowerpot, //花盆
        Crop, //作物
        Fish, //魚
        Tool, //採集工具
        Stuff, //製造材料
        RecipeBlackSmith, //配方 打鐵
        RecipeCarpenter, //配方 木工
        RecipeArmor, //配方 製甲
        RecipeTailor, //配方 裁縫
        RecipeAlchemy, //配方 煉金
        RecipeCook, //配方 烹飪
        Jewel, //衝等寶石
        PowerLight, //效果光球
        Money, //金錢
        Rune, //符文
        PosRecord, //位置記錄
        GuildContribution, //公會貢獻品
        Lottery, //樂透彩卷
        Furniture, //家俱
        SpecialRune, //特殊符文
        SmeltStone, //熔解石
        Relation, //關係物品
        SummonHorse, //招換座騎
        Contract, //房屋契約
        Study, //修煉百科
        MagicStone, //魔石
        Collection, //委託收集
        Packet, //包裹物品
        Pet, //寵物物品
        PetTools, //寵物工具
        PetFurniture, //寵物傢俱
        PetFood, //寵物食物
        PacketDropList, //打包物(掉落表所有東西)
        Egg, //商城轉蛋
        ViewPet, //觀賞用寵物
    };

    public enum RareType
    {
        Normal,
        Good,
        Magic,
        Legend,
        Epic1,
        Epic2,
        Quality6,
        Quality7,
        Shop,
        ShopExtra,
        Quality10
    }

    [Flags]
    public enum ItemMode
    {
        DurableStart0 = 0x00000001, //耐久度重0開始
        PkNoDrop = 0x00000002, //pk時不會掉落
        DepartmentStore = 0x00000004, //商城物品
        DepartmentStoreFree = 0x00000008, //必爾丁商城物品
        ItemDropAllParty = 0x00000010, //全隊掉落
        UseWithoutFail = 0x00000020, //使用不會失敗
        SpecialSuit = 0x00000040, //酷裝
        ItemDropDepart = 0x00000080, //物品掉落自動分堆
        //物品資料
        PickupBound = 0x00000100, //檢取禁制
        Sell = 0x00000200, //可買賣
        Logoutdel = 0x00000400, //離線消失
        Expense = 0x00000800, //消耗
        Coloring = 0x00001000, //可染色
        GuildMark = 0x00002000, //公會章
        EqSoulBound = 0x00004000, //裝備禁制
        HideCount = 0x00008000, //不顯示數量
        ChangeZoneDel = 0x00010000, //換區消失
        HideRefineLight = 0x00020000, //衝等武器不顯示特效
        Unique = 0x00040000, //唯一物品
        VariableRare = 0x00080000, //(配方專用)稀有度會改變
        NoNPCAbility = 0x00100000, //物品掉落全靠物品本身屬性
        EnableLockedItem = 0x00200000 //可對鎖定的物品使用
    }

    public enum PriceType
    {
        None = -1,
        Gold,
        Diamonds,
        Rubies,
        ItemMoney1,		//必耳丁
        Honor,
        ArenaPoints,		//競技場點數(Arena)
        GuildWarEnergy,		//公會戰能量
        GuildWarHonor,		//公會戰戰績
        TrialBadge,		//試煉徽章
        Relics,		//古代遺物
        PriceType10,
        PriceType11,
        PriceType12
    }
    public enum CampId
    {
        Unknown = -1,
        NewHand,
        Good,
        Evil,
        Monster,
        Wagon,
        SNPC,
        Visitor,
        WF_A,
        WF_B,
        WF_C,
        Enemy,
        Camp9,
        Camp10,
        Camp11,
        Camp12,
        Camp13,
        Camp14,
    };

    [Flags]
    public enum WearEqupmentSkill
    {
        Unarmed = 0x00000001,
        OneHandedSword = 0x00000002,
        Dagger = 0x00000004,
        Wand = 0x00000008,
        OneHandedAxe = 0x00000010,
        OneHandedHammer = 0x00000020,
        TwoHandedSword = 0x00000040,
        Staff = 0x00000080,
        TwoHandedAxe = 0x00000100,
        TwoHandedHammer = 0x00000200,
        Spear = 0x00000400,
        Bow = 0x00000800,
        CrossBow = 0x00001000,
        Gun = 0x00002000,
        Throwable = 0x00004000,
        ArmorPlate = 0x00008000,
        ArmorChain = 0x00010000,
        ArmorLeather = 0x00020000,
        ArmorCloth = 0x00040000,
        Robe = 0x00080000,
        Shield = 0x00100000,
        Implement = 0x00200000,
        SecondHand = 0x00400000
    }

    public enum WeaponType
    {
        None = -1,
        Unarmed,// Unarmed空手
        OneHandedSword,// 劍
        Dagger,// 匕首
        Wand,// 權杖
        OneHandedAxe,// 斧
        OneHandedHammer,// 鎚棍棒
        TwoHandedSword,// 雙手劍
        Staff,// 杖
        TwoHandedAxe,// 雙手斧
        TwoHandedHammer,// 雙手鎚
        Spear,// 槍(長矛)
        Bow,// 遠程武器 弓
        CrossBow,// 遠程武器 十字弓
        Gun,// 遠程武器 槍
        AmmoArrows,// 子彈 弓
        AmmoGun,// 子彈 槍
        AmmoThrowable,// 投擲類武器
        Lumbering,// 筏木
        Herbalism,// 採藥
        Mining,// 採礦
        Fishing// 釣魚
    }
    public enum ArmorType
    {
        None = -1,
        Plate,
        Chain,
        Leather,
        Cloth,
        Robe,
        Shield,

        Implement,	// 手持器具
        Ornament,	// 飾品類

        //聲音類型
        Wood,	//木頭
        Stone,	//石頭
        Iron	//鐵
    }
    public enum WeaponPos
    {
        MainHand,   //主手
        SecondHand,   //副手
        OneHand,   //雙手都可以裝備
        TwoHand,   //兩手
        Ammo,   //子彈
        Bow,   //弓
        Manufacture//生產工具
    }
    public enum ArmorPos
    {
        Head,   //頭
        Gloves,   //手套
        Shoes,   //鞋子
        Clothes,   //上衣
        Pants,   //褲子
        Back,   //背部
        Belt,   //腰帶
        Shoulder,   //肩甲
        Necklace,   //項鍊 
        Ring,   //戒子
        Earring,   //耳飾
        SecondHand,   //副手
        MagicTool,	//法寶
        Ornament	//裝飾品
    };

    public enum StatRarity
    {
        Rare0 = 0,
        Rare1 = 1,
        Rare2 = 2,
        Rare3 = 3
    }
    public enum ItemUseType
    {
        None,
        Magic,
        SrvScript,
        CliScript,
        EqRefine,	//衝等
        RepairEq,	//修裝
        Dissolution,	//拆解物品
        Coloring,	//染色
        ClearBinds,	//清除裝備綁定
        ResetAbility,	//重設基本數值
        ResetSkillPoint,	//重設技能點數
        EqAddRuneSlot,	//裝備挖洞
        EqClearRunes,	//清除裝備符文
        ItemLock,	//裝備鎖
        ItemUnLock,	//解除裝備鎖
        EqProtect,	//裝備保護
        EqLimitMax,	//裝備耐久上限到Max
        IgnoreLimitLv,	//忽略等級限制
        PK_EqProtect,	//PK裝備保護
        PK_EqProtect_Clear,	//PK裝備保護清除
        PackageOpen,	//打開包裹物品
        PackageOpenDropList,	//打包物解開(掉落表所有東西)
        Egg,	//商城轉蛋
        ClsEqSoulbound,	//清除裝備綁定
        ClsEqAbility,	//清除所有裝備屬性
    };
}
