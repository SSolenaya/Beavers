using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main_Menu: MonoBehaviour {

    public Button new_game_btn;
    public Button sound_btn;
    public Button facebook_btn;
    public Button twitter_btn;
    public AudioSource background_music;

    [SerializeField] private bool sound = true;

    public Sprite sound_off;
    public Sprite sound_on;

    void Start () {
        new_game_btn.onClick.AddListener(Play);
        sound_btn.onClick.AddListener(Sound);
        facebook_btn.onClick.AddListener(Facebook);
        twitter_btn.onClick.AddListener(Twitter);
    }

    public void Play () {
        SceneManager.LoadScene("Game");
    }

    public void Switch_sound (bool sound_game) {
        background_music.mute = !sound_game;
    }

    public void Sound () {
        if(sound) {
            sound_btn.image.sprite = sound_off;
            sound = false;
            Switch_sound(sound);

        } else {
            sound_btn.image.sprite = sound_on;
            sound = true;
            Switch_sound(sound);
        }
    }

    public void Facebook () {
        Application.OpenURL("http://facebook.com/");
    }
    public void Twitter () {
        Application.OpenURL("http://twitter.com/");
    }

    void Update () {

    }
}
