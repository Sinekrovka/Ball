using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SliceEnemy : Enemy, IEnemyMoving
{
    private void Awake()
    {
        ReColoring();
    }

    public void Moving()
    {
        Vector3 newPos = new Vector3(-0.5f, transform.localPosition.y, transform.localPosition.z);
        transform.DOLocalMove(newPos, durationJump).OnComplete(ReverseMoving);
    }

    private void ReverseMoving()
    {
        Vector3 newPos = new Vector3(0.5f, transform.localPosition.y, transform.localPosition.z);
        transform.DOLocalMove(newPos, durationJump).OnComplete(Moving);
    }
}
