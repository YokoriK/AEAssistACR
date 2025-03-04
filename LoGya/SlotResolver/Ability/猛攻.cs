using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;

namespace LoGya.SlotResolver.Ability;

public class 猛攻 : ISlotResolver
{
    
    
    public int Check()
    {
        if(!Data.Spells.猛攻.GetSpell().IsReadyWithCanCast()) return -1;
        
        if(Data.Spells.猛攻.GetSpell().Cooldown.TotalMilliseconds < 2600) return 2;
        
        return -1;
    }



    public void Build(Slot slot)
    {
        slot.Add(Data.Spells.猛攻.GetSpell());
    }
}