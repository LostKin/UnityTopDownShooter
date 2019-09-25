using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldObject : MonoBehaviour
{

    //Variables

    public Transform Current_gun;


    //Methods

    void Update(){
        Current_gun.rotation = transform.rotation;
        Current_gun.position = transform.position;
        //transform = hand;
    }
}
