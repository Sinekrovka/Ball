using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private Vector3 minBoundsSpawn;
    [SerializeField] private Vector3 maxBoundsSpawn;
    [SerializeField] private EnemyList lstEnemy;
    [Range(0.1f, 3f)]
    [SerializeField] private float maxtimeWaitSpawn;
    [Range(0.1f, 3f)]
    [SerializeField] private float mintimeWaitSpawn;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(mintimeWaitSpawn, maxtimeWaitSpawn));
        GameObject newEnemy = Instantiate(lstEnemy.GetRandomlistEnemies());
        newEnemy.transform.position = new Vector3(Random.Range(minBoundsSpawn.x, maxBoundsSpawn.x),
            maxBoundsSpawn.y + newEnemy.transform.localScale.y / 2, maxBoundsSpawn.z);
        newEnemy.transform.SetParent(BrookController.Instance.GetLastBrook);
        newEnemy.GetComponent<IEnemyMoving>().Moving();
        StartCoroutine(Spawn());
    }
}
