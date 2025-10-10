using ElmanGameDevTools.PlayerSystem;
using UnityEngine;

public class get_conf : MonoBehaviour
{
    public GameObject setting;
    public static bool issettingactive;
    private GameObject MenuManager;

    private void Start()
    {
        issettingactive = false;
        MenuManager = GameObject.FindAnyObjectByType<MenuPrincipalManager>().gameObject;
    }

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
                MenuManager.GetComponent<MenuPrincipalManager>().CloseAll();
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
