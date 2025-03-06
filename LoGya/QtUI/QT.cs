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
        Instance.SetQt("爆发药", false);
        Instance.SetQt("倾泻资源", true);
        Instance.SetQt("优先三锯", true);
        Instance.SetQt("不留猛攻", false);
    }
    
    public static void Build()
    {
        Instance = new JobViewWindow(WarSettings.Instance.JobViewSave, WarSettings.Instance.Save, "Logya战士");
        Instance.AddQt("爆发药", false);
        Instance.AddQt("AOE", true);
        Instance.AddQt("倾泻资源", true, "不留战壕，超过80兽魂才打fc");
        Instance.AddQt("优先三锯", true, "优先打解放给的3个飞锯");
        Instance.AddQt("不留猛攻", false, "默认留1层猛攻");
        
        Instance.AddHotkey("LB", new HotKeyResolver_LB());
        Instance.AddHotkey("防击退",
            new HotKeyResolver(SpellsDefine.ArmsLength, SpellTargetType.Self, false));
        Instance.AddHotkey("疾跑", new HotKeyResolver_疾跑());
        Instance.AddHotkey("爆发药", new HotKeyResolver_Potion());
        Instance.AddHotkey("大减", new 大减Hotkey());
        Instance.AddHotkey("铁壁", new 铁壁Hotkey());
        Instance.AddHotkey("血气", new 血气Hotkey());
        Instance.AddHotkey("死斗", new HotKeyResolver_NormalSpell(Spells.死斗, SpellTargetType.Self));
        Instance.AddHotkey("战栗", new 战栗Hotkey());
        Instance.AddHotkey("泰然", new 泰然Hotkey());
        Instance.AddHotkey("血仇", new 血仇Hotkey());
        Instance.AddHotkey("摆脱", new 摆脱Hotkey());
        Instance.AddHotkey("勇猛pm2", new HotKeyResolver_NormalSpell(Spells.勇猛, SpellTargetType.Pm2));
        Instance.AddHotkey("挑衅", new 挑衅Hotkey());
        Instance.AddHotkey("退避pm2", new HotKeyResolver_NormalSpell(Spells.退避, SpellTargetType.Pm2));
    }
}