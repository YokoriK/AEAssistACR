using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.CombatRoutine.Module.Opener;
using AEAssist;
using AEAssist.Extension;
using LoGya.SlotResolver.GCD;
using LoGya.QtUI;
using LoGya.Common;
using LoGya.SlotResolver.Ability;
using LoGya.SlotResolver.Opener;
using LoGya.Triggers;

namespace LoGya;

public class WarRotationEntry : IRotationEntry, IDisposable
{
    public string AuthorName { get; set; } = "LoGya";
    private readonly Jobs _targetJob = Jobs.Warrior;
    private readonly AcrType _acrType = AcrType.HighEnd; //高难专用
    private readonly int _minLevel = 70;
    private readonly int _maxLevel = 100;

    private readonly string _description = "你说的对但是\n" +
                                           "龙眼就是荔枝，荔枝就是龙眼";
    
    private readonly List<SlotResolverData> _slotResolvers =
    [
        new(new 飞斧(), SlotMode.Gcd),
        new(new 强制红斩(), SlotMode.Gcd),
        new(new 蛮荒(), SlotMode.Gcd),
        new(new 飞锯狂魂(),SlotMode.Gcd),
        new(new Base(), SlotMode.Gcd),
        
        new(new 自动团减(), SlotMode.OffGcd),
        new(new 自动血气(), SlotMode.OffGcd),
        new(new 解放(),SlotMode.OffGcd),
        new(new 爆发药(), SlotMode.OffGcd),
        new(new 怒震(), SlotMode.OffGcd),
        new(new 动乱群山(), SlotMode.OffGcd),
        new(new 猛攻(), SlotMode.OffGcd),
        new(new 战壕(), SlotMode.OffGcd),
    ];
    
    public Rotation? Build(string settingFolder)
    {
        WarSettings.Build(settingFolder);
        Qt.Build();
        var rot = new Rotation(_slotResolvers)
        {
            TargetJob = _targetJob,
            AcrType = _acrType,
            MinLevel = _minLevel,
            MaxLevel = _maxLevel,
            Description = _description,
        };
        rot.AddOpener(level => level < _minLevel ? null : GetOpener());
        rot.SetRotationEventHandler(new EventHandler());
        rot.AddTriggerAction(new TriggerActionQt(), new TriggerActionHotkey());
        rot.AddTriggerCondition(new TriggerCondQt());
        rot.AddCanUseHighPrioritySlotCheck(Helper.HighPrioritySlotCheckFunc);
        return rot;
    }

    IOpener? GetOpener()
    {
        if (Core.Me.Distance(Core.Me.GetCurrTarget()) > SettingMgr.GetSetting<GeneralSettings>().AttackRange)
            return new Opener通用猛攻();
        
        return new Opener通用1起手();
    }

    public IRotationUI GetRotationUI()
    {
        return Qt.Instance;
    }

    public void OnDrawSetting()
    {
    }

    public void Dispose()
    {
    }
}