using System.Numerics;
using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.CombatRoutine.View.JobView;
using AEAssist.Extension;
using AEAssist.Helper;
using Data = LoGya.SlotResolver.Data;

namespace LoGya.QtUI.Hotkey;

public static class 勇猛hotkeyWindow
{
    private static HotkeyWindow WarPartnerPanel;
    private static JobViewSave myJobViewSave;

    public static void Build(JobViewWindow instance)
    {
        instance.SetUpdateAction(() =>
        {
            PartyHelper.UpdateAllies();
            if (PartyHelper.Party.Count < 1) return;

            myJobViewSave = new JobViewSave
            {
                QtHotkeySize = new Vector2(WarSettings.Instance.WarPartnerPanelIconSize),
                ShowHotkey = WarSettings.Instance.WarPartnerPanelShow,
                LockWindow = WarSettings.Instance.JobViewSave.LockWindow
            };

            WarPartnerPanel = new HotkeyWindow(myJobViewSave, "SgePartnerPanel")
            {
                HotkeyLineCount = 2
            };

            for (var i = 1; i < PartyHelper.Party.Count; i++)
            {
                var index = i;
                WarPartnerPanel?.AddHotkey($"勇猛{PartyHelper.Party[i].Name}", new 勇猛hotkey1(index));
            }

            WarPartnerPanel?.DrawHotkeyWindow(new QtStyle(WarSettings.Instance.JobViewSave));
        });
    }
}

public class 勇猛hotkey1(int index) : IHotkeyResolver
{
    private const uint SpellId = Data.Spells.勇猛;

    public void Draw(Vector2 size)
    {
        HotkeyHelper.DrawSpellImage(size, SpellId);
    }

    public void DrawExternal(Vector2 size, bool isActive)
    {
        if (_check() >= 0)
        {
            if (isActive)
            {
                HotkeyHelper.DrawActiveState(size);
            }
            else
            {
                HotkeyHelper.DrawGeneralState(size);
            }
        }
        else
        {
            HotkeyHelper.DrawDisabledState(size);
        }
        
        HotkeyHelper.DrawCooldownText(Data.Spells.勇猛.GetSpell(), size);
    }

    public int Check()
    {
        return _check();
    }

    private int _check()
    {
        if (!PartyHelper.Party[index].IsTargetable ||
            PartyHelper.Party[index].IsDead() ||
            Core.Me.Distance(PartyHelper.Party[index]) > SettingMgr.GetSetting<GeneralSettings>().AttackRange + 27 ||
            Data.Spells.勇猛.GetSpell().Cooldown.TotalMilliseconds != 0 )
            return -2;
        return 0;
    }

    public void Run()
    {
        var partyMembers = PartyHelper.Party;
        if (partyMembers.Count < index + 1)
            return;

        var slot = new Slot();
        if (Data.Spells.勇猛.GetSpell().IsReadyWithCanCast())
        {
            slot.Add(new Spell(SpellId, partyMembers[index]));
            AI.Instance.BattleData.NextSlot = slot;
        }
        else
        {
            slot.Add(new Spell(SpellId, partyMembers[index]));
            AI.Instance.BattleData.NextSlot = slot;
        }
    }
}

