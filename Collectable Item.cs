using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public AudioSource zvuk;
    [SerializeField]
    private AudioClip take;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            zvuk.PlayOneShot(take);
            FindObjectOfType<ItemCollector>().CollectItem(gameObject.tag);
            Destroy(gameObject);
        }
    }
}
