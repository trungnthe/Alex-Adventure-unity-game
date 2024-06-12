using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] AudioSource bgMusic;

    private void Awake()
    {
       bgMusic.Play();
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
