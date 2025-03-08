using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.View.JobView;
using AEAssist.CombatRoutine.View.JobView.HotkeyResolver;
using LoGya.SlotResolver.Data;
using LoGya.Common;
using LoGya.QtUI.Hotkey;

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
        Instance.SetQt("倾泻资源", true);
        Instance.SetQt("优先三锯", true);
        Instance.SetQt("动乱", true);
        Instance.SetQt("战嚎", true);
        Instance.SetQt("解放", true);
        Instance.SetQt("猛攻", true);
        Instance.SetQt("fc", true);
        Instance.SetQt("不留猛攻", false);
        Instance.SetQt("群体续红斩",false);
        Instance.SetQt("单体续红斩",false);
    }
    
    public static void Build()
    {
        Instance = new JobViewWindow(WarSettings.Instance.JobViewSave, WarSettings.Instance.Save, "LoGya战士");
        Instance.AddQt("爆发药", false);
        Instance.AddQt("AOE", true);
        Instance.AddQt("倾泻资源", true, "关闭后控制兽魂和战嚎恰好不溢出");
        Instance.AddQt("优先三锯", true, "优先打解放给的3个飞锯");
        Instance.AddQt("动乱", true);
        Instance.AddQt("战嚎", true);
        Instance.AddQt("解放", true);
        Instance.AddQt("猛攻", true);
        Instance.AddQt("fc", true);
        Instance.AddQt("不留猛攻", false, "默认留1层猛攻");
        Instance.AddQt("群体续红斩",false,"aoe2连续一次红斩，用于boss上天前等情况");
        Instance.AddQt("单体续红斩",false,"单体3连续一次红斩，用于boss上天前等情况");
        Instance.AddQt("无位移蛮荒", false, "仅在不产生位移的情况下使用蛮荒崩裂");
        Instance.AddQt("无位移猛攻", false, "仅在不产生位移的情况下使用猛攻");
        
        Instance.AddHotkey("LB", new HotKeyResolver_LB());
        Instance.AddHotkey("防击退",
            new HotKeyResolver(SpellsDefine.ArmsLength, SpellTargetType.Self, false));
        Instance.AddHotkey("疾跑", new HotKeyResolver_疾跑());
        Instance.AddHotkey("爆发药", new HotKeyResolver_Potion());
        //Instance.AddHotkey("大减", new 大减Hotkey());
        Instance.AddHotkey("大减", new HotKeyResolver(Spells.大减, SpellTargetType.Self, false));
        Instance.AddHotkey("铁壁", new HotKeyResolver(Spells.铁壁, SpellTargetType.Self, false));
        Instance.AddHotkey("血气", new HotKeyResolver(Spells.血气switch, SpellTargetType.Self, false));
        Instance.AddHotkey("死斗", new HotKeyResolver(Spells.死斗, SpellTargetType.Self, false));
        Instance.AddHotkey("战栗", new HotKeyResolver(Spells.战栗, SpellTargetType.Self, false));
        Instance.AddHotkey("泰然", new HotKeyResolver(Spells.泰然, SpellTargetType.Self, false));
        Instance.AddHotkey("血仇", new HotKeyResolver(Spells.血仇, SpellTargetType.Self, false));
        Instance.AddHotkey("摆脱", new HotKeyResolver(Spells.摆脱, SpellTargetType.Self, false));
        Instance.AddHotkey("挑衅", new 挑衅Hotkey());
        Instance.AddHotkey("退避pm2", new 退避hotkey(1));
        Instance.AddHotkey("开关盾", new HotKeyResolver(Spells.守护, SpellTargetType.Self, false));
        
        SettingTab.Build(Instance);
        
        勇猛hotkeyWindow.Build(Instance);
    }
}