using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Michael Parizeau
/// 10/31/24
/// Hazard script to attach to Hard Enemies
/// <summary>
public class Hazard2 : MonoBehaviour
{
    public int health = 10;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            collision.gameObject.GetComponent<Player>().LoseHealth2();
        }
    }
}
