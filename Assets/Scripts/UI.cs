using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public Button btn_play_game;
    public Button btn_facebook;
    public Button btn_twitter;
    public Button btn_sound;

    [SerializeField]private bool is_sound_on = true;

    public Sprite sound_off;
    public Sprite sound_on;

    

    
    void Start () {

        btn_play_game.onClick.RemoveAllListeners();
        btn_play_game.onClick.AddListener(() => { SceneManager.LoadScene("game");});

        btn_twitter.onClick.RemoveAllListeners();
        btn_twitter.onClick.AddListener(() => { Application.OpenURL("http://twitter.com/"); });

        btn_facebook.onClick.RemoveAllListeners();
        btn_facebook.onClick.AddListener(() => { Application.OpenURL("http://facebook.com/"); });

        btn_sound.onClick.RemoveAllListeners();
        btn_sound.onClick.AddListener(() =>
        {
            if (is_sound_on)
            {
                btn_sound.image.sprite = sound_off;
                is_sound_on = false;
                Sound_Controller.inst.Switch_sound(is_sound_on);
                

            }
            else
            {
                btn_sound.image.sprite = sound_on;
                is_sound_on = true;
                Sound_Controller.inst.Switch_sound(is_sound_on);
            }

        });

       
    }
	
	
	void Update () {
	 

    }
}
