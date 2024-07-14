using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public Sprite closedDoorSprite;
    public Sprite openDoorSprite;
    public float levelLoadDelay = 1f; // Thời gian trì hoãn trước khi chuyển cảnh
    [SerializeField] Animator transitionAnim;
    [SerializeField] GameObject transitionOff;
    [SerializeField] AudioSource win;

    private SpriteRenderer spriteRenderer;
    private DoorUp doorUp;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closedDoorSprite; // Đặt sprite ban đầu là cửa đóng

        // Tìm đối tượng DoorUp trong scene
        doorUp = FindObjectOfType<DoorUp>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null && player.HasKey)
            {
                Debug.Log("Opened");
                OpenDoor();
                if (doorUp != null)
                {
                    doorUp.StartMovingDoors();
                }
                win.Play();
                SawMovement sawMovement = new SawMovement();
                sawMovement.moving = false;
               
                nextLevel();
            }
        }
    }

    public void OpenDoor()
    {
        spriteRenderer.sprite = openDoorSprite;
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
        transitionAnim.SetTrigger("Start");
        transitionOff.SetActive(true);
    }


}

