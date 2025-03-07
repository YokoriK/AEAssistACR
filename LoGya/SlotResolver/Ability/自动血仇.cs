using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using AEAssist.Extension;
using AEAssist;
using LoGya.SlotResolver.Data;

namespace LoGya.SlotResolver.Ability;

public class 自动血仇 : ISlotResolver
{
    public int Check()
    {
        if (!WarSettings.Instance.自动团减) return -4;
        if (!Spells.血仇.GetSpell().IsReadyWithCanCast() ) return -2;
        if (Core.Me.GetCurrTarget() == null) return -3;
        if (Core.Me.GetCurrTarget().HasAura(Buffs.血仇)) return -5;
        
        if (TargetHelper.targetCastingIsBossAOE(Core.Me.GetCurrTarget(), 5000)) return 1;
        
        return -1;
    }

    public void Build(Slot slot)
    {
        slot.Add(Spells.血仇.GetSpell());
    }
}