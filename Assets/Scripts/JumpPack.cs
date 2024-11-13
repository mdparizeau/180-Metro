using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPack : MonoBehaviour
{
    public GameObject jumpPack;
    private Vector3 packPosition;
    public bool available = true;


    void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (available && player)
        { 
            StartCoroutine(RespawnPack());
            player.jumpForce *= 2;
            print("Jump force has doubled");
            player.backpack.GetComponent<Renderer>().enabled = true;
            print("Backpack visible");
        }


    }

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
