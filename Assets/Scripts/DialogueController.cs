using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class DialogueController : MonoBehaviour
{
    public Text textBox;
    public float textInterval; // The speed at which text will type into the text box.

    private Queue<string> dialogueQueue = new Queue<string>();
    private StringBuilder stringBuf = new StringBuilder("");
    private bool dialogueActive = false;
    private static string[] alphaCodes = {
        "<color=#ffffff40>",
        "<color=#ffffff80>",
        "<color=#ffffffbf>",
        "<color=#ffffffff>",
    };

    // Places a dialogue sequence associated with the given reference string into the queue for playback.
    public void EnqueueDialogue(string dialogueRef)
    {
        dialogueQueue.Enqueue(dialogueRef);
    }

    void Update()
    {
        if (!dialogueActive)
        {
            if (dialogueQueue.Count > 0)
            {
                dialogueActive = true;
                StartCoroutine(PlayDialogue(dialogueQueue.Dequeue()));
            }
        }
    }

    private IEnumerator PlayDialogue(string dialogueRef)
    {
        foreach (string dialogueLine in GetDialogue(dialogueRef))
        {
            for (int i = 0; i < dialogueLine.Length + alphaCodes.Length; i++)
            {
                UpdateBufAlpha();
                if (i < dialogueLine.Length)
                {
                    AppendBufChar(dialogueLine[i]);
                }
                textBox.text = stringBuf.ToString();
                yield return new WaitForSeconds(textInterval);
            }
            stringBuf.Clear();
        }
        dialogueActive = false;
    }

    // Increments the alpha (transparency) of each character in the string buffer by one level.
    private void UpdateBufAlpha()
    {
        for (int i = 0; i < alphaCodes.Length - 1; i++)
        {
            stringBuf.Replace(alphaCodes[i], alphaCodes[i + 1]);
        }
    }

    // Appends a new character to the string buffer, with its alpha (transparency) set at the lowest level.
    private void AppendBufChar(char c)
    {
        stringBuf.AppendFormat("{0}{1}</color>", alphaCodes[0], c);
    }

    // Returns a list of dialogue lines associated with the given reference string.
    private List<string> GetDialogue(string dialogueRef)
    {
        return null; // Placeholder
    }
}
