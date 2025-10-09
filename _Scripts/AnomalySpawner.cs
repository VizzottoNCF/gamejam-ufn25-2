using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnomalySpawner : MonoBehaviour
{
    public static AnomalySpawner Instance;
    [Header("Salas")]
    [SerializeField] private List<GameObject> Salas; // layout padrão

    [Header("Salas Instanciada")]
    [SerializeField] private List<GameObject> SalasInstanciadas; // layouts instanciados

    [Header("Anomalias")]
    [SerializeField] private List<GameObject> AnomaliaPrefabs;
    [SerializeField] private List<GameObject> AnomaliasInstanciadas;

    [Header("Spawner Config")]
    [SerializeField] private bool gameStart = false;
    [SerializeField] private float SpawnTimer = 0f;
    [SerializeField] private float SpawnTimerDefault;

    [Header("Slider Config")]
    [SerializeField] private Slider AnomalySlider;
    [SerializeField] private float FillRate = 0.01f;
    [SerializeField] private float DepleteRate = 0.05f;
    private float MaxAnomalyValue = 1f;
    private void Awake()
    {
        // singleton
        if (Instance == null) { Instance = this.GetComponent<AnomalySpawner>(); }
        else { Destroy(gameObject); }
    }

    private void Start()
    {
        for (int i = 0; i < Salas.Count; i++)
        {
            SalasInstanciadas.Add(Salas[i]);
            SalasInstanciadas[i] = Instantiate(SalasInstanciadas[i]);
        }


        // invoke first anomaly in 5 seconds
        Invoke("CallAnomaly", 5f);
    }

    void Update()
    {
        /// quando que eu preciso chamar o spawner?
        /// timer + velocidade muda quando ja tem uma instancia? + 0 intancia = 5 seg p anomalia?

        // Once first anomaly has already been instanciated
        if (gameStart && AnomaliasInstanciadas.Count < 4)
        {
            // spawn timer loop
            // timer takes longer depending on the amount of anomalies present
            if (SpawnTimer < (SpawnTimerDefault + AnomaliasInstanciadas.Count * 10)) { SpawnTimer += Time.deltaTime; }
            else
            {
                SpawnTimer = 0f;
                CallAnomaly();
            }
        }

        if (gameStart)
        {
            // Slider health bar
            MoveSlider();
            AnomalySlider.value = Mathf.Clamp(AnomalySlider.value, 0f, MaxAnomalyValue);

            // check for death
            if (AnomalySlider.value >= MaxAnomalyValue) { HandleDeath(); }
        }
    }

    #region Slider de Anomalia

    private void MoveSlider()
    {
        if (AnomalySlider.value < 0f) { AnomalySlider.value = 0f; }

        // fill bar
        if (AnomaliasInstanciadas.Count > 0)
        {
            foreach (var anom in AnomaliasInstanciadas)
            {
                AnomalySlider.value += FillRate * Time.deltaTime;
            }
        }

        //deplete bar
        else if (AnomalySlider.value > 0f)
        {
            AnomalySlider.value -= DepleteRate * Time.deltaTime;
        }
    }

    private void BoostSlider(float val)
    {
        AnomalySlider.value += val;
    }

    private void HandleDeath()
    {
        if (!gameStart)
        {

        }
    }


    #endregion

    #region Spawner de Anomalia

    public void SelectRandomAnomaly()
    {
        int _totalWeight = 0;
        foreach (var anom in AnomaliaPrefabs)
        {
            bool shares = false;
            Anomalia a = anom.GetComponent<Anomalia>();

            // removes any anomaly that shares a room from the weight
            for (int i = 0; i < AnomaliasInstanciadas.Count; i++)
            {
                if (AnomaliasInstanciadas[i].GetComponent<Anomalia>().SalaInstancia == a.SalaInstancia)
                {
                    shares = true;
                    continue;
                }
            }
            if (shares) { continue; }
            _totalWeight += a.Weight;
        }

        int _randomValue = Random.Range(0, _totalWeight);
        int _cumulative = 0;
        foreach (var anomaly in AnomaliaPrefabs)
        {
            bool shares = false;
            Anomalia a = anomaly.GetComponent<Anomalia>();

            // removes any anomaly that shares a room from the weight
            for (int i = 0; i < AnomaliasInstanciadas.Count; i++)
            {
                if (AnomaliasInstanciadas[i].GetComponent<Anomalia>().SalaInstancia == a.SalaInstancia)
                {
                    Debug.Log("Shares with " + AnomaliasInstanciadas[i].GetComponent<Anomalia>().Name);
                    shares = true;
                    continue;
                }
            }
            if (shares) { continue; }
            _cumulative += a.Weight;
            if (_randomValue < _cumulative)
            {
                anomaly.GetComponent<Anomalia>().Ativar();
                break;
            }
        }
    }

    public void CallAnomaly()
    {
        // first use case, starts the anomaly spawn timer and slider interaction
        if (!gameStart) { gameStart = true; }

        SelectRandomAnomaly();
    }



    #endregion


    #region Instanciamento de Anomalia
    /// <summary>
    /// Activates an anomaly
    /// </summary>
    /// <param name="sala">Qual sala vai acontecer</param>
    /// <param name="anomalia">prefab da anomalia</param>
    public void ActivateAnomaly(int sala, GameObject anomalia)
    {
        // clears base layout
        GameObject basePrefab = SalasInstanciadas[sala];
        Destroy(basePrefab);

        // fills in the room with anomaly prefab
        SalasInstanciadas[sala] = Instantiate(anomalia);
        AnomaliasInstanciadas.Add(anomalia);
    }

    /// <summary>
    /// Deactivates an anomaly
    /// </summary>
    /// <param name="sala">Qual sala vai retornar ao padrão</param>
    public void DeactivateAnomaly(int sala)
    {
        // clear anomaly
        GameObject anomalyPrefab = SalasInstanciadas[sala];
        AnomaliasInstanciadas.Remove(anomalyPrefab);

        // fill in room with base layout
        SalasInstanciadas[sala] = Instantiate(Salas[sala]);
        BoostSlider(-0.2f);
    }
    #endregion
}
