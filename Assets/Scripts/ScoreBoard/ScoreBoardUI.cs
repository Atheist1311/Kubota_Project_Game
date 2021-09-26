using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreBoardUI : MonoBehaviour
{
  DataScripableObject data;
  public List<DataScripableObject> dataList;
  int carID;
  public Image carImage;
  public TextMeshProUGUI scoreBoardText;
  public TextMeshProUGUI carIDText;
  public TextMeshProUGUI describtionText;
  [SerializeField]ResultScoreManager resultScoreManager;

  // Start is called before the first frame update
  void Start()
    {
    resultScoreManager = GameObject.Find("ScoreManager").GetComponent<ResultScoreManager>();
    carID = PlayerPrefs.GetInt("carID");
    GetCarID();
    }
    // Update is called once per frame
    void Update()
    {
    scoreBoardText.text = resultScoreManager.intPlayerScore.ToString();
    }

  void GetCarID()
  {
    switch (carID)
    {
      case 0:
        data = dataList[0];
        break;
    }
    for(int i=0; i<dataList.Count;i++)
    {
      if(i == carID)
      {
        data = dataList[i];
        carImage.sprite = dataList[i].carSprite;
        carIDText.text = dataList[i].carName;
        describtionText.text = dataList[i].carDescribtion;
      }
    }
  }
}
