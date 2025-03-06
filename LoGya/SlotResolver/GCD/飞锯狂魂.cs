using AEAssist;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.JobApi;
using AEAssist.Helper;
using AEAssist.MemoryApi;
using LoGya.Common;
using LoGya.QtUI;


namespace LoGya.SlotResolver.GCD;

public class 飞锯狂魂 : ISlotResolver
{
    private static int 兽魂 => Core.Resolve<JobApi_Warrior>().BeastGauge;
    private static uint 上个连击 => Core.Resolve<MemApiSpell>().GetLastComboSpellId();
    public int Check()
    {
        if (!Qt.Instance.GetQt("fc")) return -2;
        if (Core.Me.HasAura(Data.Buffs.原初的解放)) return 1;
        
        if (兽魂 < 50) return -1;
        
        if (兽魂 >= 90 && 上个连击 == Data.Spells.凶残裂 && !Helper.是否续红斩(Data.Buffs.战场暴风, 15000)) return 2;
        
        if(兽魂 == 100 && (上个连击 == Data.Spells.凶残裂 || 上个连击 == Data.Spells.重劈)) return 3;

        if (兽魂 >= 50 && Data.Spells.战壕.GetSpell().Cooldown.TotalMilliseconds < 10000) return 4;
        
        if (兽魂 >= 50 && Data.Spells.战壕.GetSpell().Cooldown.TotalMilliseconds < 40000 && Data.Spells.解放.GetSpell().Cooldown.TotalMilliseconds < 2500) return 5;
        
        if (Qt.Instance.GetQt("倾泻资源")) return 6;
        
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