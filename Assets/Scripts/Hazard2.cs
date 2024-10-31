using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard2 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            collision.gameObject.GetComponent<Player>().LoseHealth2();
        }
    }
}
