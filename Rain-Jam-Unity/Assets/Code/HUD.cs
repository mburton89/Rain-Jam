using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HUD : MonoBehaviour
{
    public static HUD instance;

    public TextMeshProUGUI pointsText;

    public float timeRemaining = 30;
    public TextMeshProUGUI timerText;
    private bool timerIsRunning = false;

    public Button restartButton;

    private void Awake()
    {
        instance = this;
    }

    public void UpdatePointsUI(int points)
    { 
        pointsText.SetText(points.ToString());
    }

    void Start()
    {
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                DisplayTime(timeRemaining);

                restartButton.gameObject.SetActive(true);
                WaterSpawner.Instance.canSpawnWater = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1; // Ensure the time rounds up correctly
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}", seconds);
    }
}
