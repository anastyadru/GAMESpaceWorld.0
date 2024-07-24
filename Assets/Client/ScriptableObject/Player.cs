// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 250f;
    public GameObject lazerShot;
    public Transform lazerGun;
    private float nextShotTime;
    public int health = 100;

    void Update()
    {
        MovePlayer();
        HandleShooting();
    }

    private void MovePlayer()
    {
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 newPosition = transform.position + new Vector3(mouseX * Speed * Time.deltaTime, 0, 0);
        transform.position = new Vector3(Mathf.Clamp(newPosition.x, -300f, 210f), newPosition.y, newPosition.z);
    }

    private void HandleShooting()
    {
        if (Input.GetButton("Fire1") && Time.time > nextShotTime)
        {
            string selectedShip = PlayerPrefs.GetString("SelectedShip");
            if (selectedShip.Contains("SpaceshipRed"))
            {
                Shoot(1);
                nextShotTime = Time.time + 0.1f;
            }
            else if (selectedShip.Contains("SpaceshipBlue"))
            {
                Shoot(3);
                nextShotTime = Time.time + 0.2f;
            }
        }
    }

    private void Shoot(int shotCount)
    {
        for (int i = 0; i < shotCount; i++)
        {
            float angle = (i - 1) * 15; // -15, 0, +15
            Quaternion rotation = Quaternion.Euler(0, angle, 0) * transform.rotation;
            Instantiate(lazerShot, lazerGun.position, rotation);
        }
    }
    
    public void OnRelease()
    {
        
    }
}