using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderCrashFix : MonoBehaviour
{
   public PlayerRespawn player;
    // Start is called before the first frame update
    void Start()
    {
    player = GameObject.Find("GameController").GetComponent<PlayerRespawn>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  private void OnCollisionStay(Collision collision)
  {
    if (collision.transform.tag == "Player")
    {
      if (player.playerTransform.rotation.y < 0)
      {
        player.playerTransform.Rotate(0, 1, 0);
        Debug.Log("Hit Border : Left");
      }
      if (player.playerTransform.rotation.y > 0)
      {
        player.playerTransform.Rotate(0, -1, 0);
        Debug.Log("Hit Border : Right");
      }
    }
  }
 /* private void OnTriggerStay(Collider other)
  {
    if (other.transform.tag == "Player")
    {
     // player.playerTransform.Rotate(0, 1, 0);
      Debug.Log("Hit Border : Stay");
    }
  }*/
}
