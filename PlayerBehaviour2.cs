using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour2 : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private bool isJumping = false;
    private AudioSource volume;
    public int health = 5;
    [SerializeField]
    private AudioClip ouch;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        volume = GetComponent<AudioSource>();
    }

    void Update()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        if (Input.GetButton("Jump"))
        {
            if (!isJumping)
            {
                rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                isJumping = true;
            }
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            rb.velocity = new Vector2(horizontalInput * 5, rb.velocity.y);
            anim.SetFloat("Movex", horizontalInput);
            anim.SetBool("isMoving", true);
        }
        else if (anim.GetBool("isMoving"))
        {
            anim.SetBool("isMoving", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform") && isJumping)
        {
            isJumping = false;
        }
        else if (collision.gameObject.CompareTag("Monster") || collision.gameObject.CompareTag("Obstacle")) 
        {
            volume.PlayOneShot(ouch);
            health--;
            if (health <= 0) 
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
            }
        }
    }
}
