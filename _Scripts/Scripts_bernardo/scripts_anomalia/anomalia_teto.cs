using ElmanGameDevTools.PlayerSystem;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class anomalia_teto : MonoBehaviour
{
    [SerializeField] private static Collider colliderkill;
    public Transform killer;
    [SerializeField]  GameObject anomalia;
    [SerializeField]  GameObject player;
    [SerializeField] private Collider colliderdmg;
    [SerializeField] GameObject morte_menu;

    //Transform anomalia;
    bool ataca = false;
    private static Rigidbody rb;
    float speed = 10f;
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

            new WaitForSeconds(2);
            morte_menu.SetActive(true);

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
           // morte_menu.SetActive(true);
        }


    }
    
    
      



    




}
