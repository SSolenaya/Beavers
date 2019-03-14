using UnityEngine;

namespace Assets.Scripts {
    public class SoundController: MonoBehaviour {
        public static SoundController inst;
        public AudioSource backgroundMusic;

        public void Awake () {
            inst = this;
        }

        public void SwitchSound (bool statusOfSound) {
            backgroundMusic.mute = !statusOfSound;
        }

        public void Start () {

        }

    }


}