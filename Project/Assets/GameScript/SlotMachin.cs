using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachin : MonoBehaviour
{
    public Button[] slotButton;
    public Image[] slotImage;

    public Sprite[] skillSprite;

    public List<Image> slotSprite = new List<Image>();
    public List<int> startList = new List<int>();
    public List<int> resultIndexList = new List<int>();

    public PlayerInfomation playerInfomation;

    int ItemCnt = 3;
    // Start is called before the first frame update
    void Start()
    {
        resultIndexList.Clear();
        Time.timeScale = 0;
        for (int i = 0; i < ItemCnt; ++i)
        {
            int randomInt = Random.Range(0, skillSprite.Length);
            while (CheckSkill(randomInt))
            {
                randomInt = Random.Range(0, skillSprite.Length);
            }
            resultIndexList.Add(randomInt);
            slotImage[i].sprite = skillSprite[resultIndexList[i]];
        }
    }
    private void OnEnable()
    {
        Start();
    }
    private void OnDisable()
    {
        Time.timeScale = 1;
    }
    public void ClickIndex(int i)
    {
        Debug.Log(i);
        Debug.Log($"{resultIndexList[i]} 번째 스킬 선택");
        switch (resultIndexList[i])
        {
            case 0:
                playerInfomation.doubleAttack = true;
                break;
            case 1:
                playerInfomation.twinAttack = true;
                break;
            case 2:
                ++playerInfomation.damageUpCount;
                break;
            case 3:
                ++playerInfomation.attackSpeedUpCount;
                break;
            case 4:
                ++playerInfomation.moveSpeedUpCount;
                break;
            case 5:
                break;
        }
        transform.parent.gameObject.SetActive(false);
    }
    // Update is called once per frame
    //void Update()
    //{
        
    //}

    bool CheckSkill(int skillNum)
    {
        if (skillNum == 0)
        {
            return playerInfomation.doubleAttack;
        }
        if (skillNum == 1)
        {
            return playerInfomation.twinAttack;
        }

        return false;
    }
}
