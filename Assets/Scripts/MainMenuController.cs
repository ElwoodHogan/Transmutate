using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Text menuText;
    public Image menuBackground;
    public float glimmerInterval;
    public string sceneName;

    private bool glimmerAvailable = true;
    private bool runMenu = true;
    private int glimmerIndex = 0;
    private static string[] glimmerStrings = {
        "<color=#FFFFFFFF>Press 'Enter' to play</color>",
        "<color=#FFFFFFEF>Press 'Enter' to play</color>",
        "<color=#FFFFFFDF>Press 'Enter' to play</color>",
        "<color=#FFFFFFCF>Press 'Enter' to play</color>",
        "<color=#FFFFFFBF>Press 'Enter' to play</color>",
        "<color=#FFFFFFAF>Press 'Enter' to play</color>",
        "<color=#FFFFFF9F>Press 'Enter' to play</color>",
        "<color=#FFFFFF8F>Press 'Enter' to play</color>",
        "<color=#FFFFFF7F>Press 'Enter' to play</color>",
        "<color=#FFFFFF6F>Press 'Enter' to play</color>",
        "<color=#FFFFFF5F>Press 'Enter' to play</color>",
        "<color=#FFFFFF4F>Press 'Enter' to play</color>",
        "<color=#FFFFFF3F>Press 'Enter' to play</color>",
        "<color=#FFFFFF2F>Press 'Enter' to play</color>",
        "<color=#FFFFFF1F>Press 'Enter' to play</color>",
        "<color=#FFFFFF0F>Press 'Enter' to play</color>",
        "<color=#FFFFFF1F>Press 'Enter' to play</color>",
        "<color=#FFFFFF2F>Press 'Enter' to play</color>",
        "<color=#FFFFFF3F>Press 'Enter' to play</color>",
        "<color=#FFFFFF4F>Press 'Enter' to play</color>",
        "<color=#FFFFFF5F>Press 'Enter' to play</color>",
        "<color=#FFFFFF6F>Press 'Enter' to play</color>",
        "<color=#FFFFFF7F>Press 'Enter' to play</color>",
        "<color=#FFFFFF8F>Press 'Enter' to play</color>",
        "<color=#FFFFFF9F>Press 'Enter' to play</color>",
        "<color=#FFFFFFAF>Press 'Enter' to play</color>",
        "<color=#FFFFFFBF>Press 'Enter' to play</color>",
        "<color=#FFFFFFCF>Press 'Enter' to play</color>",
        "<color=#FFFFFFDF>Press 'Enter' to play</color>",
    };

    void Update()
    {
        if (runMenu & Input.GetKeyDown(KeyCode.Return)) {
            runMenu = false;
        }
        else if (!runMenu & glimmerIndex == 0)
        {
            menuText.text = "<color=#FFFFFFFF>Loading...</color>";
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
        else if (glimmerAvailable)
        {
            glimmerAvailable = false;
            StartCoroutine(Glimmer());
        }
    }
    
    private IEnumerator Glimmer()
    {
        _Glimmer();
        yield return new WaitForSeconds(glimmerInterval);
        glimmerAvailable = true;
    }

    private void _Glimmer()
    {
        glimmerIndex++;
        if (glimmerIndex >= glimmerStrings.Length)
        {
            glimmerIndex = 0;
        }
        menuText.text = glimmerStrings[glimmerIndex];
    }
}
