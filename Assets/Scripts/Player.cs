using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Michael Parizeau, Benjamin Smith
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
        rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z); // Handles movement so the player does not phase through walls
        SpaceJump();
        // Handles the rotation of the player when they move left 
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
        // Handles the rotation of the player when they move left
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
        // Causes the player to respawn, take damage and lose both the jump pack and heavy bullets when they drop to a certain y value 
        if (transform.position.y <= deathY && health > 15)
        {
            transform.position = respawnPoint.transform.position;
            backpack.GetComponent<Renderer>().enabled = false;
            jumpForce = 8f;
            HB = false;
            health -= 15;
        }
        else if (transform.position.y <= deathY && health <= 15) // Kills the player and shows the game over screen when the player loses all of their health from falling off the level
            GameOver();
    }
    /// <summary>
    /// Causes the player to jump if they press the spacebar and are on the ground
    /// </summary>
    private void SpaceJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            print("Jumped");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        Debug.DrawRay(transform.position, Vector3.down * raycastDist, Color.red);
    }
    /// <summary>
    /// Checks whether the player is on the ground by using a raycast
    /// </summary>
    /// <returns></returns>
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
    /// <summary>
    /// Causes the player to lose health bases on the damageAmt variable and checks and causes the IFrame function on taking damage
    /// </summary>
    /// <param name="damageAmt"></param>
    public void LoseHealth(int damageAmt)
    {
        if(!invinc)
        {
            health -= damageAmt;
            StartCoroutine(IFrame());
        }
        
        if (health <= 0) // Checks if the player health is less than or equal to zero and if true, transitions to the game over screen
            GameOver();
    }
    /// <summary>
    /// Transitions to the game over screen and disables the player
    /// </summary>
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
            if (sceneIndex != 4)
                SwitchScene(sceneIndex);
            else if (other.GetComponent<Door>().shoot == true)
            {
                SwitchScene(sceneIndex);
            }
        }
    }
    /// <summary>
    /// Causes the player to blink repeatedly and prevents the player from taking damage from enemies while blinking
    /// </summary>
    /// <returns></returns>
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
    /// <summary>
    /// Causes the doorTouched variable to become true after a delay
    /// </summary>
    /// <returns></returns>
    public IEnumerator pp()
    {
        yield return new WaitForSeconds(1f);
        doorTouched = true;
    }
   
}
