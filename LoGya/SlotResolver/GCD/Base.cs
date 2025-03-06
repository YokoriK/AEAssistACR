using AEAssist;
using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using AEAssist.MemoryApi;
using LoGya.Common;
using LoGya.QtUI;


namespace LoGya.SlotResolver.GCD
{
    public class Base : ISlotResolver
    {
        private static uint 上个连击 => Core.Resolve<MemApiSpell>().GetLastComboSpellId();
        
        public int Check()
        {
            return 0;
        }

        private static uint GetSpells()
        {
            var enemyCount = TargetHelper.GetNearbyEnemyCount(5);

            if (Qt.Instance.GetQt("群体续红斩") && 上个连击 == Data.Spells.超压斧)
            {
                Qt.Instance.SetQt("群体续红斩", false);
                return Data.Spells.秘银暴风;
            }

            if (Qt.Instance.GetQt("群体续红斩"))
                return Data.Spells.超压斧;

            if (Qt.Instance.GetQt("单体续红斩") && 上个连击 == Data.Spells.凶残裂)
            {
                Qt.Instance.SetQt("单体续红斩", false);
                return Data.Spells.红斩;
            }
            if (Qt.Instance.GetQt("单体续红斩") && 上个连击 == Data.Spells.重劈)
                return Data.Spells.凶残裂;
            if (Qt.Instance.GetQt("单体续红斩"))
                return Data.Spells.重劈;
            
            if (Qt.Instance.GetQt("AOE") && Data.Spells.秘银暴风.IsUnlock() &&
                上个连击 == Data.Spells.超压斧 && enemyCount == 2 && Core.Me.Level == 80)
                return Data.Spells.秘银暴风;
            
            if (Qt.Instance.GetQt("AOE") && Data.Spells.超压斧.IsUnlock() &&
                enemyCount == 2 && Core.Me.Level == 80)
                return Data.Spells.超压斧;

            if (Qt.Instance.GetQt("AOE") && Data.Spells.秘银暴风.IsUnlock() &&
                上个连击 == Data.Spells.超压斧 && enemyCount >= 3)
                return Data.Spells.秘银暴风;

            if (Qt.Instance.GetQt("AOE") && Data.Spells.超压斧.IsUnlock() &&
                enemyCount >= 3)
                return Data.Spells.超压斧;
            
            if (Data.Spells.红斩.IsUnlock() && 上个连击 == Data.Spells.凶残裂 && 
                Helper.是否续红斩(Data.Buffs.战场暴风, 15000))
                return Data.Spells.红斩;
            
            if (Data.Spells.绿斩.IsUnlock() && 上个连击 == Data.Spells.凶残裂)
                return Data.Spells.绿斩;

            if (Data.Spells.凶残裂.IsUnlock() && 上个连击 == Data.Spells.重劈)
                return Data.Spells.凶残裂;

            return Data.Spells.重劈;
        }

        public void Build(Slot slot)
        {
            slot.Add(GetSpells().GetSpell());
        }
    }
}