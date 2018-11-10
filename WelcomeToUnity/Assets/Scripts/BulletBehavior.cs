using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

    Rigidbody rb;

    public float bulletSpeed;// speed of the bullet, Dah

    Vector3 direction;// The point the character is aim at

	
	void Awake () {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    public void SetDirection(Vector3 _direction)
    {
        direction = _direction;

        rb.AddForce(direction * bulletSpeed, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision hit)
    {
        print(hit.transform.tag);
        if (hit.transform.CompareTag("Enemy"))
        {
            hit.gameObject.SendMessage("Damage",1f);
        }
        //GameManager.instance.MiniExplotion(transform.position);
        if (!hit.transform.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }



    }
