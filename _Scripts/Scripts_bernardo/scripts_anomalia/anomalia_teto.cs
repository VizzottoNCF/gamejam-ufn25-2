using ElmanGameDevTools.PlayerSystem;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class anomalia_teto : MonoBehaviour
{
    [SerializeField] private static Collider colliderkill;
    public static Transform killer;
    [SerializeField]  GameObject anomalia;
    private float spd = 0;
    [SerializeField]  GameObject player;
    //Transform anomalia;
    NavMeshAgent anomalya;
    bool ataca = false;
   private static Rigidbody rb;
    float speed = 15f;
    // Update is called once per frame

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    

    void Update()
    {
        


        if (ataca == true) {

            // new WaitForSeconds(1);
            // rb.MovePosition(transform.position*40);
            anomalia.transform.position = Vector3.MoveTowards(anomalia.transform.position,  player.transform.position, speed * Time.deltaTime);


        }

       


           
    }

   

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")){ 
        
          //  PlayerController.morreu(killer);
            PlayerController Player = other.GetComponent<PlayerController>();
            //executar paralizai do player
            PlayerController.morreu(killer);

            ataca = true;
            // killer.transform.position = player.transform.position;

            //anomalia.transform.position = Vector3.MoveTowards(player.transform.position, anomalia.transform.position, speed  * Time.deltaTime);

        }


    }

   

  

}
