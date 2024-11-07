using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Michael Parizeau
/// 10/31/24
/// Hazard script to attach to Regular Enemies
/// <summary>
public class Hazard : MonoBehaviour
{
    public int health = 1;

    void Update()
    {
        if (health <= 0)
            this.gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            collision.gameObject.GetComponent<Player>().LoseHealth1();
        }
    }
}
