using System;
using Unity.VisualScripting;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class ReplacePrefab : EditorWindow
{
    [MenuItem("Tool/Replace Prefab Window #k")]
    public static void showwindow()
    {
        GetWindow<ReplacePrefab>();
    }

    private ScriptableObjectPool pool;
    private void OnGUI()
    {
        GUILayout.Space(10);
        GUILayout.Label("Gameobjectlerin yerini alacak \n Prefablerin seçili olduğu scriptablepool objeyi seçin !!! ");
        GUILayout.Space(10);
       pool =  EditorGUILayout.ObjectField(pool,typeof(ScriptableObjectPool)) as ScriptableObjectPool;

       if (GUILayout.Button("Objeleri Prefab ile degistirme"))
       {
           var list = FindObjectsOfType<GameObject>(true);

           foreach (var obje in pool.Objeler)
           {
               int sayac = 0;
               
               foreach (var sahne_obje in list)
               {
                   if (sahne_obje != null)
                   {
                       
                       if (sahne_obje.name.Contains(obje.name))
                       {
                          var yeniobje = PrefabUtility.InstantiatePrefab(obje);
                          yeniobje.name += "_"+sayac;
                          
                          yeniobje.GameObject().transform.position = sahne_obje.transform.position;
                          yeniobje.GameObject().transform.rotation = sahne_obje.transform.rotation;
                          yeniobje.GameObject().transform.localScale = sahne_obje.transform.localScale;

                           DestroyImmediate(sahne_obje );
                           sayac++;
                           
                       }
                   }
               }
              
           }
           

       }
    }
}