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

    private void Start()
    {

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
           // morte_menu.SetActive(true);
        }


    }
    
    
      



    




}
