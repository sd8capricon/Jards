using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSound : MonoBehaviour
{
    private Sprite ONAudioimg;
    public Sprite OFFAudioimg;
    public Button button;
    public static string soundValue;
    public static bool isOn = true;
    // Start is called before the first frame update
    public static AudioSource audioSource;
    void Start()
    {
        audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        ONAudioimg = button.image.sprite;
        /*soundValue = PlayerPrefs.GetString("SoundState", "false");
        Debug.Log(soundValue);
        PlayerPrefs.SetString("SoundState", "true"); 
        soundValue = PlayerPrefs.GetString("SoundState", "false");
        Debug.Log(soundValue);*/

        audioSource.Play();
        DontDestroyOnLoad(audioSource);

        if(isOn == false)
        {
            button.image.sprite = OFFAudioimg;
        }
    }
        
    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonClicked()
    {
        if(isOn)
        {
            button.image.sprite = OFFAudioimg;
            isOn = false;
            audioSource.mute = true;
        }
        else
        {
            button.image.sprite = ONAudioimg;
            isOn = true;
            audioSource.mute = false;
        }
    }
}
           

