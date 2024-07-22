using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomGrid;
using UnityEngine.InputSystem;

public class SimpleGameManager : Singleton<SimpleGameManager>
{
    public GameObject mainPanel;
    public GameObject grid;
    public GameObject correctedImage;

    private bool isCorrectionVisible = false;

    private void Start()
    {
        OpenMenu();
    }

    private void Update()
    {
        if (ControllerOutput.pressMenuButton)
        {
            if(isCorrectionVisible)
            {
                correctedImage.SetActive(false);
                isCorrectionVisible = false;
            }
            OpenMenu();
        }


        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            Save();
        }

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            Read();
        }

        if (Keyboard.current.vKey.wasPressedThisFrame)
        {
            Recover();
        }

        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            Play();
        }

        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            Correction();
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

    public void OpenMenu()
    {
        Debug.Log("OpenMenu");
        mainPanel.SetActive(true);
        grid.SetActive(false);
    }

    public void Play()
    {
        Debug.Log("Play");
        mainPanel.SetActive(false);
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

    public void Correction()
    {
        var uvMapBoth = SaveAndLoad.ReadUV("Sample");
        correctedImage.SetActive(true);
        isCorrectionVisible = true;

        if (uvMapBoth != null)
        {
            correctedImage.GetComponent<Renderer>().material.SetTexture("_UVTex", uvMapBoth);
            correctedImage.GetComponent<Renderer>().material.SetFloat("exist", 1.0f);
            Debug.Log("Correction Applied");
        }
        else
        {
            correctedImage.GetComponent<Renderer>().material.SetFloat("exist", 0.0f);
            Debug.Log("Correction Basic");
        }
    }
}
