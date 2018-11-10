using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    Rigidbody rb;

    Vector3 direction;

    public float enemySpeed;

    public float enemyLife;
    
    Material skinMaterial;

    Color originalColour;

    float attackDistanceThreshold = .5f;
    float timeBetweenAttacks = 1;

    
    float myCollisionRadius;
    float targetCollisionRadius;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
        skinMaterial = GetComponent<Renderer>().material;
        originalColour = skinMaterial.color;
        
        myCollisionRadius = GetComponent<CapsuleCollider>().radius;
        ChangeDirection(direction,enemySpeed*3);
    }


    public void Damage(float damage)
    {
        enemyLife -= damage;
        if (enemyLife<=0)
        {
            
            GameManager.instance.EnemyDown();
            GameManager.instance.MiniExplotion(transform.position);
            Destroy(gameObject);
        }
    }
    
    public void ChangeDirection(Vector3 _direction , float force)
    {
        force = (force > 0f) ?force:enemySpeed;
        direction =( new Vector3(_direction.x,transform.position.y, _direction.z)- transform.position).normalized;
        rb.AddForce(direction*force);
    }

    void OnCollisionEnter(Collision hit)
    {

        if (hit.transform.CompareTag("Bullet"))
        {
            //change the direction to the opposite direction of the bullet
            ChangeDirection(-hit.transform.position, 6);
            StartCoroutine(KnockBack());
        }else if (hit.transform.CompareTag("Player"))
        {
            //GameManager.instance.player.SendMessage("Damage");
        }
        else if (hit.transform.CompareTag("Wall") || hit.transform.CompareTag("Enemy"))
        {
            ChangeDirection(GameManager.instance.player.transform.position, enemySpeed);
        }
    }

    IEnumerator KnockBack()
    {
        
        yield return new WaitForSeconds(1.25f);
        ChangeDirection(GameManager.instance.player.transform.position, enemySpeed);
    }





}