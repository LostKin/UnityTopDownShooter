using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillableHealth : MonoBehaviour{
    //Variables

    public float health;
    public float max_health;

    public Canvas hp_bar;
    public float height;

    //Methods

    void Start(){
        health = max_health;
    }

    void Update(){
        //Rotating to Camera;

        Quaternion target_rotation = Camera.main.transform.rotation;
        target_rotation.x = target_rotation.x;
        target_rotation.y = target_rotation.y;
        target_rotation.z = target_rotation.z;
        hp_bar.transform.rotation = target_rotation;

        //Following the object
        Vector3 sup = transform.position;
        sup.y += height;
        hp_bar.transform.position = sup;

        //Synchronizing with HP

        hp_bar.GetComponent<Image>().fillAmount = health / max_health;
        if (health <= 0){
            Die();
        }
    }

    void Die(){
        Destroy(hp_bar);
        Destroy(this.gameObject);
    }
}
