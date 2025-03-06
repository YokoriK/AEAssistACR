using System.Numerics;
using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.CombatRoutine.View.JobView;
using AEAssist.Extension;
using AEAssist.Helper;
using Dalamud.Game.ClientState.Objects.Types;
using Data = LoGya.SlotResolver.Data;

namespace LoGya.QtUI.Hotkey;

public class 退避hotkey(int index) : IHotkeyResolver
{
    private const uint SpellId = Data.Spells.退避;

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
        
        HotkeyHelper.DrawCooldownText(Data.Spells.退避.GetSpell(), size);
    }

    public int Check()
    {
        return _check();
    }

    private int _check()
    {
        if(PartyHelper.Party.Count < 2 ) return -1;
        if (!PartyHelper.Party[index].IsTargetable ||
            PartyHelper.Party[index].IsDead() ||
            Core.Me.Distance(PartyHelper.Party[index]) > SettingMgr.GetSetting<GeneralSettings>().AttackRange + 27 ||
            Data.Spells.退避.GetSpell().Cooldown.TotalMilliseconds != 0)
            return -2;
        return 0;
    }

    public void Run()
    {
        var partyMembers = PartyHelper.Party;
        if (partyMembers.Count < 2)
            return;

        var slot = new Slot();
        if (Data.Spells.勇猛.GetSpell().IsReadyWithCanCast())
        {
            //slot.Add(Data.Spells.即刻咏唱.GetSpell());
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