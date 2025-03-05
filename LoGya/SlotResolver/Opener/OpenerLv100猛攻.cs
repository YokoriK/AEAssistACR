﻿using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.CombatRoutine.Module.Opener;
using AEAssist.Helper;
using AEAssist.JobApi;
using LoGya.QtUI;
using LoGya.SlotResolver.Data;

namespace LoGya.SlotResolver.Opener;

public class OpenerLv100猛攻 : IOpener
{
    public int StartCheck()
    {
        if(!Data.Spells.解放.GetSpell().IsReadyWithCanCast()) return -1;
        if(!Data.Spells.战壕.GetSpell().IsReadyWithCanCast()) return -2;
        if(!Data.Spells.动乱.GetSpell().IsReadyWithCanCast()) return -3;
        return 0;
    }
    
    public int StopCheck(int index)
    {
        return -1;
    }
    
    public List<Action<Slot>> Sequence { get; } =
    [
        Step1, Step2, Step3, Step4
    ];

    public void InitCountDown(CountDownHandler countDownHandler)
    {
        Qt.Reset();

        const int startTime = 15000;
        countDownHandler.AddAction(600, Data.Spells.猛攻, SpellTargetType.Target);
    }

    private static void Step1(Slot slot)
    {
        slot.Add(Data.Spells.重劈.GetSpell());
        slot.Add(Data.Spells.战壕.GetSpell());
    }
    private static void Step2(Slot slot)
    {
        slot.Add(Data.Spells.凶残裂.GetSpell());
    }
    private static void Step3(Slot slot)
    {
        slot.Add(Data.Spells.红斩.GetSpell());
        slot.Add(Data.Spells.解放.GetSpell());
        if (Qt.Instance.GetQt("爆发药")) slot.Add(Spell.CreatePotion());
    }
    private static void Step4(Slot slot)
    {
        slot.Add(Data.Spells.狂魂.GetSpell());
        slot.Add(Data.Spells.动乱.GetSpell());
        if (Data.Spells.战壕.GetSpell().IsReadyWithCanCast()) slot.Add(Data.Spells.战壕.GetSpell());
    }
}