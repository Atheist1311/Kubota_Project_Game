using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PovImage : MonoBehaviour
{
    public PovState povState;
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
