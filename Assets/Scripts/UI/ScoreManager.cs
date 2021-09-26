using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuffState
{
  None,
  KAS,
  KIS,
}
public class ScoreManager : MonoBehaviour
{
   [SerializeField] ResultScoreManager scoreBoard;
    public int playerScore;
    public BuffState buffState;
    float buffMaxTime = 5f;
    float buffCurrentTime;

    public GameObject drone;
    public bool isDroneActive;
    float droneMaxTime = 5f;
    float droneCurrentTime;
    public bool isGreenHouseActivate;
  // Start is called before the first frame update
  void Start()
    {
       isGreenHouseActivate = false;
       scoreBoard = GameObject.Find("ScoreManager").GetComponent<ResultScoreManager>();
  }

    // Update is called once per frame
    void Update()
    {
      if(buffState == BuffState.KAS || buffState == BuffState.KIS)
      {
         buffCurrentTime -= Time.deltaTime;
         if(buffCurrentTime <=0){buffState = BuffState.None; }
      }
      if(isDroneActive)
      {
         droneCurrentTime -= Time.deltaTime;
         drone.SetActive(true);
         if(droneCurrentTime <= 0) { isDroneActive = false; drone.SetActive(false); }
      }
    }
  public void AddScore( int amout)
  {
    switch (buffState)
    {
      case BuffState.None:
        playerScore += amout;
        break;
      case BuffState.KAS:
        playerScore += (amout*2);
        break;
      case BuffState.KIS:
        playerScore += (amout*3);
        break;
    }
    scoreBoard.UpdateScore(playerScore);
  }
  public void AddBuff(BuffState addBuff)
  {
    buffState = addBuff;
    buffCurrentTime = buffMaxTime;
  }
  public void DroneActivate()
  {
    isDroneActive = true;
    droneCurrentTime = droneMaxTime;
  }
  public void GreenHouseActivate()
  {
    isGreenHouseActivate = true;
  }
  public void GreenHouseDetivate()
  {
    isGreenHouseActivate = false;
  }


}
