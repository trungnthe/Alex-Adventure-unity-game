using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToHome : MonoBehaviour


{

    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    public void homeMainMenu()
    {
        SceneManager.LoadScene("Light Menu 1");
    }

    public void restartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        scoreText.text = "0";
        livesText.text = "3";

    }

    public void pause()
    {

    }
}
