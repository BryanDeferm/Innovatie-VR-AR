using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    public Transform[] wheels;
    public float enginePower = 50.0f;
    public float maxSteer = 25.0f;
    public float timeBetweenSwing = 2f;
    public float swingTime = .3f;

    private Rigidbody body;
    float power = 0.0f;
    float brake = 0.0f;
    float steer = 0.0f;
    bool swalping = false;
    float rand;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.centerOfMass = new Vector3(0, -0.5f, 0.3f);
    }

    void Update()
    {
        InvokeRepeating("Swalp", 2f, .5f);

        power = Input.GetAxis("Vertical") * enginePower * Time.deltaTime * 250.0f;

        if (!swalping)
        {
            steer = Input.GetAxis("Horizontal") * maxSteer;
        }
        else
        {
            steer = rand * maxSteer;
        }

        brake = Input.GetKey("space") ? body.mass * 0.1f : 0.0f;

        GetCollider(0).steerAngle = steer;
        GetCollider(1).steerAngle = steer;


        if (brake > 0.0)
        {
            GetCollider(0).brakeTorque = brake;
            GetCollider(1).brakeTorque = brake;
            GetCollider(2).brakeTorque = brake;
            GetCollider(3).brakeTorque = brake;
            GetCollider(2).motorTorque = 0.0f;
            GetCollider(3).motorTorque = 0.0f;
        }
        else
        {
            GetCollider(0).brakeTorque = 0;
            GetCollider(1).brakeTorque = 0;
            GetCollider(2).brakeTorque = 0;
            GetCollider(3).brakeTorque = 0;
            GetCollider(2).motorTorque = power;
            GetCollider(3).motorTorque = power;
        }



    }
    WheelCollider GetCollider(int n)
    {
        return wheels[n].gameObject.GetComponent<WheelCollider>();
    }

    void Swalp()
    {
        swalping = !swalping;
        rand = Random.Range(-1.5f, 1.5f);

    }

}
