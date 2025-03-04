using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using LoGya.SlotResolver.GCD;
using LoGya.QtUI;
using LoGya.Common;
using LoGya.Triggers;

namespace LoGya;

public class WarRotationEntry : IRotationEntry, IDisposable
{
    public string AuthorName { get; set; } = "LoGya";
    private readonly Jobs _targetJob = Jobs.Warrior;
    private readonly AcrType _acrType = AcrType.HighEnd; //高难专用
    private readonly int _minLevel = 70;
    private readonly int _maxLevel = 100;
    
    private readonly List<SlotResolverData> _SlotResolvers =
    [
        new(new Base(),SlotMode.Gcd),
    ];
    
    public Rotation? Build(string settingFolder)
    {
        WarSettings.Build(settingFolder);
        Qt.Build();
        var rot = new Rotation(_SlotResolvers)
        {
            TargetJob = _targetJob,
            AcrType = _acrType,
            MinLevel = _minLevel,
            MaxLevel = _maxLevel,
        };
        //rot.AddOpener(level => level < _minLevel ? null : new OpenerBase());
        //rot.SetRotationEventHandler(new EventHandler());
        rot.AddTriggerAction(new TriggerActionQt(), new TriggerActionHotkey());
        rot.AddTriggerCondition(new TriggerCondQt());
        rot.AddCanUseHighPrioritySlotCheck(Helper.HighPrioritySlotCheckFunc);
        return rot;
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