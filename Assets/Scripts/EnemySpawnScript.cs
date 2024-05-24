using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawnScript : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnTime = 2;
    float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= spawnTime)
        {
            SpawnEnemy();
            timer = 0;
        }
    }

    void SpawnEnemy()
    {
        int rnd = Random.Range(1, 5);
        Vector3 position = new Vector3(0, Camera.main.ViewportToWorldPoint(new Vector3(0, 1.2f, 0)).y, 0);
        if (rnd == 2)
        {
            //Till höger om skärmen
            position = position + Camera.main.ViewportToWorldPoint(new Vector3(1.2f, 0, 0));
            position.y = Random.Range(Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y, Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y);
        }
        else if (rnd == 1)
        {
            //Till vänster om skärmen
            position = position + Camera.main.ViewportToWorldPoint(new Vector3(-0.2f, 0, 0));
            position.y = Random.Range(Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y, Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y);

        }
        else if (rnd == 3)
        {
            //Över skärmen
            position.x = Random.Range(Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x, Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x);
        }
        else
        {
            position.y = Camera.main.ViewportToWorldPoint(new Vector3(0, -0.2f, 0)).y;
            position.x = Random.Range(Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x, Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x);

        }

        Instantiate(enemyPrefab, position, Quaternion.identity);
    }
}
