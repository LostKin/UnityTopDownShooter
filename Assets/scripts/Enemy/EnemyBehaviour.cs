using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    Random rand = new Random();

    public float sight_length;

    public GameObject player;
    public float reaction_time;
    public GameObject current_gun;

    void Update(){
        //Facing the player

        Quaternion target_rotation = Quaternion.LookRotation(player.transform.position - current_gun.transform.position);
        target_rotation.x = 0;
        target_rotation.z = 0;

        transform.rotation = Quaternion.Slerp(transform.rotation, target_rotation, reaction_time * Time.deltaTime);

        //Moving



        //Attacking

        float dst = Vector3.Distance(player.transform.position, transform.position);

        if (dst < sight_length){
            current_gun.GetComponent<GunShoot>().Shoot();
        }

    }

}
