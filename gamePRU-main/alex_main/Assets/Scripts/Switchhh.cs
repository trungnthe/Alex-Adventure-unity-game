using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchhh : MonoBehaviour
{
    public Sprite closedDoorSprite;
    public Sprite openDoorSprite;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closedDoorSprite; // Đặt sprite ban đầu là cửa đóng
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
               
                OpenDoor();
            }
        }
    }

    private void OpenDoor()
    {
        spriteRenderer.sprite = openDoorSprite;
    }
}
