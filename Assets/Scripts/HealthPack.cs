using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Cetz, Zulema 
/// 11/5/24
/// Handles code relating to health pack when player collides with health pack it will gain X amount of health. Health will be set in the inspector. 
/// </summary>
public class HealthPack : MonoBehaviour
{
    public int hpValue;
    public float rotSpeed;

    void Update()
    {
        transform.Rotate(0, rotSpeed, Time.deltaTime);
    }


}
