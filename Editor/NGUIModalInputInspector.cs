using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace M8.NGUI {
    [CustomEditor(typeof(ModalInput))]
    public class UIModalInputNGUIInspector : UnityEditor.Editor {
        public override void OnInspectorGUI() {
            GUI.changed = false;

            ModalInput obj = target as ModalInput;

            obj.player = EditorGUILayout.IntField("Player", obj.player);

            obj.axisX = M8.EditorExt.InputBinder.GUISelectInputAction("Axis X", obj.axisX);
            obj.axisY = M8.EditorExt.InputBinder.GUISelectInputAction("Axis Y", obj.axisY);

            obj.axisDelay = EditorGUILayout.FloatField("Axis Delay", obj.axisDelay);
            obj.axisThreshold = EditorGUILayout.FloatField("Axis Threshold", obj.axisThreshold);

            obj.enter = M8.EditorExt.InputBinder.GUISelectInputAction("Enter", obj.enter);
            obj.enterAlt = M8.EditorExt.InputBinder.GUISelectInputAction("Enter Alt", obj.enterAlt);
            obj.cancel = M8.EditorExt.InputBinder.GUISelectInputAction("Cancel", obj.cancel);
            obj.cancelAlt = M8.EditorExt.InputBinder.GUISelectInputAction("Cancel Alt", obj.cancelAlt);

            if(GUI.changed)
                EditorUtility.SetDirty(target);
        }
    }
}