using UnityEngine;

namespace Assets.Scripts {
    public class SoundController: MonoBehaviour {
        public static SoundController inst;
        public AudioSource backgroundMusic;
        public bool statusOfSound = true;

        public Sprite soundOff;
        public Sprite soundOn;

        public void Awake () {
            inst = this;
        }

        public void SwitchSound () {

            backgroundMusic.mute = statusOfSound;

            if(statusOfSound) {
                UI.inst.btnSound.image.sprite = soundOff;
                statusOfSound = false;

            } else {
                UI.inst.btnSound.image.sprite = soundOn;
                statusOfSound = true;
            }

            PlayerPrefs.SetInt("State of sound", statusOfSound ? 1 : 0);
            PlayerPrefs.Save();
        }

        public void Start () {

            backgroundMusic.mute = PlayerPrefs.GetInt("State of sound", 1) != 1;
            UI.inst.btnSound.image.sprite = PlayerPrefs.GetInt("State of sound", 1) == 1 ? soundOn : soundOff;
        }

    }


}