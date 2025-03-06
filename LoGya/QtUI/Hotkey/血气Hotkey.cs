using System.Numerics;
using AEAssist.CombatRoutine.Module;
using AEAssist.CombatRoutine.View.JobView;
using AEAssist.Helper;
using AEAssist;
using LoGya.SlotResolver.Data;

namespace LoGya.QtUI.Hotkey;

public class 血气Hotkey : IHotkeyResolver
{
    public void Draw(Vector2 size)
    {
        HotkeyHelper.DrawSpellImage(size, Spells.血气switch);
    }

    private static int _check()
    {
        if (!Spells.血气switch.GetSpell().IsReadyWithCanCast()) return -1;
        
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
        HotkeyHelper.DrawCooldownText(Spells.血气switch.GetSpell(), size);
    }

    public void Run()
    {
        if (GCDHelper.GetGCDCooldown() < 700)
            血气(GCDHelper.GetGCDCooldown() + 100);
    }
    
    private async Task 血气(int delay = 0)
    {
        if (delay > 0) 
            await Coroutine.Instance.WaitAsync(delay);

        AI.Instance.BattleData.AddSpell2NextSlot(Spells.血气switch.GetSpell());
    }
}