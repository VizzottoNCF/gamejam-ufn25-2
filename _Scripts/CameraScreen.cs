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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchCamera(0);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            SwitchCamera(1);
        }
    }

    private void Start()
    {
        SwitchCamera(0);
    }
}
