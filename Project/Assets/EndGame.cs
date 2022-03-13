using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public void GoToMain()
    {
        Debug.Log("버튼누름요");
        SceneManager.LoadScene(0);
    }
}
