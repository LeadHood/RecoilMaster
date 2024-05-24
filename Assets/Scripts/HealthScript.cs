using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] public float health = 0;
    [SerializeField] GameObject HeartParent;

    [SerializeField] GameObject enemyParticle;
    [SerializeField] GameObject audioSource;

    [SerializeField] GameObject gameOverPanel;
    void Update()
    {
        
    }

    public void ChangeHealth(float healthToAdd)
    {
        health += healthToAdd;

        if(health <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        if(gameObject.tag == "Enemy")
        {
            GameObject particleClone = Instantiate(enemyParticle, transform.position, Quaternion.identity);
            Destroy(particleClone, 1.5f);

            Destroy(Instantiate(audioSource), 2);

            GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreCounter>().AddScore(1);
        }

        if(gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }

        Destroy(gameObject);
    }
}
