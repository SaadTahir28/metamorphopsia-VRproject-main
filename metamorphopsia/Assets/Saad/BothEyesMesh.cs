using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BothEyesMesh : MonoBehaviour
{

    //Texture2D uvMapBoth;

    void Awake()
    {
        GetComponent<MeshFilter>().mesh = PlayerMesh.DisplayMesh();
    }

    //private void OnEnable()
    //{
    //    Debug.Log("Enabled Mesh");
    //    uvMapBoth = SaveAndLoad.ReadUV("Sample");
    //}

    //private void Update()
    //{
    //    SetUVTexture();
    //}

    //void SetUVTexture()
    //{
    //    if (uvMapBoth != null)
    //    {
    //        GetComponent<Renderer>().material.SetTexture("_UVTex", uvMapBoth);
    //        GetComponent<Renderer>().material.SetFloat("exist", 1.0f);
    //    }
    //    else
    //        GetComponent<Renderer>().material.SetFloat("exist", 0.0f);
    //}
}
