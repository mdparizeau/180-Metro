using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Cetz, Zulema
/// 10/31/24
/// Handles enemy movement 
/// </summary>

public class EnemyMovement : MonoBehaviour
{
    public GameObject leftPoint;
    public GameObject rightPoint;

    private Vector3 leftPos;
    private Vector3 rightPos;

    public float speed;
    public bool goingRight;
    // Start is called before the first frame update
    void Start()
    {
        //store the starting values in 3d space of our left/right points
        leftPos = leftPoint.transform.position;
        rightPos = rightPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        if (goingRight)
        {
            //check if reached the right positon- if so, switch directions
            if (transform.position.x >= rightPos.x)
            {
                goingRight = false;

            }
            else //not yet at the right position so move right 
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }

        else
        {
            if (transform.position.x <= leftPos.x)
            {
                goingRight = true;

            }
            else //not yet at the  position so move right 
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }
    }

}
