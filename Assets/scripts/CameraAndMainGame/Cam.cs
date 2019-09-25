using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    //Variables
    public Transform player;
    public float smooth = 0.3f;

    public float height = 7f;

    private Vector3 velocity = Vector3.zero;

    //Methods

    void Update(){
        Vector3 pos = new Vector3();
        pos.x = player.position.x;
        pos.z = player.position.z - 7f;
        pos.y = player.position.y + height;
        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smooth);
        if (Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }

}
