using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] Animator transitionAnim;
    [SerializeField] GameObject transitionOff;
    [SerializeField] AudioSource win;
    [SerializeField] TextMeshProUGUI pointt;
    [SerializeField] int maxPoints = 0;

    void OnTriggerEnter2D(Collider2D other) 
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        Door door = other.GetComponent<Door>();
        if (other.tag == "Player" && player.HasKey)
        {
            win.Play();
            SawMovement sawMovement = new SawMovement();
            sawMovement.moving = false;
           
            countStars();
            nextLevel();
        }
    }

    public void countStars()
    {
        int stars;

        if (pointt != null)
        {
            string scoreString = pointt.text;

            int score = int.Parse(scoreString);

            if (score < maxPoints / 3)
            {
                stars= 1;
            }
            else if (score < 2 * maxPoints / 3)
            {
                stars= 2;
            }
            else if (score == 0)
            {
                stars = 0;
            }
            else
            {
                stars= 3;
            }

            string sceneName = SceneManager.GetActiveScene().name;
            Debug.Log("Ten Cua Scene Hien Tai: " + sceneName);
            PlayerPrefs.SetInt(sceneName, stars);
            PlayerPrefs.Save();
            int a= PlayerPrefs.GetInt("Level"+ " " + (SceneManager.GetActiveScene().buildIndex-1), 0);
            Debug.Log(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("So sao nhan duoc la : "+ a);
        }
    }

    public void nextLevel()
    {
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
        CoinPickup coinPickup = new CoinPickup();
        coinPickup.ResetCoin();
        transitionAnim.SetTrigger("Start");
        transitionOff.SetActive(true);
    }

    
}
