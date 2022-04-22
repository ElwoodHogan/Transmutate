using System;
using UnityEngine;

public class FrontMan : MonoBehaviour
{

    public Camera MainCam;

    public GameObject Player;

    public CanvasAI Canvas;

    public static FrontMan FM;

    public Action OnUpdate;

    public LayerMask Shootable;

    private void Awake()
    {
        FM = this;
    }

    private void Update()
    {
        OnUpdate?.Invoke();
    }

}
