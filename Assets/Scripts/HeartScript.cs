using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HeartScript : MonoBehaviour
{ 
    [SerializeField] HealthScript playerHealth;


    private void Start()
    {
    }

    void Update()
    {
        //offset = new Vector3(Camera.main.ViewportToWorldPoint(new Vector3(0.15f, 0.15f, 0)).x, Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 0.2f, 0)).y, 0);


        int health = (int) playerHealth.health;

        for (int i = 0; i < 3 - health; i++)
        {
            GameObject child = transform.GetChild(2 - i).gameObject;
            child.GetComponent<Image>().color = new Color(00, 00, 00, child.GetComponent<Image>().color.a);
        }
    }
}
