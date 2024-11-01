using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
 
    [SerializeField]
    private float speed = 5;


 
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("Monster") || collision.gameObject.CompareTag("Wall"))
        {
            
            gameObject.SetActive(false);
        }
    }
}
