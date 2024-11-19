using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Zulema C , Benjamin S
/// 11/5/2024
/// Manages the players shooting 
/// </summary>

public class Shooting : MonoBehaviour
{
    public bool goingLeft;

    public float startDelay;
    public float shotDelay;
    public bool canShoot = true;
    public Player playerScript; 
    public Bullet Bullet1;

    // Start is called before the first frame update
    void Start()
    {
    }




    // Update is called once per frame
    void Update()
    {
        // Causes the player to shoot a bullet
        Firing();
    }
    /// <summary>
    /// Gets the bullet prefab and makes it go left or right based on player script facing left direction
    /// </summary>
    public void Shoot()
    {
        // GameObject Bullet = Instantiate(Bullet1, transform.position, Bullet1.transform.rotation);
        if (Bullet1.GetComponent<Bullet>())
        {
            if(playerScript.facingLeft == true)
            {
                Bullet1.goingLeft = playerScript.facingLeft;
                Bullet1.playerScript = playerScript;
                GameObject Bullet = Instantiate(Bullet1.gameObject, transform.position, Bullet1.transform.rotation);
            }
            else
            {
                Bullet1.goingLeft = playerScript.facingLeft;
                Bullet1.playerScript = playerScript;
                GameObject Bullet = Instantiate(Bullet1.gameObject, transform.position, Bullet1.transform.rotation);
                
            }
        }
    }
    /// <summary>
    /// Press left shift to fire bullets
    /// </summary>
    public void Firing()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(canShoot)
            {
                Shoot();
                StartCoroutine(ShotDelay());


                print("Bullet shot");
            }
            


            //InvokeRepeating("Shoot", startDelay, shotDelay);
        }
        
    }
    /// <summary>
    /// Adds a delay after firing
    /// </summary>
    /// <returns></returns>
    IEnumerator ShotDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(0.5f);
        canShoot = true;
        //Firing();
    }
}
