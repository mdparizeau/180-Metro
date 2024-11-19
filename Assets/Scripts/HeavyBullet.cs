using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Benjamin S. Zulema C. 
 * 11/18/2024
 * Handles the heavy bullet pick up and respawn behaviors
 */
public class HeavyBullet : MonoBehaviour
{
    public bool active = true;
    public GameObject player;
    public float rotSpeed;

    void Update()
    {
        // Roatates the item
        transform.Rotate(0, rotSpeed, Time.deltaTime);
    }
    /// <summary>
    /// Causes the player to pick up the item and then respawns the item after a delay
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (active && player)
        {
            StartCoroutine(RespawnItem());
            player.HB = true;
            print("dmg 3x");
        }
    }
        /// <summary>
        /// Respawns an item after a delay when picked up
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
