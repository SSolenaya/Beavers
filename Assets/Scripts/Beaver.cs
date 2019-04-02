using System.Collections;
using Assets.Scripts;
using Unity.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Beaver: Entity {

    public Sprite white;
    public Sprite red;
    
    public void StatusOfBeaver () {
        var temp = Random.value;
        status = temp > 0.5;
        img.sprite = status ? red : white;

    }

    public override void PlaySoundOnClick() {
        SoundController.inst.PlaySoundKickBeaver();
    }

    public override void CountPointsOrLivesForClick() {
        if(status) {
            PlayerController.inst.CountPoints();
            
        } else {
            PlayerController.inst.CountLives();
        }
    }

    public override void CountPointsOrLivesForSkip () {
        if(status) {
            PlayerController.inst.CountLives();
            } else {
            PlayerController.inst.CountPoints();
        }
    }

    public void Start () {
        StatusOfBeaver();
    }

}
