using UnityEngine;
using UnityEngine.UI;
public class AnomalyController : MonoBehaviour
{
    public Slider anomalySlider;
    public float fillrate = 1.0f;
    public float depleterate = 0.05f;

    public KeyCode togglekey = KeyCode.Space;
    private bool isanomalyactive = false;
    private float maxanomalyvalue = 1f;
    public void ActivateAnomaly()
    {
        isanomalyactive = true;
        Debug.Log("Anomalia Ativa! A barra está enchendo.");

    }
    public void DeactivateAnomaly()
    {
        isanomalyactive = false;
        Debug.Log("Anomalia Desativada! A barra está diminuindo");

    }

    public void ToggleAnomaly()
    {
        isanomalyactive = !isanomalyactive;
        if (isanomalyactive)
        {
            Debug.Log("Anomalia Ativa! A barra está enchendo.");
        }
        else
        {
            Debug.Log("Anomalia Desativada! A barra está diminuindo");
        }

    }
    void Update()
    {
        if (anomalySlider == null)
        {
            Debug.LogError("O slider da anomalia não foi atribuido!");
            return;
        }
        if (Input.GetKeyDown(togglekey))
            {
            ToggleAnomaly();
            }
        if (isanomalyactive)
        { 
            anomalySlider.value += fillrate * Time.deltaTime;
        }
        else
        {
            anomalySlider.value -= fillrate * Time.deltaTime * 2;
        }
        anomalySlider.value = Mathf.Clamp(anomalySlider.value, 0f, maxanomalyvalue);
        if (anomalySlider.value >= maxanomalyvalue)
        {
            HandleDeath();
        }
    }
    private void HandleDeath()
    {
        if (isanomalyactive)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                isanomalyactive = false;
            }
            Debug.Log("A Barra de Anomalia Está totalmente Cheia");
        }
    }
}
    