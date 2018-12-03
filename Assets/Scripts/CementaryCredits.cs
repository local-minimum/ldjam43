﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CementaryCredits : MonoBehaviour {

    [SerializeField]
    Text prefab;

    [SerializeField]
    RectTransform scroller;

    Vector2 anchorMin;
    Vector2 anchorMax;

    [SerializeField]
    Text reason;

    bool scroll = false;

    private void Awake()
    {
        anchorMin = scroller.anchorMin;
        anchorMax = scroller.anchorMax;
        reason.text = GameSession.GameOverReason;
    }

    public void ShowCredits()
    {
        BuildCredits();
        scroll = true;
    }

    void BuildCredits()
    {
        AddHeader("Obituaries");
        int i = 0;
        foreach (string obituary in GameSession.Obituaries())
        {
            AddLine(obituary);
            i += 1;
        }
        if (i == 0)
        {
            AddLine("RIP trains");
            AddLine("You were never on time.");
            AddLine("You had too many incidents and accidents.");
        }

        AddHeader("Credits");
        AddLine("LostMinds: Graphics");
        AddLine("Local Minimum: Code");
        AddLine("Jonas: Code");
        AddLine("PicaPica & Hanna: Ideas");
        AddLine("");
        AddHeader("Thanks for playing");
    }

    void AddHeader(string msg)
    {
        AddLine("");
        AddLine(msg, true);
    }

    void AddLine(string msg)
    {
        AddLine(msg, false);
    }

    void AddLine(string msg, bool header)
    {
        Text text = Instantiate(prefab);
        text.text = msg;
        if (header) text.fontStyle = FontStyle.Bold;
        text.rectTransform.SetParent(scroller);
    }

    [SerializeField]
    float scrollSpeed = 0.2f;

    void Update()
    {
        if (scroll)
        {
            anchorMin.y += Time.deltaTime * scrollSpeed;
            anchorMax.y = anchorMin.y;
            scroller.anchorMax = anchorMax;
            scroller.anchorMin = anchorMin;
        }
    }

    public void PlayMore()
    {
        GameSession.LoadLastLevel();
    }
}
