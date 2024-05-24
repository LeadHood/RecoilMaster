using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    void Update()
    {
        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0, 0));
        transform.position = transform.position + new Vector3(0, 0, 1);
        transform.localScale = new Vector3(Camera.main.ViewportToWorldPoint(new Vector3(2, 0, 0)).x, 2, 0);
    }
}
