using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateThoughts : MonoBehaviour
{
    [SerializeField]
    private AudioSource volume;
    public AudioClip Thoughts3;
    public GameObject thisobj;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            volume.PlayOneShot(Thoughts3);
            Destroy(thisobj);
        }
    }
}
