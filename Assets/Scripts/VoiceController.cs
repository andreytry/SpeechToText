using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpeech;
using UnityEngine.UI;
using UnityEngine.Android;


public class VoiceController : MonoBehaviour
{
    const string LANG_CODE = "en-US";

    [SerializeField]
    Text uiText;

    private void Start()
    {
        Setup(LANG_CODE);

        SpeechToText.instance.onResultCallback = OnFinalSpeechResult;
#if UNITY_ANDROID
        SpeechToText.instance.onPartialResultsCallback = OnPartialSpeechResult;
#endif

        TextToSpeech.instance.onStartCallBack = OnSpeakStart;
        TextToSpeech.instance.onDoneCallback = OnSpeakStop;
        CheckPermission();
    }
    void Setup(string code)
    {
        TextToSpeech.instance.Setting(code, 1, 1);
        SpeechToText.instance.Setting(code);
    }

    void CheckPermission()
    {
#if UNITY_ANDROID
        if (! Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
#endif
    }

#region Text to speech
    public void StartSpeaking(string message)
    {
        TextToSpeech.instance.StartSpeak(message);
    }

    void OnSpeakStart()
    {
        Debug.Log("Started speaking...");
    }

    void OnSpeakStop()
    {
        Debug.Log("Stopped speaking...");
    }
#endregion

#region Speech to text

    public void StartListening()
    {
        SpeechToText.instance.StartRecording();
        Debug.Log("StartListning");
    }
    public void StopListening()
    {
        SpeechToText.instance.StopRecording();
        Debug.Log("StopListning");
    }

    void OnFinalSpeechResult(string result)
    {
        uiText.text = result;
    }

    void OnPartialSpeechResult(string result)
    {
        uiText.text = result;
    }

    public void StopSpealing()
    {
        TextToSpeech.instance.StopSpeak();
    }

    #endregion


}
