using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryTeller : MonoBehaviour
{
    public GameObject[] imageObjects; 
    public AudioClip[] dialogues;
    public float zoomSpeed = 0.1f; 
    public float maxScale = 1.2f;
    private bool isZooming = false; 


    private AudioSource audioSource; 
    private int currentStage = 0; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        UpdateStory();
    }

    void UpdateStory()
    {
        
        foreach (var image in imageObjects)
        {
            image.SetActive(false);
            image.transform.localScale = Vector3.one; 
        }

      
        if (currentStage < imageObjects.Length && currentStage < dialogues.Length)
        {
            imageObjects[currentStage].SetActive(true);
            audioSource.clip = dialogues[currentStage];
            audioSource.Play();
            isZooming = true;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            currentStage++;
            if (currentStage >= imageObjects.Length || currentStage >= dialogues.Length)
                SceneManager.LoadScene("2_Level");
            UpdateStory();
        }
        if (isZooming && currentStage < imageObjects.Length)
        {
            var currentImage = imageObjects[currentStage];
            if (currentImage.transform.localScale.x < maxScale)
            {
                float scale = Mathf.Lerp(currentImage.transform.localScale.x, maxScale, zoomSpeed * Time.deltaTime);
                currentImage.transform.localScale = new Vector3(scale, scale, 1);
            }
            else
            {
               
                isZooming = false;
            }
        }
    }
}