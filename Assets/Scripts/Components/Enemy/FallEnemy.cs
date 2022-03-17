using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FallEnemy : Enemy, IEnemyMoving
{
    private void Awake()
    {
        ReColoring();
    }

    public void Moving()
    {
       Vector3 newPos = new Vector3(Random.Range(-2f, 2f), transform.position.y-1f,
            transform.position.z - 1f);
      // transform.DOLocalRotate(new Vector3(transform.localRotation.x + 180, 
      //     transform.localRotation.y, transform.localRotation.z), durationJump);
       transform.DOJump(newPos, forceJump, 1, durationJump).OnComplete(Moving);
    }
}
