using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables

    public GameObject Current_gun;

    public float movement_speed;
    public float strafe_speed;
    public float back_speed;
    public float hit_distance;
    public float jump_height;
    public float height;
    public LayerMask layer;

    private const float EPS = 1e-3f;
    private float mv_vert = 0;
    private float mv_hor = 0;
    private bool is_grounded;

    //private Vector3 x_dir = new Vector3();
    //private Vector3 z_dir = new Vector3();

    //Methods

    void Start(){
        //x_dir.x = 1f;
        //z_dir.z = 1f;
    }

    void Update(){

        //Player facing mouse
        Plane player_plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hit_dist = 0.0f;

        if (player_plane.Raycast(ray, out hit_dist)){
            Vector3 target_point = ray.GetPoint(hit_dist);
            Quaternion target_rotation = Quaternion.LookRotation(target_point - transform.position);
            target_rotation.x = 0;
            //target_rotation.y = 0;
            target_rotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, target_rotation, 7f * Time.deltaTime);
        }

        //Player movement

        Rigidbody rb = GetComponent<Rigidbody>();

        Vector3 vel = rb.velocity;

        if (Input.GetKeyDown(KeyCode.W)){
            mv_vert += 1;
            //vel.z = movement_speed;
            //transform.Translate(Vector3.forward * movement_speed * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.W)){
            mv_vert -= 1;
            //vel.z -= movement_speed;
            //transform.Translate(Vector3.forward * movement_speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.S)){
            mv_vert -= 1;
            //vel.z = -back_speed;
            //transform.Translate(-1 * Vector3.forward * back_speed * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.S)){
            mv_vert += 1;
            //vel.z += back_speed;
            //transform.Translate(-1 * Vector3.forward * back_speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.D)){
            mv_hor += 1;
            //vel.x = strafe_speed;
            //transform.Translate(Vector3.right * strafe_speed * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.D)){
            mv_hor -= 1;
            //vel.x -= strafe_speed;
            //transform.Translate(Vector3.right * strafe_speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.A)){
            mv_hor -= 1;
            //vel.x = -strafe_speed;
            //transform.Translate(-1 * Vector3.right * strafe_speed * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.A)){
            mv_hor += 1;
            //vel.x += strafe_speed;
            //transform.Translate(-1 * Vector3.right * strafe_speed * Time.deltaTime);
        }

        vel.z = movement_speed * mv_vert;
        vel.x = movement_speed * mv_hor;

        //Jumping

        //pos.x = 1f;
        //pos.z = 1f;

        Vector3 jump = rb.velocity;

        GroundCheck();

        if (Input.GetKey(KeyCode.Space) && is_grounded){
            jump.y = jump_height;
        }
        //rb.velocity = vel;
        if (Mathf.Abs(vel.x) + Mathf.Abs(vel.y) + Mathf.Abs(vel.z) != 0){
            rb.MovePosition(rb.position + vel * Time.deltaTime);
        }
        rb.velocity= jump;
        //Shooting

        if (Input.GetMouseButtonDown(0)){
            Shoot();
        }

    }

    void Shoot(){
        Current_gun.GetComponent<GunShoot>().Shoot();
    }

    void GroundCheck(){
        if (is_grounded){
            hit_distance = 0.35f;
        }else{
            hit_distance = 0.15f;
        }
        if (Physics.Raycast(transform.position - transform.up * height, -transform.up, hit_distance , layer)){
            is_grounded = true;
        }else{
            is_grounded = false;
        }
    }

}
