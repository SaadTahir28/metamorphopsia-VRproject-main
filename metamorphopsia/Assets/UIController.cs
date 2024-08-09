using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject[] menus;

    // We need to save information about the settings applied in each panel
    // For example that would be simply, Both Eyes, Left Eye and Right Eye
    public bool isBothEyesSelected;
    public bool isLeftEyeSelected;
    public bool isRightEyeSelected;

    public void OpenMenu()
    {
        // We will need to decide which menu to open here
        menus[0].SetActive(true);
    }

    public void CloseMenu()
    {
        // Just close all menus
        foreach (var menu in menus)
        {
            menu.SetActive(false);
        }
    }

    public void SetBothEyes()
    {
        isBothEyesSelected = !isBothEyesSelected;
    }

    public void SetLeftEye()
    {
        isLeftEyeSelected = !isLeftEyeSelected;
    }

    public void SetRightEye()
    {
        isRightEyeSelected = !isRightEyeSelected;
    }

    public void ResetSelections()
    {
        isBothEyesSelected = false;
        isLeftEyeSelected = false;
        isRightEyeSelected = false;
    }

}
