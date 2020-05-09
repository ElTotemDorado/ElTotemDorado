using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenúOpciones : MonoBehaviour
{
    public AudioMixer audioMixer;

    private void Start()
    {
        
    }
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("volume", volume);
        PlayerPrefs.Save();
    }

    public void SetQuality (int qualityIndex)
    {
        Debug.Log("voy a cambiar calidad");
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
