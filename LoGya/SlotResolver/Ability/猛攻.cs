using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using AEAssist.JobApi;
using LoGya.QtUI;

namespace LoGya.SlotResolver.Ability;

public class 猛攻 : ISlotResolver
{
    
    
    public int Check()
    {
        if(!Data.Spells.猛攻.GetSpell().IsReadyWithCanCast()) return -1;
        
        if(Data.Spells.猛攻.GetSpell().Charges >= 2 ) return 1;
        
        if(Qt.Instance.GetQt("不留猛攻") && Data.Spells.猛攻.GetSpell().IsReadyWithCanCast()) return 2;
        
        if(Data.Spells.猛攻.GetSpell().Cooldown.TotalMilliseconds < 2600) return 3;
        
        return -1;
    }



    public void Build(Slot slot)
    {
        slot.Add(Data.Spells.猛攻.GetSpell());
    }
}