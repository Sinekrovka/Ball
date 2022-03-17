using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float jumpDistanceX;
    [SerializeField] private float jumpPower;
    [SerializeField] private float jumpDuration;
    [SerializeField] private Transform brook;
    
    public static PlayerMovementController Instance;
    private Transform player;
    private float brookY;
    private float brookZ;
    private float minBrookX;
    private float maxBrookX;
    private TrailRenderer trail;
    private bool moved;

    private void Awake()
    {
        Instance = this;
        player = GameObject.FindWithTag("Player").transform;
        brookY = brook.localScale.y / 2 + brook.position.y;
        brookZ = brook.localScale.z;
        minBrookX = brook.position.x - brook.localScale.x / 2;
        maxBrookX = brook.position.x + brook.localScale.x / 2;
        trail = player.GetComponent<TrailRenderer>();
        moved = false;
    }

    public void JumpBallX(float direction)
    {
        trail.enabled = true;
        if (!moved)
        {
            moved = true;
            int directionX;
            if (direction > 0)
            {
                directionX = -1;
            }
            else
            {
                directionX = 1;
            }

            float newPosX = player.position.x + jumpDistanceX * directionX;
            if (newPosX < minBrookX || newPosX > maxBrookX)
            {
                player.DOJump(new Vector3(newPosX, player.position.y, player.position.z), jumpPower, 
                    1, jumpDuration).SetEase(Ease.Linear).OnComplete(Fall);
            }
            else
            {
                player.DOJump(new Vector3(newPosX, player.position.y, player.position.z), jumpPower, 
                    1, jumpDuration ).OnComplete(CompleteMoved);
            }
           
        }
    }

    private void Fall()
    {
        player.DOMoveY(-3, jumpDuration).SetEase(Ease.Linear).OnComplete(FallComplete);
    }

    private void FallComplete()
    {
        CompleteMoved();
        GameController.Instance.EndGame();
    }

    private void CompleteMoved()
    {
        moved = false;
    }

    public void JumpBallUp()
    {
        if (!moved)
        {
            trail.enabled = false;
            moved = true;
            BrookController.Instance.MovedBrook();
            player.DOMove(new Vector3(player.position.x, player.position.y - brookY, player.position.z - brookZ),
                jumpDuration).OnComplete(JumpBeforeMoving);
            GameController.Instance.AddSteps();
        }
    }

    private void JumpBeforeMoving()
    {
        trail.enabled = true;
        player.DOJump(new Vector3(player.position.x, 
            player.position.y+brookY, player.position.z+brookZ), jumpPower, 1, jumpDuration ).OnComplete(CompleteMoved);
    }

    public float GetDuration => jumpDuration;

}
