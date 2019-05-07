using Assets.Scripts;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI: MonoBehaviour
{

    public Button btnRules;
    public Button btnPlayGame;
    public Button btnFacebook;
    public Button btnTwitter;
    public Button btnSound;

    public Button btnEasy;
    public Button btnMedium;
    public Button btnHard;

    public static UI inst;

    public void ChangeTheScene(string nameScene) {
        SceneManager.LoadScene(nameScene, LoadSceneMode.Single);
    }

    void Awake() {
        inst = this;
    }

    void Start () {

        btnRules.onClick.RemoveAllListeners();
        btnRules.onClick.AddListener(() => {
            ChangeTheScene("rules");
            });

        btnTwitter.onClick.RemoveAllListeners();
        btnTwitter.onClick.AddListener(() => {
            Application.OpenURL("http://twitter.com/");
        });

        btnPlayGame.onClick.RemoveAllListeners();
        btnPlayGame.onClick.AddListener(() => {
            ChangeTheScene("game");
        });

        btnTwitter.onClick.RemoveAllListeners();
        btnTwitter.onClick.AddListener(() => {
            Application.OpenURL("http://twitter.com/");
        });
        

        btnFacebook.onClick.RemoveAllListeners();
        btnFacebook.onClick.AddListener(() => {
            Application.OpenURL("http://facebook.com/");
        });

        btnSound.onClick.RemoveAllListeners();
        btnSound.onClick.AddListener(() => {
           
            SoundController.inst.SwitchSound();
        });

        btnEasy.onClick.RemoveAllListeners();
        btnEasy.onClick.AddListener(() => {
            btnEasy.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
            btnMedium.transform.localScale = new Vector3(1f, 1f, 1f);
            btnHard.transform.localScale = new Vector3(1f, 1f, 1f);
            LevelController.EasyLevel();
        });
        
        btnMedium.onClick.RemoveAllListeners();
        btnMedium.onClick.AddListener(() => {
            btnEasy.transform.localScale = new Vector3(1f, 1f, 1f);
            btnMedium.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
            btnHard.transform.localScale = new Vector3(1f, 1f, 1f);
            LevelController.MediumLevel();
        });

        btnHard.onClick.RemoveAllListeners();
        btnHard.onClick.AddListener(() => {
            btnEasy.transform.localScale = new Vector3(1f, 1f, 1f);
            btnMedium.transform.localScale = new Vector3(1f, 1f, 1f);
            btnHard.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
            LevelController.HardLevel();
        });

        btnEasy.onClick.Invoke();
        

    }


}
