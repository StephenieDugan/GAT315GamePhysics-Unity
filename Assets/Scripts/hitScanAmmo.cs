using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class hitScanAmmo : MonoBehaviour
{
    [SerializeField,Range(1,10)] float distance;
    [SerializeField] GameObject hitPrefab;
    [SerializeField] LayerMask layerMask = Physics.AllLayers;


    void Start()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit raycastHit, distance, layerMask))
        {
            if (hitPrefab != null)
            {
                Instantiate(hitPrefab, raycastHit.point, Quaternion.LookRotation(raycastHit.normal));
            }
        }
        

        Destroy(gameObject);
    }

  
}
