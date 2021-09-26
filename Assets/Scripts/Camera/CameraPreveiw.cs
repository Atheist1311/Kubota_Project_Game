using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPreveiw : MonoBehaviour
{
    public CameraSwitch camera;
    public CarSelection carSelection;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<CameraSwitch>();
        camera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CarComfirmSelection()
    {
        CarCamera carCamera = carSelection.carPrefabs[carSelection.carID].GetComponent<CarCamera>();
        camera.enabled = true;
        camera.TPS_cam = carCamera.tpsTransform;
        camera.FPS_cam = carCamera.fpsTranfrom;
        camera.offset = camera.TPS_cam.transform.position;
        camera.target = carCamera.LookAtTranform;
    }
}
