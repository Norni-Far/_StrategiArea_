using GeneralThinking;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class S_II_Middle : MonoBehaviour
{
    //
    public S_MainControls S_MainControls;
    General_Thinking_II General_Thinking = new General_Thinking_II();
    //

    //______Tets_____
    public GameObject Update;
    //

    // Prefabs
    public GameObject Prefab_FirstTrain_Enemy;
    public GameObject Prfab_SecondTrain_Enemy;
    //

    // Point ofCreate
    public int CreateTimes = 0; // Количество созданий перед прокачкой 
    public int CreateTimesNow = 0;
    public Transform[] PointOfCreate = new Transform[5];

    private bool StopCreate = false;
    //

    // see
    List<GameObject> TrainOn_1_line = new List<GameObject>();
    List<GameObject> TrainOn_2_line = new List<GameObject>();
    List<GameObject> TrainOn_3_line = new List<GameObject>();
    List<GameObject> TrainOn_4_line = new List<GameObject>();
    List<GameObject> TrainOn_5_line = new List<GameObject>();
    //

    // Flags
    public Transform[] Flags = new Transform[5];
    // 

    /*
    // Warning // секция уровня опатсности путей на рельсах, в зависимости от расстояния флага и поездов на этих путях
    public int[] WarningSections = new int[5];
    public int SrednieArifm = 0;

    public int[] LevelOFWarning = new int[5];
    public int[] Desijion = new int[5];
    //
    */

    // Характеристики 
    private float TimeToThink = 7f;
    //

    private void Start()
    {
        StartCoroutine(StartThink());
    }

    IEnumerator StartThink()
    {
        if (CreateTimes == 0)
            CreateTimes = UnityEngine.Random.Range(1, 6);

        yield return new WaitForSeconds(TimeToThink);

        CheckOFMashine(); // взятие данных от датчииков поля

        //
        General_Thinking.StandarttThink(Flags, TrainOn_1_line, TrainOn_2_line, TrainOn_3_line, TrainOn_4_line, TrainOn_5_line);
        //

        if (!StopCreate && CreateTimes >= CreateTimesNow)
            StartCoroutine(CreateSection());
        else if (CreateTimes < CreateTimesNow && S_MainControls.Resurses_right >= S_MainControls.Lvl_Cost_Right)
            lvlUP_II_middle();


        StartCoroutine(StartThink());
    }

    private void CheckOFMashine()
    {
        TrainOn_1_line = S_MainControls.TrainOn_1_line;
        TrainOn_2_line = S_MainControls.TrainOn_2_line;
        TrainOn_3_line = S_MainControls.TrainOn_3_line;
        TrainOn_4_line = S_MainControls.TrainOn_4_line;
        TrainOn_5_line = S_MainControls.TrainOn_5_line;
    }

    /*
    private void NullWarning()
    {
        for (int i = 0; i < WarningSections.Length; i++)
        {
            WarningSections[i] = 0;
        }

        for (int i = 0; i < LevelOFWarning.Length; i++)
        {
            LevelOFWarning[i] = 0;
        }

        for (int i = 0; i < Desijion.Length; i++)
        {
            Desijion[i] = i;
        }
    }
    */

    /*
    private void InfAboutFlags()  // от 
    {
        for (int i = 0; i < Flags.Length; i++)
        {
            WarningSections[i] = (Convert.ToInt32(DistanceForFlags + Flags[i].position.x)) / 4;
        }
    }
    */

    /*
    private void CheckTrainOnLne()
    {
        foreach (var item in TrainOn_1_line)
        {
            CheckOfTegs(item, 0);
        }

        foreach (var item in TrainOn_2_line)
        {
            CheckOfTegs(item, 1);
        }

        foreach (var item in TrainOn_3_line)
        {
            CheckOfTegs(item, 2);
        }

        foreach (var item in TrainOn_4_line)
        {
            CheckOfTegs(item, 3);
        }

        foreach (var item in TrainOn_5_line)
        {
            CheckOfTegs(item, 4);
        }
    }

    private void CheckOfTegs(GameObject Item_Obj, int Item_Obj_LineNumber)
    {
        if (Item_Obj.gameObject.tag == S_MainControls.Tag_FirstTarin_Player)
            WarningSections[Item_Obj_LineNumber] += 4;
        else if (Item_Obj.gameObject.tag == S_MainControls.Tag_SecondTarin_Player)
            WarningSections[Item_Obj_LineNumber] += 5;

        if (Item_Obj.gameObject.tag == S_MainControls.Tag_FirstTarin_Enemy)
            WarningSections[Item_Obj_LineNumber] -= 4;
    }

    private void ThinkAboutCreate()
    {
        SrednieArifm = 0;

        for (int i = 0; i < WarningSections.Length; i++)
        {
            SrednieArifm += WarningSections[i];
        }

        SrednieArifm = SrednieArifm / WarningSections.Length;

        for (int i = 0; i < WarningSections.Length; i++)
        {
            LevelOFWarning[i] = (WarningSections[i] - SrednieArifm);
        }

        // Sort
        for (int i = 0; i < LevelOFWarning.Length; i++)
        {
            for (int t = 0; t < LevelOFWarning.Length; t++)
            {
                if (LevelOFWarning[i] < LevelOFWarning[t])
                {
                    int a = 0;
                    a = LevelOFWarning[i];
                    LevelOFWarning[i] = LevelOFWarning[t];
                    LevelOFWarning[t] = a;

                    a = Desijion[i];
                    Desijion[i] = Desijion[t];
                    Desijion[t] = a;
                }

            }
        }
    }
    */

    // рандом от 1 до 5 для прокачки 
    // рандом 30% на то, что появится киллер, и если киллер способен выдержать одно столкновение 

    IEnumerator CreateSection()
    {
        int a = UnityEngine.Random.Range(0, 101);

        print("a = " + a);

        if (a <= 30 && S_MainControls.Resurses_right >= S_MainControls.Cost_SecondTrain) // и если выдержит одно столкновении хотя бы
        {
            CreateTimesNow++;

            S_MainControls.Resurses_right -= S_MainControls.Cost_SecondTrain;

            StopCreate = true;

            Instantiate(Prfab_SecondTrain_Enemy, PointOfCreate[General_Thinking.Desijion[General_Thinking.Desijion.Length - 1]].position, PointOfCreate[General_Thinking.Desijion[General_Thinking.Desijion.Length - 1]].rotation);

            yield return new WaitForSeconds(S_MainControls.CreateSpeed_Right);
            StopCreate = false;
        }
        else if (S_MainControls.Resurses_right >= S_MainControls.Cost_FirstTrain)
        {
            CreateTimesNow++;

            S_MainControls.Resurses_right -= S_MainControls.Cost_FirstTrain;

            StopCreate = true;

            Instantiate(Prefab_FirstTrain_Enemy, PointOfCreate[General_Thinking.Desijion[General_Thinking.Desijion.Length - 1]].position, PointOfCreate[General_Thinking.Desijion[General_Thinking.Desijion.Length - 1]].rotation);

            yield return new WaitForSeconds(S_MainControls.CreateSpeed_Right);
            StopCreate = false;
        }

    }

    private void lvlUP_II_middle()
    {
        // test
        Update.GetComponent<Animator>().enabled = true;
        //

        S_MainControls.Resurses_right -= S_MainControls.Lvl_Cost_Right;

        int rnd = UnityEngine.Random.Range(0, 5);

        switch (rnd)
        {
            case 0:
                UP_Strong();
                break;
            case 1:
                UP_Massa();
                break;
            case 2:
                UP_Mines();
                break;
            case 3:
                UP_SpeedOfMove();
                break;
            case 4:
                UP_SpeedOfAttack();
                break;

        }

        CreateTimes = 0;
        CreateTimesNow = 0;
        S_MainControls.Lvl_Up_All_Right++;
        S_MainControls.CheckINF_Right();
    }

    public void UP_Strong()
    {
        S_MainControls.Strong_Right += S_MainControls.Strong_Inf_LevelUP;
    }
    public void UP_Massa()
    {
        S_MainControls.Massa_Right += S_MainControls.Massa_Inf_LevelUP;
    }
    public void UP_Mines()
    {
        S_MainControls.MinesRight += S_MainControls.Mines_Inf_LevelUP;
    }
    public void UP_SpeedOfMove()
    {
        S_MainControls.Speed_Right += S_MainControls.Speed_Inf_LevelUP;
    }
    public void UP_SpeedOfAttack()
    {
        S_MainControls.SpeedAtack_Right -= S_MainControls.SpeedAtack_Inf_LevelUP;
    }
}
