using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.CombatRoutine.Module.AILoop;
using AEAssist.Extension;
using AEAssist.Helper;
using AEAssist.JobApi;
using AEAssist.MemoryApi;
using LoGya.QtUI;
using LoGya.SlotResolver.Data;

namespace LoGya;

public class EventHandler : IRotationEventHandler
{
    public void OnResetBattle()
    {
        BattleData.Instance = new BattleData();
    }

    public async Task OnNoTarget()
    {
        await Task.CompletedTask;
    }
    
    public async Task OnPreCombat()
    {
        await Task.CompletedTask;
    }

    public void AfterSpell(Slot slot, Spell spell)
    {
        if (Spell.CreatePotion().Cooldown.TotalMilliseconds <= 40000 && Core.Me.GetCurrTarget().CurrentHpPercent() > 0.1 && WarSettings.Instance.自动控制攒资源) Qt.Instance.SetQt("倾泻资源", false);
        if (Core.Me.HasAura(49) && WarSettings.Instance.自动控制攒资源) Qt.Instance.SetQt("倾泻资源", true);
    }
    
    public void OnBattleUpdate(int currTimeInMs)
    {
        
    }
    
    public void OnEnterRotation()
    {
        
    }

    public void OnExitRotation()
    {
        
    }

    public void OnTerritoryChanged()
    {
        
    }
    
    public void OnSpellCastSuccess(Slot slot, Spell spell)
    {
       
    }
}