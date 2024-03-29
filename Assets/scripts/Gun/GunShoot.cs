using System.Collections;
using System.Collections.Generic;
using System;
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
            //new_bullet.transform.rotation = transform.rotation;
            Quaternion target_rotation = transform.rotation;
            target_rotation.x = 0;
            target_rotation.z = 0;
            new_bullet.transform.rotation = target_rotation;
            //Console.Write(new_bullet.transform.rotation);
        }
    }
}
