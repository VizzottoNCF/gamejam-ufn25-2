using System.Collections.Generic;
using UnityEngine;

public class AnomalySpawner : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField] bool anomalia_ligada = false;
    [SerializeField] int numero = 0;
    [SerializeField] int numero_1 = 0;

    [Header("Anomalias")]
    [SerializeField] private List<GameObject> Layout_Sala1;
    [SerializeField] private List<GameObject> Layout_Sala2;
    [SerializeField] private List<GameObject> Layout_Sala3;
    [SerializeField] private List<GameObject> Layout_Sala4;

    [Header("Anomalia Instanciada")]
    private GameObject Sala1_Instancia = null;
    private GameObject Sala2_Instancia = null;
    private GameObject Sala3_Instancia = null;
    private GameObject Sala4_Instancia = null;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {

            numero = Random.Range(0, 3);
            anomalia_ligada = true;
            ChangeRoom1(numero);

        }

        if (Input.GetKeyDown(KeyCode.J))
        {

            numero = Random.Range(0, 3);
            anomalia_ligada = true;
            ChangeRoom2(numero);

        }
        //  else if(Input.GetKeyDown(KeyCode.J)){


    }




    /// <summary>
    ///  SPAWNER
    /// </summary>
    /// <param name="num"></param>
    /// algoritmo para saber quando tem anomalia e quantas
    /// se for p ter anomalia em X sala
    /// rand num = algum entre 1 e Layout_Sala1.Count ---> anomalia selecionado
    /// chama ChangeRoom1(rand num)


    public void ChangeRoom1(int numero)
    {
        // limpa a versão instanciada
        if (Sala1_Instancia != null) { Destroy(Sala1_Instancia); }

        // instancia nova versão
        Sala1_Instancia = Instantiate(Layout_Sala1[numero]);
    }
    public void ChangeRoom2(int numero)
    {
        // limpa a versão instanciada
        if (Sala2_Instancia != null) { Destroy(Sala2_Instancia); }

        // instancia nova versão
        Sala2_Instancia = Instantiate(Layout_Sala2[numero]);
    }
}
