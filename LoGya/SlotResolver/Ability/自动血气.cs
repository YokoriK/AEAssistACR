using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using AEAssist.Extension;
using AEAssist;

namespace LoGya.SlotResolver.Ability;

public class 自动血气 : ISlotResolver
{
    public int Check()
    {
        if (!WarSettings.Instance.自动血气) return -4;
        if (!Data.Spells.血气switch.GetSpell().IsReadyWithCanCast()) return -2;
        if (Core.Me.GetCurrTarget() == null) return -3;
        
        if (TargetHelper.targetCastingIsDeathSentenceWithTime(Core.Me.GetCurrTarget(), 40000)) return 1;
        
        return -1;
    }

    public void Build(Slot slot)
    {
        slot.Add(Data.Spells.血气switch.GetSpell());
    }
}