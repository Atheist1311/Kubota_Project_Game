using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float currentBreakForce;
   [HideInInspector] public float currentSteerAngle;
    private bool isBreaking;

   private float currentMotorForce;
    [SerializeField] private float motorForce;
    [SerializeField] private float BreakForce;
    [SerializeField] private float maxSteerAngle;
  [SerializeField] private float thrust;
  float speed;
  [SerializeField] private float maxSpeed;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    Rigidbody rigidbody;
    public Vector3 mass = new Vector3(0, -0.9f, 0);
    public Vector3 m_EulerAngleVelocity;

    private float xRotationLimit = 30;
    private float yRotationLimit = 30;
    private float zRotationLimit = 30;

    public bool isCarSpin;
    public float carSpinTime;
    public float carStopTime;
    public CarCrashStateEnum carCrashState;
    public bool isR;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        currentMotorForce = motorForce;
        rigidbody.centerOfMass = mass;
    }
    private void FixedUpdate()
    {
    speed = rigidbody.velocity.magnitude * 3.6f;
    if(speed < maxSpeed)
    {
            // --Manual Control--
            // HandleMotor();
            if (!isR)
            {
                // --Gear D--
                frontLeftWheelCollider.motorTorque = motorForce;
                frontRightWheelCollider.motorTorque = motorForce;
            }
            else
            {
                // --Gear R--
                  frontLeftWheelCollider.motorTorque = -motorForce;
                  frontRightWheelCollider.motorTorque = -motorForce;
            }
    }
    else
    {
      DecreasVelocity();
    }
        currentBreakForce = isBreaking ? BreakForce : 0f;
        if (isBreaking)
        {
            ApplyBreaking();
        }
        GetInput();
        HandleSteering();
        ApplyBreaking();
        UpdateWheel();
        if( Input.GetKey(KeyCode.P))
        {
            Debug.Log("P");
            RotateCar(m_EulerAngleVelocity,10);
        }
        if (Input.GetKey(KeyCode.O))
        {
            Debug.Log("O");
            RotateCar(-m_EulerAngleVelocity, 10);
        }
        if (isCarSpin == true)
        {
            CarCrashing();
        }
  }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        currentBreakForce = isBreaking ? BreakForce : 0f;
        if(isBreaking)
        {
            ApplyBreaking();
        }
    }
    private void ApplyBreaking()
    {
        frontLeftWheelCollider.brakeTorque = currentBreakForce;
        frontRightWheelCollider.brakeTorque = currentBreakForce;
        rearLeftWheelCollider.brakeTorque = currentBreakForce;
        rearRightWheelCollider.brakeTorque = currentBreakForce;
    }
    private void HandleSteering()
    {
        currentSteerAngle = (maxSteerAngle * horizontalInput);
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }
    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
       // isBreaking = Input.GetKey(KeyCode.Space);
        isBreaking = Input.GetButton("Jump");
    }
    private void UpdateWheel()
    {
        UpdateSingleWheel(frontLeftWheelCollider,frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
    }
    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
       // wheelTransform.position = pos;
    }
    public void ResetMotor()
    {
        frontLeftWheelCollider.motorTorque = 0;
        frontRightWheelCollider.motorTorque = 0;
        rigidbody.velocity = Vector3.zero;
    }
    public void SlowCar()
  {
    rigidbody.velocity *= 0.1f;
  }
    public void SpeedCar()
  {
        rigidbody.AddForce(transform.forward * thrust * 3.6f, ForceMode.VelocityChange);    
  }
    public void ResetSpeed()
  {
    rigidbody.velocity *= 1;
  }
    public void DecreasVelocity()
  {
    rigidbody.velocity *= 0.99f;
  }
    public void RotateCar(Vector3 angle , float rotatateSpeed)
  {
   // rigidbody.velocity *= 0.75f;
    Quaternion deltaRotation = Quaternion.Euler(angle * Time.fixedDeltaTime * rotatateSpeed);
    rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
  }
  public void StopCar()
  {
    rigidbody.velocity *= 0f;
  }
    void CarCrashing()
    {
         CameraSwitch camera = Camera.main.GetComponent<CameraSwitch>();
        switch (carCrashState)
        {
            case CarCrashStateEnum.Spinning:
                 camera.isSpin = true;
                carSpinTime -= Time.fixedDeltaTime;
                RotateCar(m_EulerAngleVelocity,30);
                if (carSpinTime <= 0) { carCrashState = CarCrashStateEnum.Stop; }
                break;
            case CarCrashStateEnum.Stop:
                 camera.isSpin= false;
                carStopTime -= Time.fixedDeltaTime;
                StopCar();
                if (carStopTime <= 0) { carCrashState = CarCrashStateEnum.StartAccelation; }
                break;
            case CarCrashStateEnum.StartAccelation:
                ResetSpeed();
                isCarSpin = false;
                carCrashState = CarCrashStateEnum.Spinning;
                break;
        }
    }
}
