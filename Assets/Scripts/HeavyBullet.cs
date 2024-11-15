using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBullet : MonoBehaviour
{
    public bool active = true;
    public GameObject player;
    public float rotSpeed;

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
            player.HB = true;
            print("dmg 3x");
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
