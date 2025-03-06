using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using AEAssist;
using AEAssist.Extension;
using LoGya.QtUI;

namespace LoGya.SlotResolver.Ability;

public class 解放 : ISlotResolver
{
    
    
    public int Check()
    {
        if(!Data.Spells.解放.GetSpell().IsReadyWithCanCast()) return -1;
        if(!Qt.Instance.GetQt("解放")) return -2;
        if (!Core.Me.HasAura(Data.Buffs.战场暴风)) return -3;
        
        return 0;
    }



    public void Build(Slot slot)
    {
        slot.Add(Data.Spells.解放.GetSpell());
    }
}