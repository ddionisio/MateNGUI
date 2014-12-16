using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace M8.NGUI {
    [CustomEditor(typeof(InputClick))]
    public class NGUIInputClickInspector : UnityEditor.Editor {

        public override void OnInspectorGUI() {
            GUI.changed = false;

            InputClick input = target as InputClick;

            input.player = EditorGUILayout.IntField("Player", input.player);

            input.action = M8.EditorExt.InputBinder.GUISelectInputAction("Action", input.action);
            input.alternate = M8.EditorExt.InputBinder.GUISelectInputAction("Alt. Action", input.alternate);

            input.axisCheck = EditorGUILayout.FloatField("Axis Check", input.axisCheck);
            input.axisDelay = EditorGUILayout.FloatField("Axis Delay", input.axisDelay);

            input.checkSelected = EditorGUILayout.Toggle("Check Selected", input.checkSelected);

            if(GUI.changed)
                EditorUtility.SetDirty(target);
        }
    }
}