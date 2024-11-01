using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed;
    private bool isMoving;
    private Vector2 input;
    private Vector2 blockedDirection = Vector2.zero;
    [SerializeField]
    public bool canMoveHorizontally = false; 
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (!isMoving && GameController.Instance.State == GameState.Free)
        {
            
            input.x = canMoveHorizontally ? Input.GetAxisRaw("Horizontal") : 0;
            input.y = Input.GetAxisRaw("Vertical");

           
            if (input.x != 0 && input.y != 0)
            {
                input.y = 0; // Обнуляем вертикальный ввод, если есть горизонтальный
            }

            if (input != Vector2.zero && Vector2.Dot(input.normalized, blockedDirection) < 0.1)
            {
                animator.SetFloat("Movex", input.x);
                animator.SetFloat("Movey", input.y);
                StartCoroutine(Move(input.normalized));
            }
        }
        animator.SetBool("isMoving", isMoving);
    }

    IEnumerator Move(Vector2 direction)
    {
        isMoving = true;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector3 start = transform.position;
        float step = speed * Time.fixedDeltaTime;
        Vector3 targetPos = start + new Vector3(direction.x, direction.y, 0) * step;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon && isMoving)
        {
            rb.MovePosition(Vector3.MoveTowards(transform.position, targetPos, step));
            yield return null;
        }

        rb.MovePosition(targetPos);
        isMoving = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 collisionNormal = collision.contacts[0].normal;
        blockedDirection = -collisionNormal;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        isMoving = false;
        animator.SetFloat("Movex", 0);
        animator.SetFloat("Movey", 0);
        animator.SetBool("isMoving", false);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        blockedDirection = Vector2.zero;
    }

    // Метод для разрешения горизонтального движения
    public void EnableHorizontalMovement()
    {
        canMoveHorizontally = true;
    }
}
