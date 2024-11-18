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
    public Player playerScript;
    public Material bullet_mat;
    public bool goingLeft;
    public float speed;

    /// <summary>
    /// Makes the bullet move left or right based on whether the goingLeft bool is true or false
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        if (goingLeft == true)
            transform.position += speed * Vector3.left * Time.deltaTime;
        else transform.position += speed * Vector3.right * Time.deltaTime;
        if (playerScript.HB)
        {
            this.GetComponent<Renderer>().material = bullet_mat;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Hazard>())
        {
            other.GetComponent<Hazard>().Damage();
            this.gameObject.SetActive(false);
        }
        if (other.gameObject.GetComponent<Door>())
        {
            if (playerScript.HB && playerScript.jumpForce == 16)
            {
                other.GetComponent<Door>().shoot = true;
                other.GetComponent<Renderer>().material = other.GetComponent<Door>().door_mat;
                print("door shot");
            }
            this.gameObject.SetActive(false);
        }
        if (!other.gameObject.GetComponent<Player>())
                {
                    Destroy(gameObject);
                }
    }
}
