using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI: MonoBehaviour {

    public Button btnPlayGame;
    public Button btnFacebook;
    public Button btnTwitter;
    public Button btnSound;

    public Button btnEasy;
    public Button btnMedium;
    public Button btnHard;

    [SerializeField] private bool isSoundOn = true; //salt1 это лучше унести в SavePrefs

    public Sprite soundOff;
    public Sprite soundOn;

    void Start () {

        btnPlayGame.onClick.RemoveAllListeners();
        btnPlayGame.onClick.AddListener(() => {

            SceneManager.LoadScene("game", LoadSceneMode.Single);
        });

        btnTwitter.onClick.RemoveAllListeners();
        btnTwitter.onClick.AddListener(() => { Application.OpenURL("http://twitter.com/"); });

        btnFacebook.onClick.RemoveAllListeners();
        btnFacebook.onClick.AddListener(() => { Application.OpenURL("http://facebook.com/"); });

        btnSound.onClick.RemoveAllListeners();
        btnSound.onClick.AddListener(() => {
            if(isSoundOn) {
                btnSound.image.sprite = soundOff;
                isSoundOn = false;
                SoundController.inst.SwitchSound(isSoundOn);


            } else {
                btnSound.image.sprite = soundOn;
                isSoundOn = true;
                SoundController.inst.SwitchSound(isSoundOn);
            }

        });

        btnEasy.onClick.RemoveAllListeners();
        btnEasy.onClick.AddListener(() => { LevelController.inst.EasyLevel(); });

        btnMedium.onClick.RemoveAllListeners();
        btnMedium.onClick.AddListener(() => { LevelController.inst.MediumLevel(); });

        btnHard.onClick.RemoveAllListeners();
        btnHard.onClick.AddListener(() => { LevelController.inst.HardLevel(); });

    }




    void Update () { //salt2 если функции монобехевера не юзаются - хорошая практика их дропать


    }
}
