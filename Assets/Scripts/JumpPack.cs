using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Benjamin S, Zulema C.
 * 11/18/2024
 * Handles the jump pack pick up and respawn behaviors
 */
public class JumpPack : MonoBehaviour
{
    public GameObject jumpPack;
    public bool available = true;
    public float rotSpeed;

    void Update()
    {
        //Rotates the item
        transform.Rotate(0, rotSpeed, Time.deltaTime);
    }
    /// <summary>
    /// Causes the player to pick up the item and then respawn the item after a delay
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (available && player)
        { 
            StartCoroutine(RespawnPack());
            player.jumpForce *= 2;
            print("Jump force has doubled");
            player.backpack.GetComponent<Renderer>().enabled = true; // Causes the jump pack to be visible after picking it up
            print("Backpack visible");
        }


    }
    /// <summary>
    /// Respawns the item after a delay
    /// </summary>
    /// <returns></returns>
   public IEnumerator RespawnPack()
    {
        available = false;
        this.GetComponent<MeshRenderer>().enabled = false;
        print("before");
        yield return new WaitForSeconds(5f);
        print("after");
        available = true;
        this.GetComponent<MeshRenderer>().enabled = true;
    }
}
