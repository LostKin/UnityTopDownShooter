using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{

    //Variables

    public GameObject bullet;
    public GameObject bullet_spawn_point;

    //Methods

    public void Shoot(){
        Transform new_bullet = Instantiate(bullet.transform, bullet_spawn_point.transform.position, Quaternion.identity);
        new_bullet.transform.rotation = transform.rotation;
    }
}
