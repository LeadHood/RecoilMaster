using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] float speed = 4f;
    [SerializeField] float damage = 1f;
    
    Rigidbody2D rb;

    [SerializeField] string EnemyTag = "Enemy";
    [SerializeField] string ObstacleTag = "Obstacle";

    [SerializeField] GameObject particleBullet;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.up * speed;
        FireScript.GetRecoil(rb.velocity);
    }


    void Update()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnBecameInvisible()
    {
        Perish(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == EnemyTag)
        {
            collision.gameObject.GetComponent<HealthScript>().ChangeHealth(-damage);
            Perish(true);
        }
        else if(collision.gameObject.tag == ObstacleTag)
        {
            Perish(true);
        }
    }

    private void Perish(bool emitParticles)
    {
        if(emitParticles)
        {
            GameObject prefabClone = Instantiate(particleBullet, transform.position, Quaternion.identity);
            Destroy(prefabClone, 2.5f);
        }
       
        Destroy(gameObject, 0.02f);
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }
}
