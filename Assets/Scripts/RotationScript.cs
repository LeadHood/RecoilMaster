using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    [SerializeField] string EnemyTag = "Enemy";
    CircleCollider2D coll;

    private void Start()
    {
        coll = GetComponent<CircleCollider2D>();
    }

    //Rotation
    void Update()
    {
        Vector2 mousePosTemp = Input.mousePosition;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(mousePosTemp);

        Vector2 playerPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        Vector2 targetDirection = (playerPos - mousePos);

        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, angle + 90);

        gameObject.transform.rotation = rotation;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == EnemyTag)
        {
            gameObject.GetComponent<HealthScript>().ChangeHealth(-1);
            Destroy(collision.gameObject);
        }
    }
}
