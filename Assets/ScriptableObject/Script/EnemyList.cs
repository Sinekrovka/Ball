using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "MyTools/List Enemies", order = 52, fileName = "List enemies")]
public class EnemyList : ScriptableObject
{
    [SerializeField] private string prefabPath;
    [SerializeField] private List<GameObject> listEnemies;
    
    #if UNITY_EDITOR

   /* public void RefreshList()
    {
        listEnemies = new List<GameObject>();
        string[] files = Directory.GetFiles(prefabPath);
        for (int i = 0; i < files.Length; ++i)
        {
            AssetDatabase.ImportAsset();
            if (!files[i].Contains("meta"))
            {
                GameObject prefab = AssetDatabase.LoadAssetAtPath(files[i], typeof(GameObject)) as GameObject;
                if (prefab != null)
                {
                    listEnemies.Add(prefab);
                }
            }
        }
    }*/

    #endif
    public GameObject GetRandomlistEnemies()
    {
        if (listEnemies.Count > 0)
        {
            return listEnemies[Random.Range(0, listEnemies.Count)];
        }
        return null;
    }
    
}
