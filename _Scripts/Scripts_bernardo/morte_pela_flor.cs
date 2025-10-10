using ElmanGameDevTools.PlayerSystem;
using UnityEngine;

public class morte_pela_flor : MonoBehaviour
{
    [SerializeField] private static Collider colliderkill;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController.morreu(transform);
        }
    }
}
