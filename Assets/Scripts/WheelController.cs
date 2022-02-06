using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    public WheelCollider frontRight;
    public WheelCollider frontLeft;
    public WheelCollider backRight;
    public WheelCollider backLeft;

    public Transform frontRightTransform;
    public Transform frontLeftTransform;
    public Transform backRightTransform;
    public Transform backLeftTransform;

    private float acceleration = 500f;
    private float breakingForce = 300f;
    private float maxTurnAngle = 15f;

    private float currentAcceleration = 0f;
    private float currentBreakingForce = 0f;
    private float currentTurnAngle = 0f;

    private float horizontalInput;
    private float forwardInput;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    

    private void GetInput(){

        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
    }

    private void Accelerate(){
        currentAcceleration = acceleration * forwardInput;

        frontRight.motorTorque = currentAcceleration;
        frontLeft.motorTorque = currentAcceleration;

    }
    private void Steer(){
        // Take Care of steering
        currentTurnAngle = maxTurnAngle * horizontalInput;
        currentTurnAngle = 0f;

        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;

    }

    private void UpdateWheelPoses(){
        // Update Wheel Meshes
        UpdateWheel(frontLeft, frontLeftTransform);
        UpdateWheel(frontRight, frontRightTransform);
        UpdateWheel(backLeft, backLeftTransform);
        UpdateWheel(backRight, backRightTransform);
    }

    private void UpdateWheel(WheelCollider collider, Transform transform){
        //Get wheel collider state
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        //Set Wheel Transform State
        transform.position = position;
        transform.rotation = rotation;
    }

    private void Update()
    {   
        Debug.Log("wHEEL cONTROLLER fIXED uPDATE!!!!");
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
        // Apply Acceleration to front of the wheels
        // Apply breaking force to all wheels

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.S))
        {
            currentBreakingForce = breakingForce;
        }else{
            currentBreakingForce = 0f;
        }

            frontRight.brakeTorque = currentBreakingForce;
            frontLeft.brakeTorque = currentBreakingForce;
            backRight.brakeTorque = currentBreakingForce;
            backLeft.brakeTorque = currentBreakingForce;

    }
}
