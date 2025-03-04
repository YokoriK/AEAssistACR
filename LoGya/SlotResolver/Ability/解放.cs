using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;

namespace LoGya.SlotResolver.Ability;

public class 解放 : ISlotResolver
{
    
    
    public int Check()
    {
        if(!Data.Spells.解放.GetSpell().IsReadyWithCanCast()) return -1;
        
        return 0;
    }



    public void Build(Slot slot)
    {
        slot.Add(Data.Spells.解放.GetSpell());
    }
}