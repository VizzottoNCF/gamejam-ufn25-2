using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class CameraAnomaly : MonoBehaviour
{

    [Header("Camera Config")]
    [SerializeField] private bool CanTakePhoto = true;
    [SerializeField] private float Cooldown = 0f;
    [SerializeField] private float CooldownDefault = 5f;
    [SerializeField] private Collider PhotoCone;

    [Header("Target Config")]
    [SerializeField] private LayerMask AnomalyLayer;

    [Header("Safezones")]
    [SerializeField] private List<Transform> SafeZone;

    public void TakePhoto()
    {
        // check if there are anomalies in the cone
        Collider[] Hits = Physics.OverlapBox(PhotoCone.bounds.center, PhotoCone.bounds.extents, Quaternion.identity, AnomalyLayer);

        foreach (var hit in Hits)
        {
            Debug.Log("Hit detected: " + hit.name);

            // if anomaly, call for deactivate
            if (hit.CompareTag("Anomaly"))
            {
                Anomalia a = hit.GetComponent<Anomalia>();
                if (a != null)
                {
                    StartCoroutine(FlashPhoto(a));
                    Debug.Log("Anomaly deactivated: " + hit.name);
                }
                else { Debug.LogWarning("Hit object tagged as Anomaly but no Anomalia component found."); }
            }
        }
    }

    private IEnumerator FlashPhoto(Anomalia a)
    {
        // play sfx

        new WaitForSeconds(1f);
        // blackout screen and call for deactivate

        // teleport player to safe zone
        GameObject closestObj = null;
        for (int i = 0; i < SafeZone.Count; i++)
        {
            if (closestObj == null) { closestObj = SafeZone[i].gameObject; }
            if ((transform.position - SafeZone[i].transform.position).magnitude < (transform.position - closestObj.transform.position).magnitude)
            {
                closestObj = SafeZone[i].gameObject;
            }
        }
        transform.position = closestObj.transform.position;

        a.Desativar();
        new WaitForSeconds(1f);

        // return screen to normal

        return null; ;

    }
}