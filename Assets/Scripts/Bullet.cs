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
    float raycastDist = 0.5f;
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
        //RaycastHit hit;
        if (goingLeft == true)
            transform.position += speed * Vector3.left * Time.deltaTime;
        else transform.position += speed * Vector3.right * Time.deltaTime;

        if (Physics.Raycast(transform.position, Vector3.right, raycastDist)
            || Physics.Raycast(transform.position, Vector3.left, raycastDist))
        {
            //if (!hit.collider.GetComponent<Shooting>() && !gameObject.GetComponent<Bullet>())
                //this.gameObject.SetActive(false);

        }
        Debug.DrawRay(transform.position, Vector3.left * raycastDist, Color.red);
        Debug.DrawRay(transform.position, Vector3.right * raycastDist, Color.red);
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
            this.gameObject.SetActive(false);
        }
    }
}
