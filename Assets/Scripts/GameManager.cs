using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void NextScene()
    {
        //goes to next screen
        Scene activesScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activesScene.buildIndex + 1);
    }
}
