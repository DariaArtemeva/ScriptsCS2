using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class QuestCompletion : MonoBehaviour
{
    private bool playerInRange = false;
    public GameObject ladder; 
    public ItemCollector itemCollector;
    [SerializeField]
    private AudioSource volume;
    public AudioClip zdvig;
    public AudioClip thoughts2;

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
            TryCompleteQuest();
        }
    }

    private void TryCompleteQuest()
    {
        if (itemCollector.blueberries >= 3 && itemCollector.mushrooms >= 5 && itemCollector.acorns >= 8)
        {
            StartCoroutine(MoveDown());
            ladder.SetActive(true);
            
        }
    }

    private IEnumerator MoveDown()
    {
        volume.PlayOneShot(zdvig);
        float duration = 3.0f; 
        float distance = -0.601f; 
        Vector3 startPosition = transform.position;
        Vector3 endPosition = new Vector3(transform.position.x, transform.position.y + distance, transform.position.z);
        float elapsed = 0;

        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        volume.PlayOneShot(thoughts2);
        transform.position = endPosition;
    }
}

