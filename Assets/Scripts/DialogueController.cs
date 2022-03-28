using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    private Queue<string> DialogueQueue = new Queue<string>();
    private bool DialogueActive = false;

    void Update()
    {
        if (!DialogueActive)
        {
            if (DialogueQueue.Count > 0)
            {
                DialogueActive = true;
                StartCoroutine(PlayDialogue(DialogueQueue.Dequeue()));
            }
        }
    }

    private IEnumerator PlayDialogue(string dialogueRef)
    {
        // Placeholder
        DialogueActive = false;
        return null;
    }

    public void EnqueueDialogue(string dialogueRef)
    {
        DialogueQueue.Enqueue(dialogueRef);
    }
}
