using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{

    //Variables

    public GameObject bullet;
    public GameObject bullet_spawn_point;
    public float wait_time;

    private float cur_time = 0;

    //Methods

    void Update(){
        if (cur_time > 0){
            cur_time -= Time.deltaTime;
        }
    }

    public void Shoot(){
        if (cur_time <= 0){
            cur_time = wait_time;
            Transform new_bullet = Instantiate(bullet.transform, bullet_spawn_point.transform.position, Quaternion.identity);
            new_bullet.transform.rotation = transform.rotation;
        }
    }
}
