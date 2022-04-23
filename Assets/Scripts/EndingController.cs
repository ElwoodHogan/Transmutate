using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingController : MonoBehaviour
{
    public DialogueController dialogueController;
    public Text creditsText;
    public RawImage toaster;

    private int sceneSegment = 0;

    void LateUpdate()
    {
        if (!dialogueController.dialogueActive)
        {
            switch(sceneSegment)
            {
                case 0:
                    dialogueController.EnqueueDialogue("ending1");
                    toaster.enabled = true;
                    sceneSegment = 1;
                    break;
                case 1:
                    toaster.enabled = false;
                    creditsText.enabled = true;
                    sceneSegment = 2;
                    break;
                case 2:
                    if (Input.GetKeyDown(KeyCode.Return)) { Application.Quit(); }
                    break;
            }
        }
    }
}
