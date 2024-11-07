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
    public void LoseHealth1()
    {
        health -= 1;
        if (health <= 0)
            this.gameObject.SetActive(false);
    }
    public void LoseHealth2()
    {
        health -= 3;
        if (health <= 0)
            this.gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            collision.gameObject.GetComponent<Player>().LoseHealth2();
        }
    }
}
