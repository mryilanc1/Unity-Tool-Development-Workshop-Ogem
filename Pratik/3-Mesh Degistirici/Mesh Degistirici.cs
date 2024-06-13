using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class MeshDegistirici : EditorWindow
{
    [MenuItem("Tool/MeshDegistirici")]
    public static void showwindow()
    {
        GetWindow<MeshDegistirici>();
    }

    private Mesh mesh1;
    private Mesh mesh2;
    private void OnGUI()
    {
        GUILayout.Label("Mesh Degistirici ");

        mesh1 = EditorGUILayout.ObjectField(mesh1 ,typeof(Mesh)) as Mesh;
        mesh2 = EditorGUILayout.ObjectField(mesh2 ,typeof(Mesh)) as Mesh;
        
        if (GUILayout.Button("Mesh Degistirme"))
        {
            var list = FindObjectsOfType<MeshFilter>();

            foreach (var obje in list)
            {
                if (obje.sharedMesh == mesh1)
                {
                    obje.sharedMesh = mesh2;
                    
                    EditorUtility.SetDirty(obje);
                }
               
            }
           
        }
    }
}

