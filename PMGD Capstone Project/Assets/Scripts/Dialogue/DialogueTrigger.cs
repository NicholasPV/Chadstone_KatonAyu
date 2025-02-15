using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TriggerMethod { TRIGGER, DIALOGUE_INTERACT}
//[RequireComponent(typeof(DialogueTrigger))]
public class DialogueTrigger : MonoBehaviour
{
    public TriggerMethod triggerMethod;
    public int currentDialogue;
    public Dialogue[] dialogue;

    [Header("Requirment")]
    //[SerializeField] DialoguableObject dialogueObject;
    [SerializeField] InteractableObject interactableObject;
    //[SerializeField] DialogueHandler dialogueHandler;

    private void Start()
    {
        //dialogueHandler = GetComponent<DialogueHandler>();

        if (triggerMethod == TriggerMethod.DIALOGUE_INTERACT)
        {
            //dialogueObject = gameObject.GetComponent<DialoguableObject>();
            interactableObject = gameObject.GetComponent<InteractableObject>();
        }
    }

    private void Update()
    {
        if(triggerMethod == TriggerMethod.DIALOGUE_INTERACT)
        {
            /*if (dialogueObject.isThereDialogue)
            {
                TriggerDialogue();
                dialogueObject.isThereDialogue = false;
                *//*PlayerStats.instance.isPlayerDialogue = false;*//*
            }*/

            if (interactableObject.isInteracted)
            {
                TriggerDialogue();
                interactableObject.isInteracted = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TriggerDialogue();
        }
    }

    [ContextMenu("Trigger Dialogue")]
    public void TriggerDialogue()
    {
        //FindObjectOfType<DialogueManager>().StartDialogue(dialogue[dialogueHandler.currentDialogue]);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue[currentDialogue], this);
        Debug.Log("Dialogue Is Started");
    }
}
