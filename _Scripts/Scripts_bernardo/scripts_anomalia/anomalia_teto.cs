using ElmanGameDevTools.PlayerSystem;
using UnityEngine;
using UnityEngine.AI;

public class anomalia_teto : MonoBehaviour
{
    [SerializeField] private Collider colliderkill;
    public Transform killer;
    private float spd = 0;
    [SerializeField] Transform player;
    NavMeshAgent anomalya;
    bool ataca = false;
   // Update is called once per frame

   void Update()
    {

        if (ataca == true) {

           // new WaitForSeconds(1);

            anomalya.destination = player.position;
            ataca = false;
        }

          
        

    }


    private void OnTriggerEnter(Collider other)
    {
        GetComponent<PlayerController>();
        PlayerController.morreu(killer);
        //executar paralizai do player
         
        ataca = true;
    }

    
}
