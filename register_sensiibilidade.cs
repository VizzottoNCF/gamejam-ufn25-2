using UnityEngine;
using UnityEngine.UI;

public class register_sensiibilidade : MonoBehaviour
{
    public Slider slider;
    public float mouseSensitivity = 100f;

    void Start()
    {
        
        mouseSensitivity = PlayerPrefs.GetFloat("currentSensitivity", 100);
        slider.value = mouseSensitivity / 10;
       /// Cursor.lockState = CursorLockMode.Locked;
    }
   public void definir_sensibilidade()
    {
        PlayerPrefs.SetFloat("currentSensitivity", mouseSensitivity);

    }

}
