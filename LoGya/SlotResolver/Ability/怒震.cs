using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using AEAssist.Extension;
using AEAssist;
using AEAssist.CombatRoutine;

namespace LoGya.SlotResolver.Ability;

public class 怒震 : ISlotResolver
{
    
    
    public int Check()
    {
        if(!Data.Spells.怒震.GetSpell().IsReadyWithCanCast()) return -1;
        if(Core.Me.Distance(Core.Me.GetCurrTarget()) >  SettingMgr.GetSetting<GeneralSettings>().AttackRange) return -2;
        
        return 0;
    }



    public void Build(Slot slot)
    {
        slot.Add(Data.Spells.怒震.GetSpell());
    }
}