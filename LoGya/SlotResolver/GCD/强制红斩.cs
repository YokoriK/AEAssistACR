using AEAssist;
using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using AEAssist.MemoryApi;
using LoGya.Common;
using LoGya.QtUI;


namespace LoGya.SlotResolver.GCD
{
    public class 强制红斩 : ISlotResolver
    {
        private static uint 上个连击 => Core.Resolve<MemApiSpell>().GetLastComboSpellId();
        
        public int Check()
        {
            if (Qt.Instance.GetQt("群体续红斩") || Qt.Instance.GetQt("单体续红斩")) return 1;
            return -1;
        }

        private static uint GetSpells()
        {

            if (Qt.Instance.GetQt("群体续红斩") && 上个连击 == Data.Spells.超压斧)
            {
                Qt.Instance.SetQt("群体续红斩", false);
                return Data.Spells.秘银暴风;
            }

            if (Qt.Instance.GetQt("单体续红斩") && 上个连击 == Data.Spells.凶残裂)
            {
                Qt.Instance.SetQt("单体续红斩", false);
                return Data.Spells.红斩;
            }
            if (Qt.Instance.GetQt("单体续红斩") && 上个连击 == Data.Spells.重劈)
                return Data.Spells.凶残裂;

            return Qt.Instance.GetQt("群体续红斩") ? Data.Spells.超压斧 : Data.Spells.重劈;
        }

        public void Build(Slot slot)
        {
            slot.Add(GetSpells().GetSpell());
        }
    }
}