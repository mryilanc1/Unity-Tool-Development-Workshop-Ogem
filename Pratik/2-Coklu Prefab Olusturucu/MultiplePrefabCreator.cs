using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class MultiplePrefabCreator : EditorWindow
{
    [MenuItem("Tool/Multiple Prefab Creator #k")]
    public static void showwindow()
    {
        GetWindow<MultiplePrefabCreator>();
    }

    public string text;
    private void OnGUI()
    {
        GUILayout.Label("Prefab'in çıktısının olacağı konumu bilgisini girin");
        text = GUILayout.TextField(text);

        if (GUILayout.Button("multiple prefab create"))
        {
            var list = Selection.gameObjects;

            foreach (var obje in list)
            {
                PrefabUtility.SaveAsPrefabAssetAndConnect(obje, text +"/"+obje.name+".prefab", InteractionMode.UserAction);
            }
          
        }
    }
}