using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLimitRotation : MonoBehaviour
{
   [SerializeField]private float xRotationLimit;
   [SerializeField]private float yRotationLimit;
   [SerializeField]private float zRotationLimit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.eulerAngles.x > xRotationLimit)
        {
            transform.rotation = Quaternion.identity;
            Debug.Log("Out limit X");
            // transform.localRotation = Quaternion.Euler(xRotationLimit, 0, 0);
        }

        if (transform.rotation.eulerAngles.y > yRotationLimit)
        {
            transform.rotation = Quaternion.identity;
            Debug.Log("Out limit Y");
        }

        if (transform.rotation.eulerAngles.z > zRotationLimit)
        {
            transform.rotation = Quaternion.identity;
            Debug.Log("Out limit Z");
        }
    }
}
