using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public void GoToMain()
    {
        Debug.Log("��ư������");
        SceneManager.LoadScene(0);
    }
}
