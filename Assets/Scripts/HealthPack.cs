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
    public int hpValue;
    public float rotSpeed;
    public bool active = true;
    public GameObject player;

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
            if ((player.health + hpValue) >= player.maxHealth)
                player.health = player.maxHealth;
            else
            {
                player.health += hpValue;
            }
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
