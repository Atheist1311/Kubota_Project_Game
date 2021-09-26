using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBase : MonoBehaviour
{
    public float rotateSpeed;
    public bool isSelectingCar;
    // Start is called before the first frame update
    void Start()
    {
        isSelectingCar = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelectingCar) { transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed); }    
    }
    public void CarSelected()
    {
        isSelectingCar = false;
    }
}
