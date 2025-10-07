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
        if (Input.GetKeyDown(KeyCode.Alpha1)) { SwitchCamera(0); }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) { SwitchCamera(1); }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) { SwitchCamera(2); }
        else if (Input.GetKeyDown(KeyCode.Alpha4)) { SwitchCamera(3); }
    }

    private void Start()
    {
        if (cameraList.Count > 0) { SwitchCamera(0); }
    }
}
