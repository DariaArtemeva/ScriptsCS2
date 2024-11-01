using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource volume;
    public AudioClip thoughts;
    [SerializeField]
    private GameObject dialogueBox;
    [SerializeField]
    Text dialogueText;
    [SerializeField]
    int lettersPerSecond;
    public bool dialogueFinished = false;

 

    public event Action OnShowDialogue;
    public event Action OnHideDialogue;
    public static DialogueManager Instance { get; private set; }
    public bool IsDialogueBoxActive => dialogueBox.activeSelf;



    private void Start()
    {
        StartCoroutine(DelayedStartDialogue());
    }

    private IEnumerator DelayedStartDialogue()
    {
        yield return new WaitForSeconds(2);
        volume.PlayOneShot(thoughts);
    }
    private void Awake()
    {
        Instance = this;
    }
    Dialogue dialogue;
    int currentLine=0;
    bool isTyping;

    public IEnumerator ShowDialogue(Dialogue dialogue)
    {
        dialogueFinished = false;
        currentLine = 0; // Переместите сброс сюда
        if (!dialogueBox.activeSelf)
        {
            OnShowDialogue?.Invoke();
            this.dialogue = dialogue;
            dialogueBox.SetActive(true);
            StartCoroutine(TypeDialogue(dialogue.Lines[0]));
            yield break;
        }
        else
        {
            Debug.Log("Dialogue is already active");
            yield break;
        }
    }



    public void HandleUpdate()
    {
   
        
        if (Input.GetMouseButtonDown(0) && !isTyping && dialogueBox.activeSelf)
        {
            
            if (currentLine == dialogue.Lines.Count - 1)
            {
                Debug.Log("Ending dialogue and resetting dialogueFinished.");
                dialogueBox.SetActive(false);
                OnHideDialogue?.Invoke();
                currentLine = 0;
                dialogueFinished = false;
            }


            else
            {
               
                ++currentLine;
                StartCoroutine(TypeDialogue(dialogue.Lines[currentLine]));
            }
            dialogueFinished = true;
        }
    }




    public IEnumerator TypeDialogue(string line)
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (var letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
        isTyping = false;
        Debug.Log("Finished typing");
    }
    public bool IsTyping
    {
        get { return isTyping; }
    }

}
