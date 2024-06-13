

using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class RenameEditor : EditorWindow
{
    [MenuItem("Tool/Rename Editor #k")]
    public static void showwindow()
    {
        GetWindow<RenameEditor>();
    }

    public string text;
    private void OnGUI()
    {
        GUILayout.Label("İsimlerini degiştireceğiniz objeleri seçin ve yerine alacağı ismi girin");
        text = GUILayout.TextField(text);

        if (GUILayout.Button("rename editor button"))
        {
            var list = Selection.gameObjects;

            if (list.Length >0)
            {
                for (int i = 0; i < list.Length; i++)
                {
                    list[i].name = text + "_" + i;
                }
            }
           
        }
    }
}
