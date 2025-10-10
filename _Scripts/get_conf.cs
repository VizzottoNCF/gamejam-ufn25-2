using ElmanGameDevTools.PlayerSystem;
using UnityEngine;

public class get_conf : MonoBehaviour
{
    public GameObject setting;
    public static bool issettingactive;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (issettingactive == false)
            {
                Pause();
            }

            else 
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        setting.SetActive(true);
        issettingactive = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume()
    {
        setting.SetActive(false);
        issettingactive = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
