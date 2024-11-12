using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPack : MonoBehaviour
{
    public GameObject jumpPack;
    private Vector3 packPosition;

    void OnTriggerEnter(Collider other)
    {

        StartCoroutine("RespawnPack");

    }

    IEnumerator RespawnPack()
    {

        GameObject clone = (GameObject)Instantiate(jumpPack, packPosition, Quaternion.identity) as GameObject;

        Destroy(jumpPack);

        yield return null;

    }
}
