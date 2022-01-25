using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public GameObject child;
    private float horizontalInput;
    private float speed = 1;
    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        child = player.transform.Find("camera constraint").gameObject;
    }

    private void FixedUpdate() 
    {
        gameObject.transform.position = Vector3.Lerp(transform.position, child.transform.position, Time.deltaTime * speed);
        gameObject.transform.LookAt(player.gameObject.transform.position);
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
