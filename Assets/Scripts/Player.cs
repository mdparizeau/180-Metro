using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Vector3 moveDir;
    private float moveSpeed = 10f;
    private Rigidbody rb;
    public float jumpForce = 8f;
    float raycastDist = 1.2f;

    public float deathY = -2f;
    public GameObject respawnPoint;
    public int lives = 3;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        SpaceJump();
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
        if (transform.position.y <= deathY)
            Respawn();
    }
    public void Respawn()
    {
        lives--;

        if (lives <= 0)
        {
            // Game Over
            print("Game Over!");
            // Send player to Game Over screen
            SceneManager.LoadScene(0);

            this.enabled = false;
        }
        else transform.position = respawnPoint.transform.position;
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
}
