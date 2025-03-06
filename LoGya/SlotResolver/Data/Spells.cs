using AEAssist;

namespace LoGya.SlotResolver.Data;

public static class Spells
{
    public const uint
        重劈 = 31,
        凶残裂 = 37,
        绿斩 = 42,
        红斩 = 45,
        超压斧 = 41,
        秘银暴风 = 16462,
        飞斧 = 46,
        挑衅 = 7533,
        原初之魂 = 49,
        锯爆 = 3549,
        钢铁旋风 = 51,
        地毁人亡 = 3550,
        蛮荒 = 25753,
        守护 = 48,
        战栗 = 40,
        死斗 = 43,
        战壕 = 52,
        泰然 = 3552,
        猛攻 = 7386,
        动乱 = 7387,
        摆脱 = 7388,
        狂暴 = 38,
        解放 = 7389,
        勇猛 = 16464,
        退避 = 7537,
        直觉 = 3551,
        血气 = 25751,
        铁壁 = 7531,
        血仇 = 7535,
        群山 = 25752,
        复仇 = 44,
        戮罪 = 36923,
        混沌旋风 = 16463,
        狂魂 = 16465,
        怒震 = 36924,
        尽毁 = 36925;

    public static uint 大减 =>
        Core.Me.Level >= 92 ? 戮罪 : 复仇;

    public static uint 血气switch =>
        Core.Me.Level >= 82 ? 血气 : 直觉;
    
}