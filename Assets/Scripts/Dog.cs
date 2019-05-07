using System.Collections;
using Assets.Scripts;
using Unity.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Dog: Entity {

    public override void StatusOfEntity () {
        status = true;
    }

   
    public override void PlaySoundOnClick () {
        SoundController.inst.PlaySoundForKick();
    }

    public override void CountPointsOrLivesForClick () {
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
        StatusOfEntity();
    }

}
