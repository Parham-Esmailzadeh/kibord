using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    private Text uiText;
    private string textToWrite;
    private float timePerCharacter;
    private float timer;
    private int characterIndex;
    private bool invisibleCharecters;
    private Action onComplete;

    public void AddWriter(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharecters, Action onComplete) {
        this.uiText = uiText;
        this.textToWrite = textToWrite;
        this.timePerCharacter = timePerCharacter;
        this.onComplete = onComplete;
        characterIndex = 0;
    }

    private void Update(){
        if (uiText != null) {
            timer -= Time.deltaTime;
            while (timer <= 0f) {
                timer += timePerCharacter;
                characterIndex++;
                string text = textToWrite.Substring(0, characterIndex);
                if (invisibleCharecters) {
                    text += "<color=#00000000>" + textToWrite.Substring(characterIndex) + "</color>";
                }
                uiText.text = text;

                if (characterIndex >= textToWrite.Length){
                    if (onComplete!=null) onComplete();
                    uiText = null;
                    return;
                }
            }
        }
    }
}