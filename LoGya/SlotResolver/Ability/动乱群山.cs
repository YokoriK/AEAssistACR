﻿using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using AEAssist.Extension;
using AEAssist;

namespace LoGya.SlotResolver.Ability;

public class 动乱群山 : ISlotResolver
{
    
    
    public int Check()
    {
        if(!Data.Spells.动乱.GetSpell().IsReadyWithCanCast()) return -1;
        if(!Core.Me.HasAura(Data.Buffs.战场暴风)) return -2;
        
        return 0;
    }

    private static uint GetSpells()
    {
        var enemyCount = TargetHelper.GetNearbyEnemyCount(5);
        
        if(enemyCount >= 3)
            return Data.Spells.群山;

        return Data.Spells.动乱;
    }

    public void Build(Slot slot)
    {
        slot.Add(GetSpells().GetSpell());
    }
}