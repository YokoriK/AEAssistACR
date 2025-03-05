using AEAssist;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.JobApi;
using AEAssist.Helper;
using LoGya.QtUI;


namespace LoGya.SlotResolver.GCD;

public class 飞锯狂魂 : ISlotResolver
{
    private static int 兽魂 => Core.Resolve<JobApi_Warrior>().BeastGauge;
    public int Check()
    {
        if (Core.Me.HasAura(Data.Buffs.原初的解放)) return 1;
        
        if (兽魂 < 50) return -1;
        if(!Core.Me.HasAura(Data.Buffs.战场暴风)) return -2;
        
        if (兽魂 >= 80) return 2;
        
        if (Qt.Instance.GetQt("倾泻资源")) return 3;
        
        return -1;
    }

    private static uint GetSpells()
    {
        var enemyCount = TargetHelper.GetNearbyEnemyCount(5);

        if (Qt.Instance.GetQt("AOE") && Core.Me.HasAura(Data.Buffs.原初的混沌) && enemyCount >= 3)
            return Data.Spells.混沌旋风;
        
        if (Qt.Instance.GetQt("AOE") && !Core.Me.HasAura(Data.Buffs.原初的混沌))
            if(Core.Me.Level >= 94 && enemyCount >= 4)
                return Data.Spells.地毁人亡;
            if(Core.Me.Level <= 94 && enemyCount >= 3)
                return Data.Spells.地毁人亡;

            return Data.Spells.狂魂.IsUnlock() && Core.Me.HasAura(Data.Buffs.原初的混沌) ? Data.Spells.狂魂 : Data.Spells.锯爆;
    }
    
    public void Build(Slot slot)
    {
        slot.Add(GetSpells().GetSpell());
    }
}