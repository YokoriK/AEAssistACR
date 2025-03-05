using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.CombatRoutine.Module.Opener;
using AEAssist.Helper;
using AEAssist.MemoryApi;
using LoGya.QtUI;
using LoGya.SlotResolver.Data;

namespace LoGya.SlotResolver.Opener;

public class Opener通用1起手 : IOpener
{
    public int StartCheck()
    {
        if(!Spells.解放.GetSpell().IsReadyWithCanCast()) return -1;
        if(!Spells.战壕.GetSpell().IsReadyWithCanCast()) return -2;
        if(!Spells.动乱.GetSpell().IsReadyWithCanCast()) return -3;
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

        const int startTime = 1000;
        countDownHandler.AddAction(300, Spells.重劈, SpellTargetType.Target);
    }

    private static void Step1(Slot slot)
    {
        if(Core.Resolve<MemApiSpell>().GetLastComboSpellId() != Spells.重劈) slot.Add(Spells.重劈.GetSpell());
        slot.Add(Spells.战壕.GetSpell());
    }
    private static void Step2(Slot slot)
    {
        slot.Add(Spells.凶残裂.GetSpell());
    }
    private static void Step3(Slot slot)
    {
        slot.Add(Spells.红斩.GetSpell());
        slot.Add(Spells.解放.GetSpell());
        if (Qt.Instance.GetQt("爆发药")) slot.Add(Spell.CreatePotion());
    }
    private static void Step4(Slot slot)
    {
        slot.Add(Spells.狂魂.GetSpell().IsUnlock() ? Spells.狂魂.GetSpell() : Spells.锯爆.GetSpell());
        slot.Add(Spells.动乱.GetSpell());
        if (Spells.战壕.GetSpell().IsReadyWithCanCast()) slot.Add(Spells.战壕.GetSpell());
    }
}