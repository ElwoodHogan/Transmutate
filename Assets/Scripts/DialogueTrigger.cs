using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueController dialogueController;
    public string dialogueRef;

    private bool destroy = false;

    void OnTriggerEnter(Collider other)
    {
        if (destroy) { return; }
        if (other.tag == "Player")
        {
            destroy = true;
            dialogueController.EnqueueDialogue(dialogueRef);
            Destroy(gameObject);
        }
    }
}
