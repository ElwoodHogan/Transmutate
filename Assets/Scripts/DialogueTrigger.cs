using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueController dialogueController;
    public string dialogueRef;

    void OnTriggerEnter(Collider other)
    {
        dialogueController.EnqueueDialogue(dialogueRef);
        Destroy(gameObject);
    }
}