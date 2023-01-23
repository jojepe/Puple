using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameManager gm;

    private void Start()
    {
        GetComponentInChildren<TMPro.TextMeshProUGUI>().gameObject.LeanScale(new Vector3(1.2f, 1.2f), 0.5f).setLoopPingPong();
    }

    public void Play()
    {
        GetComponent<CanvasGroup>().LeanAlpha(0, 0.2f).setOnComplete(OnComplete);
        
    }

    private void OnComplete()
    {
        gm.Enable();
        Destroy(gameObject);
    }
}
