using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class LoadMainScene : MonoBehaviour
{

    // Update is called once per frame
    public void ChangeMainScene()
    {
        EditorSceneManager.LoadScene(1);
    }
}
