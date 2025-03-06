using AEAssist;
using AEAssist.CombatRoutine.Module;
using AEAssist.JobApi;
using AEAssist.Helper;
using LoGya.QtUI;

namespace LoGya.SlotResolver.Ability;

public class 战壕 : ISlotResolver
{
    private static int 兽魂 => Core.Resolve<JobApi_Warrior>().BeastGauge;
    
    public int Check()
    {
        if (兽魂 > 50) return -1;
        if(!Data.Spells.战壕.GetSpell().IsReadyWithCanCast()) return -2;
        if(!Qt.Instance.GetQt("战嚎")) return -3;
        
        if(Qt.Instance.GetQt("倾泻资源")) return 1;
        
        if(Data.Spells.战壕.GetSpell().Cooldown.TotalMilliseconds < 10000) return 2;
        
        return -1;
    }



    public void Build(Slot slot)
    {
        slot.Add(Data.Spells.战壕.GetSpell());
    }
}