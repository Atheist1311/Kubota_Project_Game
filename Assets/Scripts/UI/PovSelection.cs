using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PovSelection : MonoBehaviour
{
    public PovState povState;
    public List<PovImage> povImages;
    public CameraSwitch cameraSwitch;
    private void Start()
    {
        UpdatePovSelection(0, true);
        UpdatePovSelection(1, false);
    }
    public void Previous()
    {
       switch(povState)
        {
            case PovState.FPS:
                povState = PovState.TPS;
                UpdatePovSelection(1, true);
                UpdatePovSelection(0, false);
                break;
            case PovState.TPS:
                povState = PovState.FPS;
                UpdatePovSelection(0, true);
                UpdatePovSelection(1, false);
                break;
        }
        cameraSwitch.SwitchingCamera();
    }
    public void Next()
    {
        switch (povState)
        {
            case PovState.FPS:
                povState = PovState.TPS;
                UpdatePovSelection(1, true);
                UpdatePovSelection(0, false);
                break;
            case PovState.TPS:
                povState = PovState.FPS;
                UpdatePovSelection(0, true);
                UpdatePovSelection(1, false);
                break;
        }
        cameraSwitch.SwitchingCamera();
    }
    public void UpdatePovSelection(int index , bool state)
    {
        povImages[index].isSelect = state;
        povImages[index].UpdateSelection();
    }
    public void SavePOV()
    {
        switch(povState)
        {
            case PovState.FPS :
                PlayerPrefs.SetInt("PovState", 0);
                break;
            case PovState.TPS:
                PlayerPrefs.SetInt("PovState", 1);
                break;
        }
        PlayerPrefs.Save();
    }
}
