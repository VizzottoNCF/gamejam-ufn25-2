using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrincipalManager : MonoBehaviour
{

    [SerializeField]private string nomeDoLevelDoJogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelCreditos;
    [SerializeField] private GameObject painelConfig;
    [SerializeField] private AudioMixer mymixer;
    [SerializeField] private Slider Volume_slider;
    [SerializeField] private Slider Music_slider;
    [SerializeField] private Slider Sounds_slider;
    [SerializeField] private Slider slider_sensi;
    public static float mouseSensitivity = 100f;
    private void Start()
    {
       
        mouseSensitivity = PlayerPrefs.GetFloat("currentSensitivity", 100);
        slider_sensi.value = mouseSensitivity;
        Cursor.lockState = CursorLockMode.Locked;


        LoadAll();
        //if (PlayerPrefs.HasKey("Master_Sound")) 
        //{

        //    LoadVolume();


        //}
        //else
        //{
        //    SetVolume();
        //    SetMusic();
        //    SetSound();

        //}
    }


    public void LoadAll()
    {
        Volume_slider.value = PlayerPrefs.GetFloat("Master_Sound");
        Music_slider.value = PlayerPrefs.GetFloat("Music");
        Sounds_slider.value = PlayerPrefs.GetFloat("Sounds");
        slider_sensi.value = PlayerPrefs.GetFloat("currentSensitivity");
    }

    public void SaveAll()
    {
        PlayerPrefs.SetFloat("Master_Sound", Volume_slider.value);
        PlayerPrefs.SetFloat("Music", Music_slider.value);
        PlayerPrefs.SetFloat("Sounds", Sounds_slider.value);
        PlayerPrefs.SetFloat("currentSensitivity", slider_sensi.value);
    }
    public void jogar()
    {

        SceneManager.LoadScene(nomeDoLevelDoJogo);

    }
  //seta o volume
    public void SetVolume()
    {
        float volume = Volume_slider.value;
        mymixer.SetFloat("Master_Sound", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("Master_Sound", volume);
        
    }
    public void SetMusic()
    {
        
        float Music = Music_slider.value;
        mymixer.SetFloat("Music", Mathf.Log10(Music) * 20);
        PlayerPrefs.SetFloat("Music", Music);
      
    }
    public void SetSound()
    {

        float Sounds = Sounds_slider.value;
        mymixer.SetFloat("Sounds", Mathf.Log10(Sounds) * 20);
        PlayerPrefs.SetFloat("Sounds", Sounds);
    }
    private void LoadVolume()
    {
        Volume_slider.value = PlayerPrefs.GetFloat("Master_Sound");
        Music_slider.value = PlayerPrefs.GetFloat("Music");
        Sounds_slider.value = PlayerPrefs.GetFloat("Sounds");
        
        SetVolume();
        SetMusic();
        SetSound();
    }

    public void AbriConfig()
    {

        painelMenuInicial.SetActive(false);
        painelCreditos.SetActive(false);
        painelConfig.SetActive(true);
        
    }
    public void FecharConfig()
    {

        painelMenuInicial.SetActive(true);
        painelCreditos.SetActive(false);
        painelConfig.SetActive(false);

    }
    public void AbrirCreditos()
    {

        painelMenuInicial.SetActive(false);
        painelCreditos.SetActive(true);
        painelConfig.SetActive(false);

    }

    public void FecharCreditos()
    {


        painelMenuInicial.SetActive(true);
        painelCreditos.SetActive(false);
        painelConfig.SetActive(false);
    }

    public void SairJogo()
    {
        Debug.Log("Sair do jogo");
        Application.Quit();

    }
    public void AdjustSpeed(float newSpeed)
    {
        mouseSensitivity = newSpeed * 10;
    }

    

}
