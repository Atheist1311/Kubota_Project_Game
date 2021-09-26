using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductImage : MonoBehaviour
{
    public int imageID;
    public bool isSelect;
    [SerializeField]
    private GameObject border;

    public void UpdateSelection()
    {
        if (isSelect)
        {
            border.SetActive(true);
        }
        else if (!isSelect)
        {
            border.SetActive(false);
        }
    }
    
}
