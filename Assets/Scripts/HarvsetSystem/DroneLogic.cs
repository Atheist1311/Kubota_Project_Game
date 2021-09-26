using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneLogic : MonoBehaviour
{
  public PlayerRespawn player;
  public ScoreManager playerScoreManager;
  public Vector3 offset;
  // Start is called before the first frame update
  void Start()
    {
    player = GameObject.Find("GameController").GetComponent<PlayerRespawn>();
    playerScoreManager = GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreManager>();
  }

    // Update is called once per frame
    void Update()
    {

    }
  private void OnTriggerEnter(Collider other)
  {
    if(other.gameObject.tag == "Player")
    {
      //Drone Activate
      ScoreManager scoreManager = other.GetComponent<ScoreManager>();
      scoreManager.DroneActivate();
      Destroy(gameObject);
    }
  }
}
