using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour
{
    private AudioSource volume;
    [SerializeField]
    private AudioClip death;
    [SerializeField]
    private AudioClip hurt;
    public int health = 5;

    private void Start()
    {
        volume = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            volume.PlayOneShot(hurt);
            health -= 1;

            if (health <= 0)
            {
                StartCoroutine(Die());
            }
        }
    }

    IEnumerator Die()
    {
        volume.PlayOneShot(death);
        yield return new WaitForSeconds(death.length);
        Destroy(gameObject);
    }
}
