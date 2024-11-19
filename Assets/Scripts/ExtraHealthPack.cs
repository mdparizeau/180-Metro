using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Benjamin S, Zulema C
 * 11/18/2024
 * Handles the extra health pack pick up and respawn behaviors
 */
public class ExtraHealthPack : MonoBehaviour
{
    public int extraHealth = 100;
    public float rotSpeed;
    public GameObject player;
    public bool active = true;

    void Update()
    {
        // Rotates the extra health pack
        transform.Rotate(0, rotSpeed, Time.deltaTime);
    }
    /// <summary>
    /// Causes the player to pick up the extra health pack on collision and respawns the item after a delay
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (active && player)
        {
            StartCoroutine(RespawnItem());
            player.maxHealth += extraHealth;
            print("max health increased");
            player.health = player.maxHealth;
            print("increased health to match maxhealth");
        }
    }

    /// <summary>
    /// Respawns the item after a delay
    /// </summary>
    /// <returns></returns>
    public IEnumerator RespawnItem()
    {
        active = false;
        this.GetComponent<MeshRenderer>().enabled = false;
        print("before");
        yield return new WaitForSeconds(5f);
        print("after");
        active = true;
        this.GetComponent<MeshRenderer>().enabled = true;
    }
}
