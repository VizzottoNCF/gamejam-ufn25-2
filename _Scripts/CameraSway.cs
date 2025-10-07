using DG.Tweening;
using UnityEngine;

public class CameraSway : MonoBehaviour
{
    private Vector3 rot;
    [SerializeField] private float angle = 15f;
    private float timeToSway = 4f;
    private void Start()
    {
        rot = transform.eulerAngles;
        Sway();
    }

    private void Sway()
    {
        // recursively rotate camera
        transform.DORotate(new Vector3(rot.x, rot.y+angle, rot.z), timeToSway).SetEase(Ease.InOutSine).OnComplete(() =>
            { transform.DORotate(new Vector3(rot.x, rot.y-angle, rot.z), timeToSway).SetEase(Ease.InOutSine).OnComplete(Sway); });
    }

}
