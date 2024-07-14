using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] int pointsForCoinPickup = 100;
    [SerializeField] TextMeshProUGUI scoreText;

    public static int score = 0;

    bool wasCollected = false;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            score += pointsForCoinPickup;
            Debug.Log("Coined: " + score);
            scoreText.text = score.ToString();
            AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    public void ResetCoin()
    {
        score = 0;

    }
}
