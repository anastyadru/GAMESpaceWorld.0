// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 250f;
    public GameObject lazerShot;
    public Transform lazerGun;
    private float nextShotTime;
    
    public int health = 100;

    public void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 newPosition = transform.position + new Vector3(mouseX * speed * Time.deltaTime, 0, 0);
        newPosition.x = Mathf.Clamp(newPosition.x, -300f, 210f);
        transform.position = newPosition;
        if (Input.GetButton("Fire1") && Time.time > nextShotTime)
        {
            string selectedShip = PlayerPrefs.GetString("SelectedShip");
            if (selectedShip.Contains("SpaceshipRed"))
            {
                Instantiate(lazerShot, lazerGun.position, transform.rotation);
                nextShotTime = Time.time + 0.1f;
            }
            else if (selectedShip.Contains("SpaceshipBlue"))
            {
                Instantiate(lazerShot, lazerGun.position, transform.rotation);
                Instantiate(lazerShot, lazerGun.position, Quaternion.Euler(0, -15, 0) * transform.rotation);
                Instantiate(lazerShot, lazerGun.position, Quaternion.Euler(0, 15, 0) * transform.rotation);
                nextShotTime = Time.time + 0.2f;
            }
        }
    }
    
    public void OnRelease()
    {
        
    }
}