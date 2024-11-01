using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMovement : MonoBehaviour
{
    public PlayerBehaviour pb;
    private bool playerInRange = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
    private void Update()
    {
        if (playerInRange && Input.GetMouseButtonDown(0))
        {
            pb.canMoveHorizontally = true;
        }
    }
}
