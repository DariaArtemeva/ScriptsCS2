using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewSprite : MonoBehaviour
{
    public Sprite defaultSprite;
    public Sprite clickedSprite;

    private SpriteRenderer spriteRenderer;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = defaultSprite; 
    }

    void OnMouseDown()
    {
        spriteRenderer.sprite = clickedSprite;
        
    }

    void OnMouseUp()
    {
        spriteRenderer.sprite = defaultSprite;
        SceneManager.LoadScene("Level_1");
    }
}
    

