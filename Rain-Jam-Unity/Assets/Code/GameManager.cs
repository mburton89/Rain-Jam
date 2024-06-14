using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int points;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (!WaterSpawner.Instance.canSpawnWater && Input.GetMouseButtonDown(0))
        { 
            RestartGame();
        }
    }

    public void AddPoint()
    { 
        points++;

        if (points > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", points);
        }

        HUD.instance.UpdatePointsUI(points);
    }

    public void DeductPoint()
    {
        points--;

        HUD.instance.UpdatePointsUI(points);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
