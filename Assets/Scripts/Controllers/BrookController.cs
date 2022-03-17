using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BrookController : MonoBehaviour
{
    [SerializeField] private Transform brook;
    
    public static BrookController Instance;

    private List<Transform> brookQueeq;
    private int brookCounts;
    private Transform lastBrookObject;

    private void Awake()
    {
        Instance = this;
        brookQueeq = new List<Transform>();
        brookCounts = brook.childCount;

        for (int i = 0; i < brookCounts; ++i)
        {
            brookQueeq.Add(brook.GetChild(i));
        }
        lastBrookObject = brookQueeq[brookQueeq.Count - 1];
    }

    public void MovedBrook()
    {
        Transform lessBrook = brookQueeq[0];
        Vector3 position = lessBrook.position;
        brookQueeq.RemoveAt(0);
        lessBrook.position = brookQueeq[brookQueeq.Count - 1].position;
        for (int i = 0; i < brookQueeq.Count; ++i)
        {
            Vector3 currentIndex = brookQueeq[i].position;
            brookQueeq[i].DOMove(position, PlayerMovementController.Instance.GetDuration);
            position = currentIndex;
        }
        brookQueeq.Add(lessBrook);
        lastBrookObject = brookQueeq[brookQueeq.Count - 1];
    }

    public Transform GetLastBrook => lastBrookObject;
}
