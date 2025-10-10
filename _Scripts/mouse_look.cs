using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public  class mouse_look : MonoBehaviour
{
    public Slider slider;
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;
  
    public static bool morto = false;
    void Start()
    {
        mouseSensitivity = PlayerPrefs.GetFloat("currentSensitivity", 100);
        slider.value = mouseSensitivity / 10;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        if (morto == false) {

            PlayerPrefs.SetFloat("currentSensitivity", mouseSensitivity);
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
            
            // achar a inst do audiomanager que eu quero
            // acessar ela
            // chamar a função
        }

       
    }

    public void AdjustSpeed(float newSpeed)
    {
        mouseSensitivity = newSpeed * 10;
    }


  //  public static void Morte_de_Cima(mouse_look mouse_look)
  //  {

     //   morto = true;
     //   mouse_look.transform.LookAt(killer, Vector3.up);
            
   // }
}
