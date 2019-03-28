using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scripts {

    public class PlayerController : MonoBehaviour {
        public static PlayerController inst;

        public bool alive = true; // наличие жизней
        public Text currentScoreText;
        public Text highScoreText;
        [SerializeField]private int highScore;
        public int points;
        private int _lives;
        public int lives {
            get => _lives >= 0 ? _lives : 0;
            set => _lives = value;
        }
        public List<Heart> hearts = new List<Heart>(GP.numOfLives);
        //public Coroutine coroHearts;
        
       

       /* public void StopCoroHearts() {
            if (coroHearts != null) {
                StopCoroutine(coroHearts);
                coroHearts = null;
            }
        }*/

        public int CountPoints() {
            points += GP.pointsForBeaver;
            ShowScore();
            return points;

        }

        public void CountLives() {
            lives -= 1;
           // StopCoroHearts();
            hearts[lives].HideHearts();
            if (_lives > 0) return;
            alive = false;
            MainLogic.inst.GameEnd();
        }

        void Awake() {
            inst = this;
         }

        public void ShowScore() {
            var p = points;
            if(points <= 10000) { currentScoreText.text = "Score: " + p; }
            if(points >= 10000 && points <= 1000000) { currentScoreText.text = "Score: " + p/1000 + "K"; }
            if(points >= 1000000) { currentScoreText.text = "Score: " + p / 1000000 + "M"; }

        }

        public void ShowHighScore () {
            var hs = highScore;
            if(highScore <= 10000) { currentScoreText.text = "Score: " + hs; }
            if(highScore >= 10000 && highScore <= 1000000) { currentScoreText.text = "Score: " + hs / 1000 + "K"; }
            if(highScore >= 1000000) { currentScoreText.text = "Score: " + hs / 1000000 + "M"; }

        }


        public void SaveHighScore () {
            if(points > highScore) {
                PlayerPrefs.SetInt("High score", points);
                PlayerPrefs.Save();
                Debug.Log("New High score added to SavePrefs" + points); //bear
            }
        }

        public void LoadHighScoreFromPlayerPrefs() {
            if(PlayerPrefs.HasKey("High score")) {
                highScore = PlayerPrefs.GetInt("High score", 0);
                highScoreText.text = "High score: " + highScore;
                Debug.Log("New High score loaded from SavePrefs" + highScore); //bear
            } else {
                highScoreText.text = "High score: " + 0;
                Debug.Log("SavePrefs don't see key High score"); //bear
            }
        }

        public void StateOnStart() {
            lives = GP.numOfLives;
            points = 0;
            foreach(var heart in hearts) {
               // StopCoroHearts();
              heart.ShowHearts();
             }
            ShowScore();
            LoadHighScoreFromPlayerPrefs();

        }

        void Start() {
            
            StateOnStart();
            

        }


    }
}