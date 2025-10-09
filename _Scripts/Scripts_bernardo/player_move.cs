using UnityEngine;

public class player_move : MonoBehaviour
{
    public CharacterController controller;
    [SerializeField] static bool morto = false;

    public static float speed = 12f;

    void Update()
    {
        if (morto == false)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);
        }
        else
        {
            GetComponent<mouse_look>();
           // Morte_de_Cima();
        }
    }

    public static void morreu()
    {
        morto = true;
        speed = 0;
       

        
    }
}
