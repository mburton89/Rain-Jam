using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public TextMeshProUGUI Score;

    void Start()
    {
        startButton.onClick.AddListener(HandleStartButtonClicked);

        int highestScore = PlayerPrefs.GetInt("HighScore");
        Score.SetText("High Score: " + highestScore);
    }

    void HandleStartButtonClicked()
    {
        SceneManager.LoadScene(1);
    }
}
