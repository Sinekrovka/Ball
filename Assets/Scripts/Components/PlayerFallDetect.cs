using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallDetect : MonoBehaviour
{
    private MeshRenderer render;
    private ParticleSystem particleDie;
    private Vector3 startPos;

    private void Start()
    {
        render=GetComponent<MeshRenderer>();
        particleDie = GetComponentInChildren<ParticleSystem>();
        startPos = transform.position;
        GameController.Instance.restartGame += RestartGame;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(7))
        {
            Die();
        }

        if (other.gameObject.layer.Equals(9))
        {
            
        }
    }

    private void Die()
    {
        render.enabled = false;
        particleDie.Play();
        GameController.Instance.EndGame();
    }

    private void RestartGame()
    {
        transform.position = startPos;
        particleDie.Stop();
        render.enabled = true;
    }
}
