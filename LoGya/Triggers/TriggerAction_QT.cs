﻿using AEAssist.CombatRoutine.Trigger;
using AEAssist.GUI;
using AEAssist.Helper;
using ImGuiNET;
using LoGya.QtUI;

namespace LoGya.Triggers;

//这个类也可以完全复制 改一下上面的namespace和对QT的引用就行
public class TriggerActionQt : ITriggerAction
{
    public string DisplayName { get; } = "Dancer/QT";
    public string Remark { get; set; }
    
    public string Key = "";
    public bool Value;
    
    // 辅助数据 因为是private 所以不存档
    private int _selectIndex;
    private string[] _qtArray;

    public TriggerActionQt()
    {
        _qtArray = Qt.Instance.GetQtArray();
    }

    public bool Draw()
    {
        _selectIndex = Array.IndexOf(_qtArray, Key);
        if (_selectIndex == -1)
        {
            _selectIndex = 0;
        }
        ImGuiHelper.LeftCombo("选择Key",ref _selectIndex,_qtArray);
        Key = _qtArray[_selectIndex];
        ImGui.SameLine();
        using (new GroupWrapper())
        {
            ImGui.Checkbox("",ref Value);   
        }
        return true;
    }

    public bool Handle()
    {
        Qt.Instance.SetQt(Key, Value);
        if (WarSettings.Instance.TimeLinesDebug) LogHelper.Print("时间轴", $"{Key}QT => {Value}");
        return true;
    }
}