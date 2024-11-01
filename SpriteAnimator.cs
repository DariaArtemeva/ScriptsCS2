using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    public Sprite[] sprites; 
    private int currentSpriteIndex = 0; 
    private float timer = 0; 
    private float frameRate = 0.2f; 

    private void Update()
    {
        if (sprites.Length == 0) return;

        timer += Time.deltaTime; 

        if (timer >= frameRate)
        {
            timer -= frameRate; 
            currentSpriteIndex++; 
            if (currentSpriteIndex >= sprites.Length)
            {
                currentSpriteIndex = 0;
            }

            GetComponent<SpriteRenderer>().sprite = sprites[currentSpriteIndex]; 
        }
    }
}

