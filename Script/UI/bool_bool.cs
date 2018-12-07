using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bool_bool : MonoBehaviour {

    public Animator animator;
    public string Name;
    public void Animator_bool(bool Bool)
    {
        animator.SetBool(Name, Bool);
    }
}
