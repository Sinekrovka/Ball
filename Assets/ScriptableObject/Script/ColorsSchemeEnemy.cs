using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Colors Enemy", menuName = "MyTools/Colors Enemy", order = 51)]
public class ColorsSchemeEnemy : ScriptableObject
{
    [SerializeField] private List<Color> colors;

    public Color GetRandomColor()
    {
        return colors[Random.Range(0, colors.Count)];
    }
}
