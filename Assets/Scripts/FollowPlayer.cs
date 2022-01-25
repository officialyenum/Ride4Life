using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(15, 5, 0);
    private float horizontalInput;
    private float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.position = player.transform.position + offset;
        
        transform.eulerAngles += speed * new Vector3(0, horizontalInput, 0) * Time.deltaTime;

        // transform.Rotate(Vector3.up * Time.deltaTime * 45.0f * horizontalInput);
        
    }
}
