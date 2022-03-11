using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachin : MonoBehaviour
{
    public GameObject[] slotSkillObject;
    public Button[] slot;

    public Sprite[] skillSprite;

    public List<Image> slotSprite = new List<Image>();
    public List<int> startList = new List<int>();
    public List<int> resultIndexList = new List<int>();

    int ItemCnt = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
