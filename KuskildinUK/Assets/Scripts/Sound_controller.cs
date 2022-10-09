using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]  //Обязательный компонент AudioSource
public class Sound_controller : MonoBehaviour
{
    [SerializeField] private Scrollbar scrollbar;
    [SerializeField] private Text volume_value_text;
    private AudioSource audio_source;
    private float sound_value;
    private void Start()
    {
        audio_source = GetComponent<AudioSource>();
        sound_value = PlayerPrefs.GetFloat("volume");
        scrollbar.value = sound_value;
    }
    private void FixedUpdate()
    {
        sound_value = scrollbar.value; //меняет значение громкости, в зависимости от положения ползунка
        audio_source.volume = sound_value;
        volume_value_text.text = "Звук: " + Mathf.Round(sound_value * 100) + "%";
        PlayerPrefs.SetFloat("volume", sound_value);
    }
}
