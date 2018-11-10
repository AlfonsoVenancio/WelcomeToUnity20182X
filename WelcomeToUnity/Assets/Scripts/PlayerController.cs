using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    float angle;

    Vector3 velocity;

    //TO make thing move, it simulates the physcics for the object 
    Rigidbody rigidBody;

    // Use this for initialization
    void Start()
    {

        rigidBody = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        rigidBody.MovePosition(velocity * Time.fixedDeltaTime + rigidBody.position);
    }



    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
        
    }

    public void LookAt(Vector3 lookPoint)
    {
        Vector3 heightCorrectedPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(heightCorrectedPoint);

    }
}
