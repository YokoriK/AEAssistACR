using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.CombatRoutine.Module.AILoop;
using AEAssist.Extension;
using AEAssist.Helper;
using AEAssist.JobApi;
using AEAssist.MemoryApi;
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
    
    public async Task OnPreCombat() //脱战时
    {
        await Task.CompletedTask;
    }

    public void AfterSpell(Slot slot, Spell spell)
    {
        
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