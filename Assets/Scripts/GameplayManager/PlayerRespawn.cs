using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform playerTransform;
    public CarController playerController;
    public Vector3 playerVector3;
    public float distanceZ;
    float timeDelay = 1f;
    public CarController carController;
    // Start is called before the first frame update
    void Start()
    {
        distanceZ = playerVector3.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerVector3 = playerTransform.transform.position;

        if(playerVector3.z > distanceZ)
        {
            distanceZ = playerVector3.z;
        }
       /* if(playerVector3.z - distanceZ < (-15))
        {
            RespawnPlayer();
        }*/
        if (playerTransform.transform.rotation.z > 0.85f || playerTransform.transform.rotation.z < -0.85f)
        {
           RespawnPlayer();
        }
      /*  if(playerTransform.transform.rotation.y <= -0.258819f)
        {
          playerTransform.localRotation = Quaternion.Euler(0, -30, 0);
            Debug.Log("Max Left");
        }
        if(playerTransform.transform.rotation.y >= 0.258819f)
        {
          playerTransform.localRotation = Quaternion.Euler(0, 30, 0);
            Debug.Log("Max Right");
        }*/
      /*  if(carController.currentSteerAngle == 0)
        {
          playerTransform.transform.rotation = transform.rotation;
        }*/
    }
    public void RespawnPlayer()
    {
        playerController.ResetMotor();
        playerTransform.transform.position = new Vector3(0,1,distanceZ);
        playerTransform.transform.rotation = transform.rotation;
    }
}
