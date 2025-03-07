using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using AEAssist.CombatRoutine.View.JobView;
using AEAssist.GUI;
using Dalamud.Interface.Windowing;
using ImGuiNET;

namespace LoGya.QtUI;

public class SettingTab
{
    private static void 技能设置Box()
    {
        ImGui.Checkbox("自动团减", ref WarSettings.Instance.自动团减);
        ImGuiHelper.SetHoverTooltip("开启后，检测到目标释放aoe会自动释放血仇和摆脱");
        ImGui.Checkbox("自动控制攒资源", ref WarSettings.Instance.自动控制攒资源);
        ImGuiHelper.SetHoverTooltip("开启后，将自动控制在爆发药期间倾泻资源");
        ImGui.Checkbox("自动血气", ref WarSettings.Instance.自动血气);
        ImGuiHelper.SetHoverTooltip("开启后，检测到目标释放死刑会自动释放血气");
        ImGui.Checkbox("双尽毁", ref WarSettings.Instance.双尽毁);
        ImGuiHelper.SetHoverTooltip("是否留双尽毁打进爆发药");
    }

    public static void Build(JobViewWindow instance)
    {
        instance.AddTab("设置", Window =>
        {
            if (ImGui.CollapsingHeader("技能设置", ImGuiTreeNodeFlags.DefaultOpen))
            {
                ImGui.Dummy(new Vector2(5, 0));
                ImGui.SameLine();
                ImGui.BeginGroup();

                技能设置Box();
                
                ImGui.EndGroup();
            }
        });
    }
}