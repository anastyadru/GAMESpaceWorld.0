// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControllerEnemy : MonoBehaviour
{
    public float speed = 100;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerController"))
        {
            Player player = other.GetComponent<PlayerController>();
            player.health -= 5;
            if (player.health <= 0)
            {
                player.OnRelease();
                gameObject.SetActive(false);
            }
        }
    }
    
    public void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}