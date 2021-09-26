using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DataScripableObject", order = 1)]
public class DataScripableObject : ScriptableObject
{
  public Sprite carSprite;
  public string carName;
  [TextArea(3, 10)]
  public string carDescribtion;
}
