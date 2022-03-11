using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{

    public GameObject followPlayer;

    public float offsetY = 45f;
    public float offsetZ = -30f;

    Vector3 cameraPosition;

    void LateUpdate()
    {
        cameraPosition.y = (followPlayer.transform.position.y + offsetY);
        cameraPosition.z = (followPlayer.transform.position.z + offsetZ);

        transform.position = cameraPosition;
    }

    public void MoveStage()
    {
        cameraPosition.x = followPlayer.transform.position.x;
    }
}
