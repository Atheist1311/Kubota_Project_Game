using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvester : MonoBehaviour
{
    public int point;
    Vector3 startTranform;
    public Vector3 newPosition;
    private Transform trans;
   // public PlayerRespawn player;
    public Transform playerTransform;
    public ScoreManager playerScoreManager;
    bool isHarvesting;

    // Start is called before the first frame update
    void Start()
    {
      point = 1;
      trans = transform;
      isHarvesting = false;
      playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
      playerScoreManager = GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreManager>();     // startTranform = transform.position;
    }

  // Update is called once per frame
  void Update()
  {
   // Debug.Log(startTranform + " : " + transform.position);
    if (playerTransform) { newPosition = playerTransform.transform.position; }
    if(playerScoreManager)
    {
      if (playerScoreManager.isDroneActive)
      {
        float distance = Vector3.Distance(playerTransform.position, transform.position);
        if (distance <= 20)
        {
            isHarvesting = true;         
        }
      }
      if(isHarvesting)
        {
           Magnatic();
        }
     /* if (startTranform.z != trans.position.z)
      {
        // Magnatic();
        Debug.Log("Tranform Change : "+startTranform + " : " + transform.position);
      }*/
    }
   
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      playerScoreManager.AddScore(point);
      Destroy(gameObject);
    }
  }
  void Magnatic()
  {
        /* trans.position = Vector3.Lerp(trans.position, newPosition, Time.deltaTime * 15f);

         if (Mathf.Abs(newPosition.z - trans.position.z) < 0.05f)
         {
           trans.position = newPosition;

         }*/
    transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 20f);

    if (Mathf.Abs(newPosition.z - transform.position.z) < 0.1f)
    {
      transform.position = newPosition;
    }
  }

 
}
