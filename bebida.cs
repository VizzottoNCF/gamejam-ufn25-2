using UnityEngine;

public class bebida : MonoBehaviour
{
    private void OnDestroy()
    {
        AnomalySpawner.Instance.BoostSlider(-0.3f);
    }
}
