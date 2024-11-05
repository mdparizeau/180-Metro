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
    public Player playerScript;
    public int addHP;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            
        }
    }

   /* private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Coin>())
        {
            //adds points to player

            totalPoints += other.GetComponent<Coin>().coinValue;
            print("Coin value is" + other.GetComponent<Coin>().coinValue);
            //removes coin
            Destroy(other.gameObject);
        }
    } Platformer reference
   */ 
}
