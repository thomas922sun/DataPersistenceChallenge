using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class StartSceneManager : MonoBehaviour
{

    public TMP_InputField playerName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNew()
    {
        ScoreRecorder.Instance.thisPlayerName = playerName.text;
        SceneManager.LoadScene(1);
        //MainManager.Instance.SaveName();
    }

    public void Exit()
    {
        //MainManager.Instance.SaveHighScore();

        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
                Application.Quit(); // original code to quit Unity player
        #endif
    }

    public void ClearHighScore()
    {
        ScoreRecorder.Instance.highestScore = 0;
        ScoreRecorder.Instance.highScorePlayerName = "null";
        ScoreRecorder.Instance.SaveHighestScore();
    }
}
