using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelMenu : MonoBehaviour

{
    [SerializeField] GameObject transitionOff;
    [SerializeField] Animator transition;
    // Start is called before the first frame update
    public void openLevel(int levelID) {
        string levelName= "Level " + levelID;
        transition.SetTrigger("Start");
        SceneManager.LoadScene(levelName);
        transition.SetTrigger("End");
        transitionOff.SetActive(false);

    }
}
