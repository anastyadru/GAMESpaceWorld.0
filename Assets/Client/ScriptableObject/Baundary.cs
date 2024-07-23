// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;

public class Baundary : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
} 