using ElmanGameDevTools.PlayerSystem;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class anomalia_teto : MonoBehaviour
{
    [SerializeField] private static Collider colliderkill;
    [SerializeField] private GameObject anomalia;
    [SerializeField] private GameObject player;
    [SerializeField] private Collider colliderdmg;
    [SerializeField] private GameObject morte_menu;

    //Transform anomalia;
    bool ataca = false;
    private static Rigidbody rb;
    float speed = 10f;
    // Update is called once per frame

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        player = GameObject.FindGameObjectWithTag("Player");
    }
    

    void Update()
    {
        //if (ataca == true) {
        //    anomalia.transform.position = Vector3.MoveTowards(anomalia.transform.position,  player.transform.position, speed * Time.deltaTime);

        //    new WaitForSeconds(2);
        //    morte_menu.SetActive(true);

        //}
           
    }

   

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")){ 
            //executar paralizai do player
            PlayerController.morreu(transform);

            ataca = true;
           // morte_menu.SetActive(true);
        }


    }
    
    
      



    




}
