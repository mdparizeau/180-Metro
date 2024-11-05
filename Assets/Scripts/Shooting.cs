using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Zulema C , Benjamin S
/// </summary>

public class Shooting : MonoBehaviour
{
    public bool goingLeft;

    public float startDelay;
    public float shotDelay;
    public bool canShoot = true;

    public GameObject Bullet1;

    // Start is called before the first frame update
    void Start()
    {
        
    }




    // Update is called once per frame
    void Update()
    {
        Firing();
    }

    public void Shoot()
    {
        GameObject Bullet = Instantiate(Bullet1, transform.position, Bullet1.transform.rotation);
        if (Bullet1.GetComponent<Bullet>())
        {
            Bullet1.GetComponent<Bullet>().goingLeft = goingLeft;
        }
    }

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

    IEnumerator ShotDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(0.5f);
        canShoot = true;
        //Firing();
    }
}
