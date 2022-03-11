using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfomation : PlayerHealth
{
    public bool doubleAttack;
    public bool twinAttack;
    public bool reco;

    public int level;
    public int needEXP;
    public int currentEXP;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EXP"))
        {
            ++currentEXP;
            Destroy(other.transform.parent.gameObject);
            if (needEXP <= currentEXP)
            {
                LevelUp();
            }
        }
    }

    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    void LevelUp()
    {
        ++level;
        currentEXP -= needEXP;
        needEXP = needEXP +2;
    }
}
