using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DebuffType
{
    pest,
    obstacle
}
public class DebuffLogic : MonoBehaviour
{
    public DebuffType debuffType;
    
  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      //Drone Activate
      ScoreManager scoreManager = other.GetComponent<ScoreManager>();
      if(scoreManager.isGreenHouseActivate)
      {
        scoreManager.GreenHouseDetivate();
      }
      else if(!scoreManager.isGreenHouseActivate)
      {
        CarController player = other.GetComponent<CarController>();
        if(debuffType == DebuffType.pest) { player.SlowCar(); }
        if (debuffType == DebuffType.obstacle) {
                    // Debug.Log("Car Spin"); player.LoseControl();
                    player.isCarSpin = true;
                    player.carSpinTime = 2f;
                    player.carStopTime = 2.5f;
                }   
      }
      Destroy(gameObject);
    }
  }
}
