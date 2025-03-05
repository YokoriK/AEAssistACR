using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.Helper;


namespace LoGya.SlotResolver.GCD;

public class 飞斧 : ISlotResolver
{

    public int Check()
    {
        if(Core.Me.Distance(Core.Me.GetCurrTarget()) >  SettingMgr.GetSetting<GeneralSettings>().AttackRange) return 1;
        
        return -1;
    }
    
    public void Build(Slot slot)
    {
        slot.Add(Data.Spells.飞斧.GetSpell());
    }
}