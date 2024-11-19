using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    //public int numOfEnemies = 100;

    void Update()
    {
        /*if (playerScript.sceneIndex == 5)
            numOfEnemies = 14;
        if (playerScript.counter == numOfEnemies)
            SceneManager.LoadScene(5);*/
    }

    /// <summary>
    /// Causes the enemy to take damage 
    /// </summary>
    public void Damage()
    {
        if (playerScript.HB)
            health -= 3;
        else health -= 1;
        if (health <= 0)
        {
            playerScript.counter++;
            this.gameObject.SetActive(false);
        }
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
