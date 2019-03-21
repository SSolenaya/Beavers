using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts {

    public class PlayerController : MonoBehaviour {
        public static PlayerController inst;

        public bool alive = true; // наличие жизней

        public int points;
        public int lives = GP.numOfLives;

        public List<Image> hearts = new List<Image>(GP.numOfLives);

        public int CountPoints() {
            points += GP.pointsForBeaver;
            return points;
        }

        public void CountLives() {
            lives -= 1;
            hearts[lives].gameObject.SetActive(false);
            if (lives == 0) {
                MainLogic.inst.GameEnd();
            }
        }

        void Awake() {
            inst = this;
            foreach (var heart in hearts) {
                heart.gameObject.SetActive(true);
            }
        }



    }
}