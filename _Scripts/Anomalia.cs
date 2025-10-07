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
    public string Desc;
    public int Weight = 1; // peso default
    public SalaAnomalia SalaInstancia;

    public virtual void Ativar()
    {
        AnomalySpawner.Instance.ActivateAnomaly((int)SalaInstancia, AnomPrefab);
    }

    
    public abstract void Desativar();
}


