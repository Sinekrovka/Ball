using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject restartScreen;
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject controlls;
    [SerializeField] private TextMeshProUGUI textSteps;
    public static GameController Instance;
    public Action restartGame;
    private int steps;
    private void Awake()
    {
        Instance = this;
        startScreen.SetActive(true);
        controlls.SetActive(false);
        restartScreen.SetActive(false);
        steps = 0;
        textSteps.text = "Steps: " + steps;
    }

    public void EndGame()
    {
        startScreen.SetActive(false);
        restartScreen.SetActive(true);
        controlls.SetActive(false);
    }

    public void RestartGame()
    {
        restartScreen.SetActive(false);
        controlls.SetActive(true);
        startScreen.SetActive(false);
        SpawnerEnemy.Instance.StartSpawn();
        steps = 0;
        textSteps.text = "Steps: " + steps;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemi");
        for (int i = 0; i < enemies.Length; ++i)
        {
            Destroy(enemies[i]);
        }
        restartGame?.Invoke();
    }

    public void StartGame()
    {
        startScreen.SetActive(false);
        controlls.SetActive(true);
    }

    public void AddSteps()
    {
        steps += 1;
        textSteps.text = "Steps: " + steps;

    }
}
