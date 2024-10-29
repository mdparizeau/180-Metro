using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 moveDir;
    private float moveSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            moveDir = Vector3.left;
            transform.position += moveDir * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveDir = Vector3.right;
            transform.position += moveDir * moveSpeed * Time.deltaTime;
        }
    }
}
