using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultScoreManager : MonoBehaviour
{
     [SerializeField] ScoreManager playerScoreManager;
     public int intPlayerScore;
     public TextMeshProUGUI scoreText;
     
    // Start is called before the first frame update
    void Start()
    {
      playerScoreManager = GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
     
    }
  public void UpdateScore(int amout)
  {
    intPlayerScore = amout;
    scoreText.text = amout.ToString();
  }
}
