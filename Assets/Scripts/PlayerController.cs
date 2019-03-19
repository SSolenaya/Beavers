using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
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
        hearts.RemoveAt(0);
        if (lives == 0) {
            MainLogic.inst.GameEnd();
        }
    }

    void Awake()
    {
        inst = this;
    }

    
    
}
