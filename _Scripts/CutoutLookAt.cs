using Unity.VisualScripting;
using UnityEngine;

public class CutoutLookAt : MonoBehaviour
{
    [SerializeField] private GameObject Target;
    [SerializeField] private Vector3 _rot;
    private void Start()
    {
        if (Target == null)
        {
            Target = GameObject.FindWithTag("Player");
        }
    }
    private void Update()
    {
        //print(Vector3.Distance(transform.position, Target.transform.position) < 10f);
        if (Vector3.Distance(transform.position, Target.transform.position) > 10f)
        {
            transform.LookAt(Target.transform);
        }
        else
        {
            transform.eulerAngles = _rot;
        }
    }
}
