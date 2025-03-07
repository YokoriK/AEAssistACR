using AEAssist;
using AEAssist.CombatRoutine.Module;
using AEAssist.CombatRoutine;
using AEAssist.Extension;
using AEAssist.Helper;
using LoGya.QtUI;
using LoGya.SlotResolver.Data;

namespace LoGya.SlotResolver.Ability;

public class 爆发药 : ISlotResolver
{
    
    
    public int Check()
    {
        if (!Qt.Instance.GetQt("爆发药")) return -1;
        if (!ItemHelper.CheckCurrJobPotion()) return -2;
        if (WarSettings.Instance.双尽毁 && Core.Me.HasAura(Buffs.尽毁预备))
        {
            //解放前15s吃药
            if (Spells.解放.GetSpell().Cooldown.TotalMilliseconds >= 15 * 1000) return -3;
        }
        else
        {
            //解放后马上吃药
            if (Spells.解放.GetSpell().Cooldown.TotalMilliseconds <= (60 - 2.5) * 1000) return -4;
        }

        return 0;
    }



    public void Build(Slot slot)
    {
        slot.Add(Spell.CreatePotion());
    }
}