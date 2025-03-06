using System.Numerics;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.CombatRoutine.View.JobView;
using AEAssist.Helper;
using AEAssist;
using AEAssist.Extension;
using LoGya.SlotResolver.Data;

namespace LoGya.QtUI.Hotkey;

public class 挑衅Hotkey : IHotkeyResolver
{
    public void Draw(Vector2 size)
    {
        HotkeyHelper.DrawSpellImage(size, Spells.挑衅);
    }

    private static int _check()
    {
        if (!Spells.挑衅.GetSpell().IsReadyWithCanCast()) return -1;
        if (Core.Me.GetCurrTarget() == null) return -2;
        if (Core.Me.Distance(Core.Me.GetCurrTarget()!) >
            SettingMgr.GetSetting<GeneralSettings>().AttackRange + 22) return -3;
        
        return 0;
    }

    public int Check()
    {
        return _check();
    }

    public void DrawExternal(Vector2 size, bool isActive)
    {
        if (_check() >= 0)
        {
            if (isActive)
            {
                HotkeyHelper.DrawActiveState(size);
            }
            else
            {
                HotkeyHelper.DrawGeneralState(size);
            }
        }
        else
        {
            HotkeyHelper.DrawDisabledState(size);
        }
        HotkeyHelper.DrawCooldownText(Spells.挑衅.GetSpell(), size);
    }

    public void Run()
    {
        if (GCDHelper.GetGCDCooldown() < 700)
            挑衅(GCDHelper.GetGCDCooldown() + 100);
    }
    
    private async Task 挑衅(int delay = 0)
    {
        if (delay > 0) 
            await Coroutine.Instance.WaitAsync(delay);

        AI.Instance.BattleData.AddSpell2NextSlot(Spells.挑衅.GetSpell());
    }
}