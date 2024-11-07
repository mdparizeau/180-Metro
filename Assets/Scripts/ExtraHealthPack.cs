using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraHealthPack : MonoBehaviour
{
    public int extraHealth = 100;
    public float rotSpeed;

    void Update()
    {
        transform.Rotate(0, rotSpeed, Time.deltaTime);
    }
}
