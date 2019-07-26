using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public GameObject GoalCompletedMenu;
    public static bool inputEnabled = true;

    // Update is called once per frame
    void Update()
    {
        if ( Coin.total == 0)
        {
            GoalCompletedMenu.SetActive(true);
            inputEnabled = false;
        }
    }

    public void PlayAgainClick()
    {
        GoalCompletedMenu.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
