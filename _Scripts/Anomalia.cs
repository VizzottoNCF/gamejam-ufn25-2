using UnityEngine;

public abstract class Anomalia : MonoBehaviour
{
    public enum SalaAnomalia
    {
        Gerador, 
        Armazem, 
        Cameras,
        Cela
    }

    [Header("Anomaly Info")]
    public GameObject AnomPrefab;
    public string Name;
    public int Weight = 1; // peso default
    public SalaAnomalia SalaInstancia;

    public virtual void Ativar()
    {
        AnomalySpawner.Instance.ActivateAnomaly((int)SalaInstancia, AnomPrefab);
    }

    public virtual void Desativar()
    {
        AnomalySpawner.Instance.DeactivateAnomaly((int)SalaInstancia);
    }
}


