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

        public int Lives {
            get => _lives >= 0 ? _lives : 0;
            set => _lives = value;
        }
           

        public List<Image> hearts = new List<Image>(GP.numOfLives);

        public int CountPoints() {
            points += GP.pointsForBeaver;
            ShowScore();
            return points;

        }

        public void CountLives() {
            Lives -= 1;
            hearts[Lives].gameObject.SetActive(false);
            if (_lives <= 0) {
                alive = false;
                MainLogic.inst.GameEnd();
            }
        }

        void Awake() {
            inst = this;
            

        }

        public void ShowScore() {
            currentScoreText.text = "Score: " + points;
           }


        public void SaveHighScore () {
            if(points > highScore) {
                PlayerPrefs.SetInt("High score", points);
                PlayerPrefs.Save();
                Debug.Log("New High score added to SavePrefs" + points);
            }
        }

        public void LoadHighScoreFromPlayerPrefs() {
            if(PlayerPrefs.HasKey("High score")) {
                highScore = PlayerPrefs.GetInt("High score", 0);
                highScoreText.text = "High score: " + highScore;
                Debug.Log("New High score loaded from SavePrefs" + highScore);
            } else {
                highScoreText.text = "High score: " + 0;
                Debug.Log("SavePrefs don't see key High score");
            }
        }

        public void StateOnStart() {
            Lives = GP.numOfLives;
            points = 0;
            foreach(var heart in hearts) {
                heart.gameObject.SetActive(true);
            }
            ShowScore();
            LoadHighScoreFromPlayerPrefs();

        }

        void Start() {
            
            StateOnStart();
            

        }


    }
}