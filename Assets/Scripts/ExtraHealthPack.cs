using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraHealthPack : MonoBehaviour
{
    public int extraHealth = 100;
    public float rotSpeed;
    public GameObject player;
    public bool active = true;

    void Update()
    {
        transform.Rotate(0, rotSpeed, Time.deltaTime);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            player.GetComponent<Player>().health = 99;
            player.GetComponent<Player>().health += extraHealth;
            
            StartCoroutine(RespawnItem());
        }
    }


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
