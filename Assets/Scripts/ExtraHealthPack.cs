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
