using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint : MonoBehaviour
{
    //Variables

    public Transform target;

    //Methods

    void Update(){
        target.position = transform.position;
    }
}
