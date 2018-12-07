using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Transfer : MonoBehaviour {
    [System.Serializable]
    public class enter : UnityEvent<GameObject> { }
    public enter Enter;
    public UnityEvent end;
    //public UnityEvent ;
    private void OnTriggerStay(Collider other)
    {
        Enter.Invoke(other.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        end.Invoke();
    }

}
