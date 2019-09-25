using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCorrecting : MonoBehaviour
{

    public Transform player;

    void Update(){
        transform.rotation = player.rotation;
    }
}
