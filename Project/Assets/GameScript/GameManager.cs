using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    public Transform startPosition;
    public GameObject playerCam;
    public Transform playerTransform;

    public List<GameObject> Mosnters;
    public List<Transform> StageList;

    public GameObject slotmachin;

    public GameObject EXPUI;
    public GameObject BossHPUI;

    public Canvas EndGameCanvas;


    public int clearStageCount = 0;
    public int currentStageNumber = 0;

    private void Update()
    {
        if (this.Mosnters.Count <=0)
        {
            StageList[currentStageNumber].parent.transform.GetChild(4).gameObject.SetActive(true);
        }
        else
        {
            StageList[currentStageNumber].parent.transform.GetChild(4).gameObject.SetActive(false);
        }
    }
    public void UpdateCam()
    {
        playerCam.GetComponent<FollowCam>().MoveStage();
    }

    public void EndGame()
    {
        Time.timeScale = 0f;
        EXPUI.SetActive(false);
        EndGameCanvas.gameObject.SetActive(true);
    }
}
