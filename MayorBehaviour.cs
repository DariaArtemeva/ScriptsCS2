using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayorBehaviour : MonoBehaviour
{
    [SerializeField]
    Dialogue dialogue;
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
        if (playerInRange && Input.GetMouseButtonDown(0) && !DialogueManager.Instance.IsDialogueBoxActive)
        {
            Debug.Log("Trying to interact...");
            Interact();
        }
    }

    void Interact()
    {
        Debug.Log($"IsDialogueBoxActive: {DialogueManager.Instance.IsDialogueBoxActive}, IsTyping: {DialogueManager.Instance.IsTyping}, dialogueFinished: {DialogueManager.Instance.dialogueFinished}");
        if (!DialogueManager.Instance.IsDialogueBoxActive && !DialogueManager.Instance.IsTyping && !DialogueManager.Instance.dialogueFinished)
        {
            Debug.Log("Starting dialogue...");
            StartCoroutine(DialogueManager.Instance.ShowDialogue(dialogue));
        }
    }




}
