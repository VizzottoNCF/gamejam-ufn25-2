using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class CameraScreen : MonoBehaviour
{
    [SerializeField] private List<Camera> cameraList;
    [SerializeField] private RenderTexture m_rendertexture;

    public void ClearCameraOutput()
    {
        // nulls the render texture
        for (int i = 0; i < cameraList.Count; i++)
        {
            cameraList[i].targetTexture = null;
        }
    }

    public void SwitchCamera(int i)
    {
        // calls when a button is pressed
        ClearCameraOutput();

        cameraList[i].targetTexture = m_rendertexture;
    }

    private void Update()
    {
        
    }

    private void Start()
    {
        if (cameraList.Count > 0) { SwitchCamera(0); }
    }
}
