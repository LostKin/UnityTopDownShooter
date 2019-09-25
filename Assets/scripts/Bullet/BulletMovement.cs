using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    public float speed;
    public float max_distance;


    void Update(){
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        max_distance += 1f * Time.deltaTime;
        if (max_distance >= 3){
            Destroy(this.gameObject);
        }
    }
}
