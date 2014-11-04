using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(NGUIModalInput))]
public class UIModalInputNGUIInspector : Editor {
    public override void OnInspectorGUI() {
        GUI.changed = false;

		NGUIModalInput obj = target as NGUIModalInput;

        obj.player = EditorGUILayout.IntField("Player", obj.player);

        obj.axisX = M8.Editor.InputBinder.GUISelectInputAction("Axis X", obj.axisX);
        obj.axisY = M8.Editor.InputBinder.GUISelectInputAction("Axis Y", obj.axisY);

        obj.axisDelay = EditorGUILayout.FloatField("Axis Delay", obj.axisDelay);
        obj.axisThreshold = EditorGUILayout.FloatField("Axis Threshold", obj.axisThreshold);

        obj.enter = M8.Editor.InputBinder.GUISelectInputAction("Enter", obj.enter);
        obj.enterAlt = M8.Editor.InputBinder.GUISelectInputAction("Enter Alt", obj.enterAlt);
        obj.cancel = M8.Editor.InputBinder.GUISelectInputAction("Cancel", obj.cancel);
        obj.cancelAlt = M8.Editor.InputBinder.GUISelectInputAction("Cancel Alt", obj.cancelAlt);

        if(GUI.changed)
            EditorUtility.SetDirty(target);
    }
}
