using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MeMuevo))]
public class MoverEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Dame clickcito"))
        {
            var castedTarget = target as MeMuevo;
            castedTarget.Move();
        }
    }
}
