// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BulletControllerEnemy : MonoBehaviour
{
    public float speed = 100;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
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