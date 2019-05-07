using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts {

    public class MainLogic : MonoBehaviour {

        public bool state; // для отслеживания режима игры и паузы/окончания
        public Button btnPause;
        public Button btnContinue;
        public Button btnPlayAgain;
        public Button btnMainMenu;
        public GameObject pausedScreen;
        public GameObject gameEndScreen;

        public static MainLogic inst;

        public IEnumerator IEnumWaiting() {
            yield return new WaitForSeconds(2f);
            state = false;
            Time.timeScale = 0;
            gameEndScreen.SetActive(true);

        } 

        public void GameStart() {
            Time.timeScale = 1;
            state = true;
            EntityController.inst.StartGenerationOfBeavers();
            PlayerController.inst.StateOnStart();
        }

        public void GameEnd() {
            StartCoroutine(IEnumWaiting());
            EntityController.inst.Reset();
            LevelController.Reset();
            PlayerController.inst.SaveHighScore();

        }

        void Start() {
            btnPause.onClick.RemoveAllListeners();
            btnPause.onClick.AddListener(() => {
                state = false;
                Time.timeScale = 0;
                pausedScreen.SetActive(true);
            });

            btnContinue.onClick.RemoveAllListeners();
            btnContinue.onClick.AddListener(() => {
                state = true;
                Time.timeScale = 1;
                pausedScreen.SetActive(false);
            });

            btnMainMenu.onClick.RemoveAllListeners();
            btnMainMenu.onClick.AddListener(() => {
                SceneManager.LoadScene("main", LoadSceneMode.Single);
                state = false;
                EntityController.inst.Reset();
            });

            btnPlayAgain.onClick.RemoveAllListeners();
            btnPlayAgain.onClick.AddListener(() => {
                gameEndScreen.SetActive(false);
                Time.timeScale = 1;
                GameStart();
                
            });
            GameStart();
        }

        public void Awake() {
            inst = this;
        }


    }
}