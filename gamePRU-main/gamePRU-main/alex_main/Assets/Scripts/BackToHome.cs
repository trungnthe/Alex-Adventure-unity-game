using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class BackToHome : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Score;
    public void homeMainMenu()
    {
        SceneManager.LoadScene("Light Menu 1");
    }

    public void toLevelSelection()
    {
        SceneManager.LoadScene(1);
    }

    public void restartLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        CoinPickup coinPickup = new CoinPickup();
        coinPickup.ResetCoin();
        Score.text = "0";
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void pause()
    {

    }
}
