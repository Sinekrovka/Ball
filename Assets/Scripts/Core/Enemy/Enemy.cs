using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy: MonoBehaviour
{
    [SerializeField] private ColorsSchemeEnemy colors;
    [SerializeField] protected  float durationJump;
    [SerializeField] protected  float forceJump;
    

    protected void ReColoring()
    {
        GetComponent<Renderer>().material.color = colors.GetRandomColor();
    }
}
