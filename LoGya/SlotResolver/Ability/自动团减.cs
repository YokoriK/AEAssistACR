using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using AEAssist.Extension;
using AEAssist;

namespace LoGya.SlotResolver.Ability;

public class 自动团减 : ISlotResolver
{
    public int Check()
    {
        if (!WarSettings.Instance.自动团减) return -4;
        if (!Data.Spells.摆脱.GetSpell().IsReadyWithCanCast() && !Data.Spells.血仇.GetSpell().IsReadyWithCanCast() ) return -2;
        if (Core.Me.GetCurrTarget() == null) return -3;
        
        if (TargetHelper.targetCastingIsBossAOE(Core.Me.GetCurrTarget(), 5000)) return 1;
        
        return -1;
    }

    public void Build(Slot slot)
    {
        if (!Core.Me.GetCurrTarget().HasAura(1193)) slot.Add(Data.Spells.血仇.GetSpell());
        if (!Core.Me.HasAura(1457)) slot.Add(Data.Spells.摆脱.GetSpell());
    }
}