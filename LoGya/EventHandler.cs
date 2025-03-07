using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
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
        if ((Core.Me.HasAura(49) || Core.Me.GetCurrTarget().CurrentHpPercent() <= 0.05) && WarSettings.Instance.自动控制攒资源)
        {
            Qt.Instance.SetQt("倾泻资源", true);
            WarSettings.Instance.攒猛攻 = false;
            WarSettings.Instance.留尽毁 = false;
        }
    }
    
    public void OnBattleUpdate(int currTimeInMs)
    {
        if(Core.Me.HasAura(49)) BattleData.Instance.上次爆发药时间 = currTimeInMs;
        if (!Core.Me.HasAura(49) && BattleData.Instance.上次爆发药时间 + 210000 <= currTimeInMs &&
            Core.Me.GetCurrTarget().CurrentHpPercent() > 0.05 && WarSettings.Instance.自动控制攒资源)
        {
            Qt.Instance.SetQt("倾泻资源", false);
            WarSettings.Instance.攒猛攻 = true;
        }

        if (!Core.Me.HasAura(49) && BattleData.Instance.上次爆发药时间 + 210000 <= currTimeInMs && WarSettings.Instance.双尽毁)
        {
            WarSettings.Instance.留尽毁 = true;
        }
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