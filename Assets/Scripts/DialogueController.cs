using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;
using Newtonsoft.Json;

public class DialogueController : MonoBehaviour
{
    public Text textBox;
    public float textInterval; // The speed at which text will type into the text box.

    private Queue<string> dialogueQueue = new Queue<string>();
    private StringBuilder stringBuf = new StringBuilder("");
    private bool dialogueActive = false;
    private static string[] alphaCodes = {
        "<color=#00000040>",
        "<color=#00000080>",
        "<color=#000000bf>",
        "<color=#000000ff>",
    };
    private Dictionary<string, List<string>> dialogueDict = new Dictionary<string, List<string>>();

    // Places a dialogue list associated with the given reference string into the queue for playback.
    public void EnqueueDialogue(string dialogueRef)
    {
        dialogueQueue.Enqueue(dialogueRef);
    }

    // Read our all of our dialogue from a json file and serialize it.
    void Start()
    {
        string path = Application.dataPath + "/Dialogue.json";
        string jsonData = File.ReadAllText(path);
        dialogueDict = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(jsonData);
        EnqueueDialogue("test");
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
        for (int i = alphaCodes.Length - 1; i > 0; i--)
        {
            stringBuf.Replace(alphaCodes[i - 1], alphaCodes[i]);
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
        return dialogueDict[dialogueRef];
    }
}
