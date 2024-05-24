using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject player;

    [SerializeField] float dashTime = 3;
    [SerializeField] float dashSpeed = 5;
    float timer = 0;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();

        if (player)
        {
            Vector3 enemyVector = -(transform.position - player.transform.position);
            rb.velocity = enemyVector.normalized * dashSpeed;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= dashTime)
        {
            timer = 0;
            if(player)
            {
                Vector3 enemyVector = -(transform.position - player.transform.position);
                rb.velocity = enemyVector.normalized * dashSpeed;
            }
            
        }
        transform.position = new Vector3(0, 0, -transform.position.z) + transform.position;
    }

    private void FixedUpdate()
    {
        rb.velocity = rb.velocity * new Vector2(0.99f, 0.99f);
    }
}
