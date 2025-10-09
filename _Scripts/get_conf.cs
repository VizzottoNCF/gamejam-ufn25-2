using ElmanGameDevTools.PlayerSystem;
using UnityEngine;

public class get_conf : MonoBehaviour
{
    public GameObject setting;
    public static bool issettingactive;
    [SerializeField] GameObject morte_menu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
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

        if(PlayerController.morto == true)
        {

            morte_menu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            issettingactive = true;
        }
    }

    public void Pause()
    {
        setting.SetActive(true);
        issettingactive = true;
      //  this.GetComponent<mouse_look>().enabled = false;
        //if an error occurs make sure to delete and then add your own＜＞(Youtube doesn't allow angled brackets in the comments for some reason)
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume()
    {
        setting.SetActive(false);
        issettingactive = false;
       // this.GetComponent<mouse_look>().enabled = true;
        //if an error occurs make sure to delete and then add your own＜＞(Youtube doesn't allow angled brackets in the comments for some reason)
        Cursor.lockState = CursorLockMode.Locked;
    }
}
