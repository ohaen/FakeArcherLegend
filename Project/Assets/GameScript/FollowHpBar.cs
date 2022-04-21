using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHpBar : MonoBehaviour
{
    public GameObject followObject;

    void Update()
    {
        transform.position = followObject.transform.position;
    }
}
