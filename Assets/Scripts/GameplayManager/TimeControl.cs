using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeControl : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    [SerializeField] private float maxTime;
    [SerializeField]GameController gameController;
    public CarController carController;
    public ScoreManager scoreManager;
    private float currentTime;
    [SerializeField] private GameObject scoreBoard;
    // Start is called before the first frame update
    void Start()
    {
       currentTime = maxTime;
       gameController = GetComponent<GameController>();
       scoreBoard.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    currentTime -= Time.deltaTime;
    int intTime = (int)currentTime;
      timeText.text = intTime.ToString();
    if(currentTime <= 0)
    {
      currentTime = 0;
      ScoreBoardOpen();
    }
     
    }
    public void ScoreBoardOpen()
    {
        scoreManager.enabled = false;
        carController.StopCar();
        carController.enabled = false;
        scoreBoard.SetActive(true);
    }
}
