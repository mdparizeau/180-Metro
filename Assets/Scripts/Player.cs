using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Michael Parizeau
/// 10/31/24
/// Player movement, health, and spawning
/// </summary>
public class Player : MonoBehaviour
{
    private Vector3 moveDir;
    private float moveSpeed = 10f;
    private Rigidbody rb;
    public float jumpForce = 8f;
    float raycastDist = 1.2f;
    public int sceneIndex;

    public bool facingLeft = false;
    public bool HB = false;
    public bool invinc = false;
    private bool doorTouched = false;
    

    public float deathY = -2f;
    public GameObject respawnPoint;
    public GameObject backpack;
    public int health = 99;
    public int maxHealth = 99;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
        SpaceJump();
        if (Input.GetKey(KeyCode.A))
        {
            //moveDir = Vector3.left;
            //transform.position += moveDir * moveSpeed * Time.deltaTime;
            rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, rb.velocity.z);
            if(!facingLeft)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                facingLeft = true;
            }
            
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(moveSpeed, rb.velocity.y, rb.velocity.z);
            //moveDir = Vector3.right;
            //transform.position += moveDir * moveSpeed * Time.deltaTime;

            if (facingLeft)
            {
                transform.rotation = Quaternion.Euler(0, 360, 0);
                facingLeft = false;
            }
        }
        if (transform.position.y <= deathY && health > 15)
        {
            transform.position = respawnPoint.transform.position;
            backpack.GetComponent<Renderer>().enabled = false;
            jumpForce = 8f;
            health -= 15;
        }
        else if (transform.position.y <= deathY && health <= 15)
            GameOver();
    }
    private void SpaceJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            print("Jumped");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        Debug.DrawRay(transform.position, Vector3.down * raycastDist, Color.red);
    }
    private bool IsGrounded()
    {
        bool isGrounded = false;

        //perform a raycast to check if player is on the ground
        if (Physics.Raycast(transform.position, Vector3.down, raycastDist))
        {
            isGrounded = true;
        }

        return isGrounded;
    }
    public void LoseHealth(int damageAmt)
    {
        if(!invinc)
        {
            health -= damageAmt;
            StartCoroutine(IFrame());
        }
        
        if (health <= 0)
            GameOver();
    }
    
    private void GameOver()
    {
            // Game Over
            print("Game Over!");
            // Send player to Game Over screen
            SceneManager.LoadScene(5);

            this.enabled = false;
    }

    /// <summary>
    /// will add HP to player when it comes into contact with health pack
    /// </summary>
    /// <param name="other"></param>
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Portal>())
        {
            //teleports player to new scene if already touched once
            if (doorTouched)
            {
                SwitchScene(sceneIndex);
            }
            //teleports player to teleport point 
            transform.position = other.GetComponent<Portal>().teleport.transform.position;
            print("You've been teleported");
            if (sceneIndex-1 == 1)
                   other.GetComponent<Renderer>().material = other.GetComponent<Portal>().portal_mat;
            StartCoroutine(pp());

        }
        if (other.GetComponent<Door>())
        {
            //teleports player to new scene
            SwitchScene(sceneIndex);
        }
    }
    public IEnumerator IFrame()
    {
        invinc = true;
        for (int i = 0; i < 50; i++)
        {
            if(i % 2 == 0)
            {
                GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                GetComponent<MeshRenderer>().enabled = true;
            }
            yield return new WaitForSeconds(.1f);
        }

        invinc = false;
        GetComponent<MeshRenderer>().enabled = true;
    }
    private void SwitchScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public IEnumerator pp()
    {
        yield return new WaitForSeconds(1f);
        doorTouched = true;
    }
   
}
