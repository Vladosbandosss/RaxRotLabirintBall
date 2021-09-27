using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset;//растоян между камерой и игроком позициями
    private GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            transform.position = player.transform.position +offset;
        }
    }
}
