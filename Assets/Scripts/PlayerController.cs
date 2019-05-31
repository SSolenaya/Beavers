using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts {

    public class PlayerController: MonoBehaviour {
        public static PlayerController inst;

        public bool alive = true; // наличие жизней
        public Text currentScoreText;
        public Text highScoreText;
        [SerializeField] private int highScore;
        private string highScoreNameTxt;
        private string scoreNameTxt;
        public int points;
        public float coefMultiplying = GP.coefSeries;
        private int _lives;
        public int lives {
            get => _lives >= 0 ? _lives : 0;
            set => _lives = value;
        }
        public List<Heart> hearts = new List<Heart>(GP.numOfLives);

        public void ScoreMultiplier (bool action) {
            if(action) {
                points += (int)(coefMultiplying * GP.pointsForBeaver);
                coefMultiplying += GP.deltaCoefSeries;
            } else {
                coefMultiplying = GP.coefSeries;
            }
        }

        public int CountPoints () {
            ScoreMultiplier(true);
            ShowScore(points);
            return points;

        }

        public void CountLives () {
            ScoreMultiplier(false);
            lives -= 1;
            hearts[lives].HideHearts();
            if(_lives > 0)
                return;
            alive = false;
            MainLogic.inst.GameEnd();
        }

        void Awake () {
            inst = this;
        }

        public void ShowScore (int p) {

            if(points <= 10000) { currentScoreText.text = scoreNameTxt + ":" + p; }
            if(points >= 10000 && points <= 1000000) { currentScoreText.text = scoreNameTxt + ":" + p / 1000 + "K"; }
            if(points >= 1000000) { currentScoreText.text = scoreNameTxt + ":" + p / 1000000 + "M"; }

        }

        public void ShowHighScore (int hs) {
            if(highScore <= 10000) { highScoreText.text = highScoreNameTxt + ":" + hs; }
            if(highScore >= 10000 && highScore <= 1000000) { highScoreText.text = highScoreNameTxt + ":" + hs / 1000 + "K"; }
            if(highScore >= 1000000) { highScoreText.text = highScoreNameTxt + ":" + hs / 1000000 + "M"; }

        }


        public void SaveHighScore () {
            if(points > highScore) {
                PlayerPrefs.SetInt(highScoreNameTxt, points);
                PlayerPrefs.Save();
               }
        }

        public void LoadHighScoreFromPlayerPrefs () {
            if(PlayerPrefs.HasKey(highScoreNameTxt)) {
                highScore = PlayerPrefs.GetInt(highScoreNameTxt, 0);
                ShowHighScore(highScore);
                } else {
                ShowHighScore(0);
               
            }
        }

        public void StateOnStart () {
            lives = GP.numOfLives;
            foreach(var heart in hearts) {
        heart.ShowHearts();
            }
            ShowScore(points = 0);
            LoadHighScoreFromPlayerPrefs();

        }

        void Start () {

            StateOnStart();
            highScoreNameTxt = "High score";
            scoreNameTxt = "Score";


        }
     }
}