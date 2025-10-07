using System.Collections.Generic;
using UnityEngine;

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
    }

    void Update()
    {
        

    }

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
    }
    #endregion
}
