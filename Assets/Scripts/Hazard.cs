using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Michael Parizeau
/// 10/31/24
/// Hazard script to attach to Hard Enemies
/// <summary>
public class Hazard : MonoBehaviour
{
    public int health = 10;
    public int damage = 15;
    public Player playerScript;
    /// <summary>
    /// Causes the player to take damage 
    /// </summary>
    public void Damage()
    {
        if (playerScript.HB)
            health -= 3;
        else health -= 1;
        if (health <= 0)
            this.gameObject.SetActive(false);
    }
    /// <summary>
    /// Causes the player to lose health on collision with them
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            collision.gameObject.GetComponent<Player>().LoseHealth(damage);
        }
    }
}
