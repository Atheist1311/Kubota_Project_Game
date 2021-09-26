using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCamera : MonoBehaviour
{
    public Transform target;
    public Transform startOffset;
    public Vector3 offset;
    public float translateSpeed;
    public float rotationSpeed;
    // Start is called before the first frame update
    private void Awake()
    {
        Debug.Log("Awake Camera");
    }
    void Start()
    {
        offset = startOffset.transform.position;
        Debug.Log("Start Camera");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleTranslation();
        HandleRotation();
    }
    private void HandleTranslation()
    {
        var targetPosition = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition ,translateSpeed * Time.deltaTime);
    }
    private void HandleRotation()
    {
        var direction = target.position - transform.position;
        var rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation , rotation, rotationSpeed * Time.deltaTime);
    }
}
