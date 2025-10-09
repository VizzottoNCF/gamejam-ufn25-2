using ElmanGameDevTools.PlayerSystem;
using UnityEngine;

public class morte_pela_flor : MonoBehaviour
{
    [SerializeField] private static Collider colliderkill;
    public Transform killer;


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            //  PlayerController.morreu(killer);
            PlayerController Player = other.GetComponent<PlayerController>();
          
            PlayerController.morreu(killer);

         

           

        }


    }
}
