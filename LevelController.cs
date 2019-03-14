using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{

    public float K; // промежуток времени между появлением порций бобров
    public float M; // задержка бобров на экране
    public float N; // количество бобров в порции - одновременно появляются на экране
    public float deltaKandM; // изменение К со временем игры - усложнение геймплея
    public int timeToChange; // промежуток времени для усложнения геймплея, секунды
    public int pointsForBeaver; // очки за правильное действие с бобром
    public float coefSeries; // множитель очков за успешную серию действий игрока
    public float deltaCoefSeries;

    public static Level Controller inst;

        void Awake()
    {
        inst = this;
    }


    public void EasyLevel ()
    {
        K = 4;
        M = 4;
        N = 1;
        deltaKandM = 1.25;
        timeToChange = 120;

        pointsForBeaver = 100;
        coefSeries = 1;
        deltaCoefSeries = 0.25f;
    }

    public void MediumLevel()
    {
        K = 3;
        M = 3;
        N = 1;
        deltaKandM = 1.5;
        timeToChange = 90;

        pointsForBeaver = 200;
        coefSeries = 1.25;
        deltaCoefSeries = 0.5f;
    }

    public void HardLevel()
    {
        K = 2;
        M = 2;
        N = 2;
        deltaKandM = 1.75;
        timeToChange = 60;

        pointsForBeaver = 300;
        coefSeries = 1.5;
        deltaCoefSeries = 0.75f;
    }

IEnumerator BeaversQuantity()
    {
        yield return new WaitForSeconds(timeToChange);
        while (PlayerController.inst.Alive)
        {
            N += 1;
                
        }
    }

    IEnumerator IEnumGameMode()
    {
        yield return new WaitForSeconds(60f);
        while (PlayerController.inst.Alive)
        {
            K /= deltaKandM;
            M /= deltaKandM;

        }
    }


    void Start()
    {
        StartCoroutine(BeaversQuantity());
        StartCoroutine(IEnumGameMode());

    }


    void Update()
    {

    }
}

