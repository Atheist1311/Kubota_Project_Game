using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PovState
{
    FPS,
    TPS
}
public class CameraSwitch : MonoBehaviour
{
    public PovState cameraState;
    public KeyCode cameraSwitch_key;

    public Transform FPS_cam;
    public Transform TPS_cam;

    public Transform target;
    public Vector3 offset;
    public float translateSpeed;
    public float rotationSpeed;

    public bool isSpin = false;

    // Start is called before the first frame update
    void Start()
    {
        // offset = TPS_cam.transform.position;
        cameraSwitch_key = KeyCode.C;
    }
    void Update()
    {
        if (Input.GetKeyDown(cameraSwitch_key))
        {
            SwitchingCamera();
           // Debug.Log("Camera State : " + cameraState);
        }
    }
    private void FixedUpdate()
    {
       CurrentCameraState(cameraState);
    }
    public void CurrentCameraState(PovState cameraState)
    {
        switch (cameraState)
        {
            case PovState.FPS:
                if (FPS_cam && TPS_cam)
                {
                    FPSCamearaTranslation();
                }
                break;
            case PovState.TPS:
                if (FPS_cam && TPS_cam)
                {
                    if (!isSpin)
                    {
                        HandleTranslation();
                        HandleRotation();
                    }
                    if(isSpin)
                    {
                        HandleTranslationSpin();
                    }
                }
                break;
        }
    }
    public void SwitchingCamera()
    {
        if (cameraState == PovState.FPS)
        {
            cameraState = PovState.TPS;
            CurrentCameraState(cameraState);
        }
        else if (cameraState == PovState.TPS)
        {
            cameraState = PovState.FPS;
            CurrentCameraState(cameraState);
        }
    }
    private void HandleTranslation()
    {
        var targetPosition = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, translateSpeed * Time.deltaTime);
    }
    private void HandleTranslationSpin()
    {
       // transform.position = TPS_cam.transform.position;
        //  Vector3 currentOffset = spinTransform.transform.position;
        //  transform.position = Vector3.Lerp(transform.position, currentOffset , translateSpeed * Time.deltaTime);
    }
    private void HandleRotation()
    {
        var direction = target.position - transform.position;
        var rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
    private void FPSCamearaTranslation()
    {
        transform.position = FPS_cam.transform.position;
        transform.rotation = FPS_cam.transform.rotation;
    }
}
