using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    public Transform cameraTarget;
    public float camSpeed =6f;
    public Vector3 distance;
    public Transform lookTarget;


    private void LateUpdate() 
    {
        Vector3 dPos =cameraTarget.position+distance;
        Vector3 sPos = Vector3.Lerp(transform.position,dPos, camSpeed*Time.deltaTime);
        transform.position=sPos;
        transform.LookAt(lookTarget.position);
    }
}
