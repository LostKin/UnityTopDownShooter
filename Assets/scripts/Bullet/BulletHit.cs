using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BulletHit : MonoBehaviour
{

    public float damage;
    public float go_through;
    private GameObject killable;

    public void OnTriggerEnter(Collider other){
        go_through -= 1;
        if (other.tag == "Killable"){
            killable = other.gameObject;
            killable.GetComponent<KillableHealth>().health -= damage;
        }else if (other.tag == "KillablePart"){
            killable = other.gameObject.transform.parent.gameObject;
            killable.GetComponent<KillableHealth>().health -= damage;
        }
        if (go_through <= 0){
            Die();
        }
    }

    public void Die(){
        Destroy(this.gameObject);
    }

}
