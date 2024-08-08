using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomGrid;
using UnityEngine.InputSystem;
using TMPro;

public class SimpleGameManager : Singleton<SimpleGameManager>
{
    public UIController uiController;
    public TMP_Text debugText;
    public GameObject grid;
    public GameObject correctionMesh;
    public Texture imageCorrectionTexture;
    public Texture videoCorrectionTexture;

    private bool isCorrectionVisible = false;
    private Texture2D uvMapBoth;

    private void Start()
    {
        uiController.OpenMenu();
        //OpenMenu();
    }

    private void Update()
    {
        if(isCorrectionVisible)
        {
            SetUVTexture();
        }

        ControllerInput();
        //UIControls();
    }

    private void ControllerInput()
    {
        if (ControllerOutput.pressMenuButton)
        {
            //if (isCorrectionVisible)
            //{
            //    correctionMesh.SetActive(false);
            //    isCorrectionVisible = false;
            //}
            //OpenMenu();
            uiController.OpenMenu();
        }
    }

    private void UIControls()
    {
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            Save();
        }

        if (Keyboard.current.vKey.wasPressedThisFrame)
        {
            Recover();
        }

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            Read();
        }

        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            Play();
        }

        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            ImageCorrection();
        }

        if (Keyboard.current.xKey.wasPressedThisFrame)
        {
            RealtimeCorrection();
        }

        if (Keyboard.current.nKey.wasPressedThisFrame)
        {
            Debug.Log("ShowTexture");
            GridManager.showTexture = true;
        }

        if (Keyboard.current.mKey.wasPressedThisFrame)
        {
            Debug.Log("HideTexture");
            GridManager.showTexture = false;
        }
    }

    //public void OpenMenu()
    //{
    //    Debug.Log("OpenMenu");
    //    //mainPanel.SetActive(true);
    //    grid.SetActive(false);
    //}

    public void Play()
    {
        Debug.Log("Play");
        //mainPanel.SetActive(false);
        grid.SetActive(true);
    }   
    
    public void Quit()
    {
        Debug.Log("Quit App");
        Application.Quit();
    }

    public void Save()
    {
        Debug.Log("Save");
        Mesh storedMesh = grid.GetComponent<MeshFilter>().mesh;
        SaveAndLoad.Save(storedMesh, GenerateBoard.UVTex, "Sample");
    }

    public void Read()
    {
        Debug.Log("Read");
        grid.GetComponent<MeshFilter>().mesh = SaveAndLoad.Load("Sample");
        MoveVertexController.Initilize();
    }

    public void Recover()
    {
        Debug.Log("Recover");
        grid.GetComponent<MeshFilter>().mesh = GridGeneration.Instance().Initilize(GridGeneration.Instance().subdivisionLevel);

        GridDecoration.changed = true;

        GridManager.gridDecoration.Update(grid.GetComponent<MeshFilter>().mesh, grid.transform);
    }

    public void ResetMesh()
    {
        Debug.Log("ResetMesh");
        var gridManager = grid.GetComponent<GridManager>();
        gridManager.InitializeGrid();
    }

    public void RealtimeCorrection()
    {
        //mainPanel.SetActive(false);
        correctionMesh.SetActive(true);
        isCorrectionVisible = true;
        uvMapBoth = SaveAndLoad.ReadUV("Sample");
        correctionMesh.GetComponent<Renderer>().material.mainTexture = videoCorrectionTexture;
    }

    public void ImageCorrection()
    {
        //mainPanel.SetActive(false);
        correctionMesh.SetActive(true);
        isCorrectionVisible = true;
        uvMapBoth = SaveAndLoad.ReadUV("Sample");
        correctionMesh.GetComponent<Renderer>().material.mainTexture = imageCorrectionTexture;
    }

    private void SetUVTexture()
    {
        if (uvMapBoth != null)
        {
            correctionMesh.GetComponent<Renderer>().material.SetTexture("_UVTex", uvMapBoth);
            correctionMesh.GetComponent<Renderer>().material.SetFloat("exist", 1.0f);
            Debug.Log("Correction Applied");
            SetDebugText("Correction Applied");
        }
        else
        {
            correctionMesh.GetComponent<Renderer>().material.SetFloat("exist", 0.0f);
            Debug.Log("Correction Basic");
            SetDebugText("Correction Basic");
        }
    }

    public void SetDebugText(string text)
    {
        debugText.text = text;
    }
}
