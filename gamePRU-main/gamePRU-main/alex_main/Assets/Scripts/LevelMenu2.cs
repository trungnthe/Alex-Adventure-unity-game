using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelMenu2 : MonoBehaviour
{
    public levelObject[] levelObject;
    public static int UnlockedLevel;

    [SerializeField] GameObject transitionOff;
    [SerializeField] Animator transition;
    public Sprite GoldenStar;

    // Thêm biến để lưu trạng thái mở khóa của các level
    private bool[] levelsUnlocked;
    public static int curentLevel;

    // Khởi tạo trạng thái mở khóa các level
    private void InitializeLevels()
    {
        levelsUnlocked = new bool[7]; // Giả sử bạn có 7 level

        levelsUnlocked[0] = true; // Mở khóa Level 1
        levelsUnlocked[3] = true; // Mở khóa Level 4

        // Các level khác mặc định bị khóa
        for (int i = 1; i < levelsUnlocked.Length; i++)
        {
            if (i != 3) // Bỏ qua Level 4
                levelsUnlocked[i] = false;
        }
    }

    // Kiểm tra xem level có được mở khóa hay không
    public bool IsLevelUnlocked(int level)
    {
        if (level < 1 || level > levelsUnlocked.Length)
        {
            Debug.LogError("Số level không hợp lệ.");
            return false;
        }
        return levelsUnlocked[level - 1];
    }

    // Mở khóa các level khi hoàn thành level
    public void CompleteLevel(int level)
    {
        if (level == 1)
        {
            UnlockLevels(2, 3); // Mở khóa các level 2 và 3
        }
        else if (level == 4)
        {
            UnlockLevels(5, 6, 7); // Mở khóa các level 5, 6 và 7
        }
    }

    // Mở khóa các level cụ thể
    private void UnlockLevels(params int[] levels)
    {
        foreach (int level in levels)
        {
            if (level > 0 && level <= levelsUnlocked.Length)
            {
                levelsUnlocked[level - 1] = true;
            }
        }
    }

    public void openLevel(int levelID)
    {
        if (IsLevelUnlocked(levelID))
        {
            curentLevel = levelID;
            string levelName = "Level " + levelID;
            transition.SetTrigger("Start");
            SceneManager.LoadScene(levelName);
            transition.SetTrigger("End");
            transitionOff.SetActive(false);
        }
        else
        {
            Debug.Log("Level " + levelID + " chưa được mở khóa.");
        }
    }

    private void Start()
    {
        Debug.Log("IN LEVEL MENUUUUUUUU");
        InitializeLevels();

        for (int i = 0; i < levelObject.Length; i++)
        {
            int stars = PlayerPrefs.GetInt("Level" + " " + (i + 1), 0);
            Debug.Log("Bạn nhận được " + stars + " sao cho Level " + (i + 1));
            for (int j = 0; j < stars; j++)
            {
                levelObject[i].stars[j].sprite = GoldenStar;
            }
        }
    }
}
