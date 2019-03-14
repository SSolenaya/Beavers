using System.Runtime.CompilerServices;
using UnityEngine;

namespace Assets.Scripts
{
    public class Sound_Controller: MonoBehaviour
    {
        public static Sound_Controller inst;
        public AudioSource background_music;

        public void Awake()
        {
            inst = this;
        }

        public void Switch_sound(bool status_of_sound)
        {
            background_music.mute = !status_of_sound;
        }

        public void Start()
        {
            
        }

    }

    
}