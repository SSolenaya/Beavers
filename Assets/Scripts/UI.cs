using Assets.Scripts;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI: MonoBehaviour
{

    public Button btnPlayGame;
    public Button btnFacebook;
    public Button btnTwitter;
    public Button btnSound;

    public Button btnEasy;
    public Button btnMedium;
    public Button btnHard;

    public Text easy;
    public Text med;
    public Text hard;

    [SerializeField] private bool isSoundOn = true;

    public Sprite soundOff;
    public Sprite soundOn;

    void Start () {

        btnPlayGame.onClick.RemoveAllListeners();
        btnPlayGame.onClick.AddListener(() => {

            SceneManager.LoadScene("game", LoadSceneMode.Single);
        });

        btnTwitter.onClick.RemoveAllListeners();
        btnTwitter.onClick.AddListener(() => {
            
            Application.OpenURL("http://twitter.com/");
        });
        

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


        

    }


}
