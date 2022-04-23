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
    public Image textBoxBackground;
    public string entryRef; // First dialogue ref to be played immediately.
    public float textInterval; // The speed at which text will type into the text box.
    public float pauseInterval; // The delay between displaying new lines of text.

    public bool dialogueActive = false;

    private Queue<string> dialogueQueue = new Queue<string>();
    private StringBuilder stringBuf = new StringBuilder("");
    private static string[] alphaCodes = {
        "<color=#FFFFFF40>",
        "<color=#FFFFFF80>",
        "<color=#FFFFFFBF>",
        "<color=#FFFFFFFF>",
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
        EnqueueDialogue(entryRef);
    }

    void Update()
    {
        if (!dialogueActive)
        {
            if (dialogueQueue.Count > 0)
            {
                dialogueActive = true;
                string nextRef = dialogueQueue.Dequeue();
                StartCoroutine(PlayDialogue(nextRef));
            }
        }
    }

    private IEnumerator PlayDialogue(string dialogueRef)
    {
        ShowBackground();
        foreach (string dialogueLine in GetDialogue(dialogueRef))
        {
            for (int i = 0; i < dialogueLine.Length + alphaCodes.Length; i++)
            {
                UpdateBufAlpha();
                if (i < dialogueLine.Length)
                {
                    AppendBufChar(dialogueLine[i]);
                }
                UpdateTextBox();
                yield return new WaitForSeconds(textInterval);
            }
            yield return new WaitForSeconds(pauseInterval);
            stringBuf.Clear();
        }
        UpdateTextBox();
        HideBackground();
        dialogueActive = false;
    }

    // Updates the text box to display the current string buffer.
    private void UpdateTextBox()
    {
        textBox.text = stringBuf.ToString();
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

    // Shows the textbox background
    private void ShowBackground()
    {
        textBoxBackground.enabled = true;
    }

    // Hides the textbox background
    private void HideBackground()
    {
        textBoxBackground.enabled = false;
    }
}
