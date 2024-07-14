using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitt : MonoBehaviour
{

    public Sprite closedDoorSprite;
    public Sprite openDoorSprite;
    public float levelLoadDelay = 1f; // Thời gian trì hoãn trước khi chuyển cảnh

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
                UnlockNewLevel();
                StartCoroutine(LoadNextLevel());
            }
        }
    }

    private void OpenDoor()
    {
        spriteRenderer.sprite = openDoorSprite;
    }

    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0; // Quay lại cảnh đầu tiên nếu không còn cảnh nào tiếp theo
        }

        // Reset lại trạng thái cảnh trước khi chuyển cảnh
        ScenePersist scenePersist = FindObjectOfType<ScenePersist>();
        if (scenePersist != null)
        {
            scenePersist.ResetScenePersist();
        }

        SceneManager.LoadScene(nextSceneIndex);
    }
    void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}
