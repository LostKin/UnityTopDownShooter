using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    public float speed;
    public float max_distance;

    private float cur_distance = 0;


    void Update(){
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        cur_distance += 1f * Time.deltaTime;
        if (max_distance <= cur_distance){
            Destroy(this.gameObject);
        }
    }
}
