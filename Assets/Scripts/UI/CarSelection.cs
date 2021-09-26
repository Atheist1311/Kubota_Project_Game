using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelection : MonoBehaviour
{
    public int carID;
    public List<GameObject> carPrefabs;
    public List<ProductImage> productImages;
    public RectTransform productImagePanel;
    public Vector3 set1;
    public Vector3 set2;
    // Start is called before the first frame update
    void Start()
    {
        CheckCarID();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Previous()
    {
        if (carID <= 0)
        {
            carID = carPrefabs.Count -1;
            ChangeAnchoredPos(set2);
        }
        else
        {
            carID--;
            if(carID <4) { ChangeAnchoredPos(set1);}
        }
        CheckCarID();
    }
    public void Next()
    {
        if(carID >= carPrefabs.Count -1)
        {
            carID = 0;
            ChangeAnchoredPos(set1);
        }
        else
        {
            carID++;
            if(carID > 3){ChangeAnchoredPos(set2);}
        }
        CheckCarID();

    }
    public void CheckCarID()
    {
        for (int i = 0; i < carPrefabs.Count; i++)
        {
            if (i == carID)
            {
                carPrefabs[i].SetActive(true);
                productImages[i].isSelect = true;
                productImages[i].UpdateSelection();
            }
            else
            {
                carPrefabs[i].SetActive(false);
                productImages[i].isSelect = false;
                productImages[i].UpdateSelection();
            }
        }
    }
    public void ChangeAnchoredPos(Vector3 pos)
    {
        productImagePanel.anchoredPosition = pos;
    }
    public void SaveCarID()
    {
        PlayerPrefs.SetInt("carID",carID);
        PlayerPrefs.Save();
    }
}
