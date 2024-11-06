using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Benjamin Smith Zulema C.
 * 11/5/2024
 * Handles the bullet behaviors
 */
public class Bullet : MonoBehaviour
{
    public bool goingLeft;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// Makes the bullet move left or right based on whether the goingLeft bool is true or false
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        if (goingLeft == true)
        {
            transform.position += speed * Vector3.left * Time.deltaTime;

        }

        else
        {
            transform.position += speed * Vector3.right * Time.deltaTime;

        }
    }
    /* private void OnTriggerEnter(Collision collision)
    {
        
        if (collision.gameObject.GetComponent<Hazard>())
        {
            collision.gameObject.SetActive(false);
            print("you touched the enemy");
        }
        //this.gameObject.SetActive(false);
    } */
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Hazard>())
        {
            other.gameObject.SetActive(false);
            print("you touched the enemy");
        }
        if (!other.gameObject.GetComponent<Player>())
            this.gameObject.SetActive(false);
    }
}
