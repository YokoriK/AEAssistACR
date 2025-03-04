using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.View.JobView;
using AEAssist.CombatRoutine.View.JobView.HotkeyResolver;
using LoGya.SlotResolver.Data;
using LoGya.Common;

namespace LoGya.QtUI;

public static class Qt
{
    public static JobViewWindow Instance { get; set; }
    
    /// <summary>
    /// 除了爆发药以外都复原
    /// </summary>
    public static void Reset()
    {
        Instance.SetQt("AOE", true);
        Instance.SetQt("猛攻", true);
        Instance.SetQt("飞斧", true);
        Instance.SetQt("盾姿", false);
        Instance.SetQt("爆发药", false);
        Instance.SetQt("倾泻资源", true);
        Instance.SetQt("优先三锯", true);
    }
    
    public static void Build()
    {
        Instance = new JobViewWindow(WarSettings.Instance.JobViewSave, WarSettings.Instance.Save, "Logya战士");
        Instance.AddQt("爆发药", false);
        Instance.AddQt("猛攻", true);
        Instance.AddQt("飞斧", true);
        Instance.AddQt("盾姿", false);
        Instance.AddQt("AOE", true);
        Instance.AddQt("倾泻资源", true, "不留战壕");
        Instance.AddQt("优先三锯", true, "优先打解放给的3个飞锯");
        
        Instance.AddHotkey("LB", new HotKeyResolver_LB());
        Instance.AddHotkey("防击退",
            new HotKeyResolver(SpellsDefine.ArmsLength, SpellTargetType.Self, false));
        Instance.AddHotkey("疾跑", new HotKeyResolver_疾跑());
        Instance.AddHotkey("爆发药", new HotKeyResolver_Potion());
        
    }
}