using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliderSystem : MonoBehaviour {
    public BiologicaSystem BiologicaSystem;
    private void OnTriggerEnter(Collider other)
    {
        //dis2 = Mathf.Sqrt(dx * dx + dy * dy + dz * dz);
        if (other.transform.tag=="Player")
            BiologicaSystem.nearby_obj.Add(other.transform);
    }
    private void OnTriggerStay(Collider other)
    {
        
    }
}
