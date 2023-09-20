using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class UI_Assistant : MonoBehaviour
{
    [SerializeField] private TextWriter textWriter;
    public float TypingSpeed;
    public int FrameRate;
    private Text messageText;
    private string msg;
    private AudioSource TypingAudioSource;
    
    private void Awake() {
        messageText = transform.Find("Message").Find("Text").GetComponent<Text>();
        TypingAudioSource = transform.Find("TypingSound").GetComponent<AudioSource>();

        Application.targetFrameRate = FrameRate;
        transform.Find("Message").GetComponent<Button_UI>().ClickFunc = () => {
            string[] messageArray = new string[] {
                "salam va dorod!",
                "chahar hezar sal ghabl az milad masih",
                "be soorat kholase kiram to hossein",
                "angosht kardan hossein >>>> harchi",
                "unity kirie nemidonam chejori az halat random text dadan kharejesh konam"
            };

            string msg = messageArray[Random.Range(0, messageArray.Length)];
            StartTypingSound();
            textWriter.AddWriter(messageText, msg, TypingSpeed, true, StopTypingSound);

        };
    }

    private void StartTypingSound(){
        TypingAudioSource.Play();
    }
   
    private void StopTypingSound() {
        TypingAudioSource.Stop();
    }

    private void Start() {
        StopTypingSound();
    }
}
