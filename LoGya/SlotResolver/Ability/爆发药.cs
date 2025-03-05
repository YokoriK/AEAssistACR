using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using LoGya.QtUI;

namespace LoGya.SlotResolver.Ability;

public class 爆发药 : ISlotResolver
{
    
    
    public int Check()
    {
        if (Qt.Instance.GetQt("爆发药")) return -1;
        if (ItemHelper.CheckCurrJobPotion()) return -2;
        if (Data.Spells.解放.GetSpell().Cooldown.TotalMilliseconds <= (60 - 2.5) * 1000) return -3;
        return 0;
    }



    public void Build(Slot slot)
    {
        slot.Add(Data.Spells.怒震.GetSpell());
    }
}