using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillableHealth : MonoBehaviour{
    //Variables

    public float health;

    //Methods
    void Update(){
        if (health <= 0){
            Die();
        }
    }

    void Die(){
        Destroy(this.gameObject);
    }
}
