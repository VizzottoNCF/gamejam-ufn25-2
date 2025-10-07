using UnityEditor;
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

    private void Start()
    {
        if (PlayerPrefs.HasKey("Master_Sound"))
        {

            LoadVolume();


        }
        else
        {
            SetVolume();

        }
    }


    public void jogar()
    {

        SceneManager.LoadScene(nomeDoLevelDoJogo);

    }

    public void SetVolume()
    {
        float volume = Volume_slider.value;
        mymixer.SetFloat("Master_Sound", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("Master_Sound", volume);
    }
    private void LoadVolume()
    {
        Volume_slider.value = PlayerPrefs.GetFloat("Master_Soud");

        SetVolume();
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
}
