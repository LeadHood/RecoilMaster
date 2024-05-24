using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    Vector3 offset = new Vector3(0, 0, -10);


    void Update()
    {
        if(player)
        transform.position = player.transform.position + offset;
    }
}
