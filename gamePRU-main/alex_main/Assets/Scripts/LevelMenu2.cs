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

    // Start is called before the first frame update

    public static int curentLevel;
    public void openLevel(int levelID)
    {
        curentLevel= levelID;
        string levelName = "Level " + levelID;
        transition.SetTrigger("Start");
        SceneManager.LoadScene(levelName);
        transition.SetTrigger("End");
        transitionOff.SetActive(false);

    }

    private void Start()
    {
        Debug.Log("IN LEVEL MENUUUUUUUU");  
        for (int i = 0; i < levelObject.Length; i++)
        {
            int stars = PlayerPrefs.GetInt("Level"+ " " + i+1, 0);
            Debug.Log("ban nhan duoc" + stars);
            for(int j=0; j<stars;j++)
            {
                levelObject[i].stars[j].sprite = GoldenStar;
            }
        }
    }
}
