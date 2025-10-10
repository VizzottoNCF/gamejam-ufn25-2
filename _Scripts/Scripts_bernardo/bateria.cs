using UnityEngine;

public class bateria : MonoBehaviour
{
    public static int energia = 3;
    [SerializeField] public GameObject energiaLvl1;
    [SerializeField] public GameObject energiaLvl2;
    [SerializeField] public GameObject energiaLvl3;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (energia <= 2)
        {
           energiaLvl3.SetActive(false);

        }
        if(energia <= 1)
        {

            energiaLvl2.SetActive(true);
        }
        if(energia <= 0)
        {

            energiaLvl1.SetActive(true);
        }


    }
}
