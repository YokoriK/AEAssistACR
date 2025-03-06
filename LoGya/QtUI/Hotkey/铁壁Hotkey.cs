﻿using System.Numerics;
using AEAssist.CombatRoutine.Module;
using AEAssist.CombatRoutine.View.JobView;
using AEAssist.Helper;
using LoGya.SlotResolver.Data;

namespace LoGya.QtUI.Hotkey;

public class 铁壁Hotkey : IHotkeyResolver
{
    public void Draw(Vector2 size)
    {
        HotkeyHelper.DrawSpellImage(size, Spells.铁壁);
    }

    private static int _check()
    {
        if (!Spells.铁壁.GetSpell().IsReadyWithCanCast()) return -1;
        
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
        HotkeyHelper.DrawCooldownText(Spells.铁壁.GetSpell(), size);
    }

    public void Run()
    {
        AI.Instance.BattleData.AddSpell2NextSlot(Spells.铁壁.GetSpell());
    }
}