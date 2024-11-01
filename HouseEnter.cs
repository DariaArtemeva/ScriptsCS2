using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HouseEnter : MonoBehaviour
{
    private bool playerInRange = false;
    public string sceneName;
    public GameObject manager;
    public Image fadeImage;
    public float fadeSpeed = 0.8f;
    [SerializeField]
    private AudioSource volume;
    public AudioClip door;
    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn()
    {
        float alpha = fadeImage.color.a;
        while (alpha > 0)
        {
            alpha -= Time.deltaTime / fadeSpeed;
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, alpha);
            yield return null;
        }
        fadeImage.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player in range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player not in range");
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(TransitionToScene());
        }
    }

    public IEnumerator FadeOut()
    {
        fadeImage.enabled = true;
        float alpha = fadeImage.color.a;
        while (alpha < 1)
        {
            alpha += Time.deltaTime / fadeSpeed;
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, alpha);
            yield return null;
        }
    }

    private IEnumerator TransitionToScene()
    {
        yield return StartCoroutine(FadeOut());
        volume.PlayOneShot(door);
        if (manager != null) Destroy(manager);
        SceneManager.LoadScene(sceneName);
    }
}
