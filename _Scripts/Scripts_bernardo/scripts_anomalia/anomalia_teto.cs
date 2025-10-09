using ElmanGameDevTools.PlayerSystem;
using UnityEngine;

public class anomalia_teto : MonoBehaviour
{
    [SerializeField] private Collider colliderkill;
    public Transform killer;
    private float spd = 0;

    // Update is called once per frame

    void Update()
    {
      

    }


    private void OnTriggerEnter(Collider other)
    {
        GetComponent<PlayerController>();
        PlayerController.morreu(killer);
        //executar paralizai do player

    }
}
