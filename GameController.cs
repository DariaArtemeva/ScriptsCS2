using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { Free, Dialogue }

public class GameController : MonoBehaviour
{
  
    private GameState state;


    public GameState State
    {
        get { return state; }
        private set { state = value; } 
    }

    public static GameController Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        DialogueManager.Instance.OnShowDialogue += () => {
            State = GameState.Dialogue;
        };
        DialogueManager.Instance.OnHideDialogue += () => {
            if (State == GameState.Dialogue)
                State = GameState.Free;
        };
    }

    private void Update()
    {
        if (State == GameState.Free)
        {
            
        }
        else if (State == GameState.Dialogue)
        {
            DialogueManager.Instance.HandleUpdate();
        }
    }
}
