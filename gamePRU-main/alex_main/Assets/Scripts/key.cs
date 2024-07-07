using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] AudioSource keyPick;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
          
            PlayerMovement player = collision.GetComponent<PlayerMovement>();
            if (player != null)
            {
                
                Debug.Log("Has key");
                player.HasKey = true;
                Destroy(gameObject);
            }
            keyPick.Play();
        }
    }
}
