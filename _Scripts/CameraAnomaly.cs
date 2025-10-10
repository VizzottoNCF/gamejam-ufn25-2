using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraAnomaly : MonoBehaviour
{
    [Header("Canvas Variables")]
    [SerializeField] private Image blackout;

    [Header("Camera Config")]
    [SerializeField] private bool CanTakePhoto = true;
    [SerializeField] private float Cooldown = 0f;
    [SerializeField] private float CooldownDefault = 5f;
    [SerializeField] private Collider PhotoCone;
    [SerializeField] private int CameraAmmo = 3;

    [Header("Target Config")]
    [SerializeField] private LayerMask AnomalyLayer;
    [SerializeField] private LayerMask RefillLayer;

    [Header("Safezones")]
    [SerializeField] private List<Transform> SafeZone;

    private void Update()
    {
        if (CanTakePhoto && Input.GetKeyDown(KeyCode.Mouse1))
        {
            TakePhoto();
        }

        if (CameraAmmo > 0)
        {
            if (!CanTakePhoto && Cooldown < CooldownDefault) { Cooldown += Time.deltaTime; }
            else { Cooldown = 0f; CanTakePhoto = true; }
        } else { CanTakePhoto = false; }

        // interact to refill
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Interact();
        }
    }

    public void Interact()
    {
        Collider[] Hits = Physics.OverlapBox(PhotoCone.bounds.center, PhotoCone.bounds.extents, Quaternion.identity, RefillLayer);

        foreach (var hit in Hits)
        {
            Debug.Log("Hit detected: " + hit.name);
            if (((1 << hit.gameObject.layer) & RefillLayer.value) != 0)
            {
                RefillCamera();
            }
        }
    }

    public void RefillCamera()
    {
        CameraAmmo = 3;
    }
    public void TakePhoto()
    {
        print("FOTOU!");
        CameraAmmo -= 1;
        CanTakePhoto = false;
        // check if there are anomalies in the cone
        Collider[] Hits = Physics.OverlapBox(PhotoCone.bounds.center, PhotoCone.bounds.extents, Quaternion.identity, AnomalyLayer);

        bool hitAnomaly = false;

        foreach (var hit in Hits)
        {
            Debug.Log("Hit detected: " + hit.name);

            // if anomaly, call for deactivate
            print(hit.gameObject.layer);
            print(AnomalyLayer.value);
            if (((1 << hit.gameObject.layer) & AnomalyLayer.value) != 0)
            {
                Anomalia a = hit.GetComponent<Anomalia>();
                if (a != null)
                {
                    hitAnomaly = true;
                    StartCoroutine(FlashPhoto(a));
                    Debug.Log("Anomaly deactivated: " + hit.name);
                }
                else { Debug.LogWarning("Hit object tagged as Anomaly but no Anomalia component found."); }
            }
        }

        if (!hitAnomaly)
        {
            // play SFX of photo fail
        }
    }

    private IEnumerator FlashPhoto(Anomalia a)
    {
        // play sfx


        yield return new WaitForSeconds(1f);
        // blackout screen and call for deactivate
        blackout.enabled = true;
        
        yield return new WaitForSeconds(0.1f);

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
        yield return new WaitForSeconds(0.9f);

        // return screen to normal
        blackout.enabled = false;

    }
}