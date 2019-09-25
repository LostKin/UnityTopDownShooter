using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{

    public float damage;
    private GameObject killable;

    public void OnTriggerEnter(Collider other){
        if (other.tag == "Killable"){
            killable = other.gameObject;
            killable.GetComponent<KillableHealth>().health -= damage;
        }
    }

}
