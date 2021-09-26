using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject ProductImagePanel;
    [SerializeField] private GameObject PovPanel;
    [SerializeField] private GameObject CarConfirmButton;
    [SerializeField] private GameObject PovConfirmButton;
    private void Start()
    {
        CarConfirmButton.SetActive(true);
        PovConfirmButton.SetActive(false);
    }
    public void CarSelectionComfirm()
    {
        ProductImagePanel.SetActive(false);
        PovPanel.SetActive(true);
        CarConfirmButton.SetActive(false);
        PovConfirmButton.SetActive(true);
    }
}
