using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        // singleton
        if (Instance == null) { Instance = this.GetComponent<GameManager>(); }
        else { Destroy(gameObject); }
    }


}
