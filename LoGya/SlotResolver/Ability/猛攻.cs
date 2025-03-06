using AEAssist;
using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using AEAssist.Extension;
using LoGya.QtUI;

namespace LoGya.SlotResolver.Ability;

public class 猛攻 : ISlotResolver
{
    
    
    public int Check()
    {
        if (!Data.Spells.猛攻.GetSpell().IsReadyWithCanCast()) return -2;
        if (!Core.Me.HasAura(Data.Buffs.战场暴风)) return -3;
        if (Qt.Instance.GetQt("无位移猛攻") && Core.Me.Distance(Core.Me.GetCurrTarget()) > 0) return -4;
        if(!Qt.Instance.GetQt("猛攻")) return -5;
        
        if (Data.Spells.猛攻.GetSpell().Charges >= 2 ) return 1;
        
        if (Qt.Instance.GetQt("不留猛攻") && Data.Spells.猛攻.GetSpell().IsReadyWithCanCast()) return 2;
        
        if (Data.Spells.猛攻.GetSpell().Cooldown.TotalMilliseconds < 2600) return 3;
        
        return -1;
    }



    public void Build(Slot slot)
    {
        slot.Add(Data.Spells.猛攻.GetSpell());
    }
}