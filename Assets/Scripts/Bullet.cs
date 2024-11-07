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
    //float raycastDist = 0.5f;
    public float speed;
    private Vector3 leftCheck;
    private Vector3 rightCheck;

    // Start is called before the first frame update
    void Start()
    {
        /*float halfWidth = (transform.localScale.x / 2) + 0.1f;
        rightCheck = transform.position + new Vector3(halfWidth, 0, 0);
        leftCheck = transform.position - new Vector3(halfWidth, 0, 0);*/
    }

    /// <summary>
    /// Makes the bullet move left or right based on whether the goingLeft bool is true or false
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        if (goingLeft == true)
            transform.position += speed * Vector3.left * Time.deltaTime;
        else transform.position += speed * Vector3.right * Time.deltaTime;

        /*RaycastHit hit;
        if (Physics.Raycast(rightCheck, Vector3.right, out hit)
            || Physics.Raycast(leftCheck, Vector3.left, out hit))
        {
            if (!hit.collider.GetComponent<Shooting>() && !gameObject.GetComponent<Bullet>())
            {
                this.gameObject.SetActive(false);
            }
                //this.gameObject.SetActive(false);

        }
        Debug.DrawRay(transform.position, Vector3.left * raycastDist, Color.red);
        Debug.DrawRay(transform.position, Vector3.right * raycastDist, Color.red);*/
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Hazard>())
        {
            other.GetComponent<Hazard>().LoseHealth1();
            this.gameObject.SetActive(false);
        }
        else if (other.gameObject.GetComponent<Hazard2>())
        {
            other.GetComponent<Hazard2>().LoseHealth1();
            this.gameObject.SetActive(false);
        }
        else if (!other.gameObject.GetComponent<Player>())
                {
                    Destroy(gameObject);
                }
    }
}
