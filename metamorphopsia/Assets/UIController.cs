using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject SecondUI;
    [SerializeField] GameObject TestAndCorrectionUI;
    [SerializeField] GameObject TestAndCorrectionUI2;
    [SerializeField] GameObject TrackingUI;
    [SerializeField] GameObject TrackingUI2;
    [SerializeField] GameObject TreatmentAndExcersisesUI;
    [SerializeField] GameObject TreatmentAndExcersisesUI2;

    // We need to save information about the settings applied in each panel
    // For example that would be simply, Both Eyes, Left Eye and Right Eye
    public bool isBothEyesSelected;
    public bool isLeftEyeSelected;
    public bool isRightEyeSelected;

    public void OpenMenu()
    {
        MainMenu.SetActive(true);
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
