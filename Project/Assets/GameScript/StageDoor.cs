using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageDoor : MonoBehaviour
{
    //void Start()
    //{
        
    //}

    //void Update()
    //{

    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ++GameManager.Instance.currentStageNumber;

            GameManager.Instance.StageList[GameManager.Instance.currentStageNumber].parent.Find("MonsterSearch").gameObject.SetActive(true);
            GameManager.Instance.StageList[GameManager.Instance.currentStageNumber].parent.Find("Monster").gameObject.SetActive(true);
            //GameManager.Instance.StageList[GameManager.Instance.currentStageNumber].parent.GetChild(3).gameObject.SetActive(true);
            other.transform.position = GameManager.Instance.StageList[GameManager.Instance.currentStageNumber].transform.position;
            GameManager.Instance.UpdateCam();
        }
    }
}
