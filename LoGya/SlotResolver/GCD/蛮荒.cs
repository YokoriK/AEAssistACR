using AEAssist;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.Helper;
using LoGya.QtUI;


namespace LoGya.SlotResolver.GCD;

public class 蛮荒 : ISlotResolver
{

    public int Check()
    {
        if (Qt.Instance.GetQt("优先三锯") && Core.Me.HasAura(Data.Buffs.原初的解放)) return -2;
        
        if (Core.Me.HasAura(Data.Buffs.蛮荒崩裂预备)) return 1;
        
        if (Core.Me.HasAura(Data.Buffs.尽毁预备)) return 2;
        
        return -1;
    }

    private static uint GetSpells()
    {
        if (Core.Me.HasAura(Data.Buffs.蛮荒崩裂预备)) return Data.Spells.蛮荒;
        
        return Data.Spells.尽毁;
    }
    
    public void Build(Slot slot)
    {
        slot.Add(GetSpells().GetSpell());
    }
}