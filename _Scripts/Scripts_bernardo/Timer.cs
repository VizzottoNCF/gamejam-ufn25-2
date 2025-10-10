using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TimerText;
    [SerializeField] float remainingTime;
    [SerializeField] int minutos;
    [SerializeField] int seconds;
    public static bool started = false;
    private void Start()
    {
        started = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            remainingTime += Time.deltaTime;
        }
       
        int minutos = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        TimerText.text = string.Format("{0:00}:{1:00}", minutos, seconds);
    }
}
