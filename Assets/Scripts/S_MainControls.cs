using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class S_MainControls : MonoBehaviour
{

    // TEST
    public Text LeftPlus;
    public Text RightPlus;
    //

    // Границы 
    public Transform LeftBorden;
    public Transform RightBroden;

    // Inf
    public Text Inf_Cost;
    public Text Inf_Resurses_lvlUP;

    public Text Inf_Lvl_Strong;
    public Text Inf_Lvl_Massa;
    public Text Inf_Lvl_SpeedOfMove;
    public Text Inf_Lvl_Mines;
    public Text Inf_Lvl_SpeedOfAttack;

    private int Lvl_Strong = 1;
    private int Lvl_Massa = 1;
    private int Lvl_SpeedOfMove = 1;
    private int Lvl_Mines = 1;
    private int Lvl_SpeedOfAttack = 1;

    public int Lvl_Up_All_Left;
    public int Lvl_Up_All_Right;
    private int Lvl_Cost_Left = 104;
    public int Lvl_Cost_Right = 104;
    //

    // Tegs Player
    public static string Tag_FirstTarin_Player = "Tag_FirstTrain_Player";
    public static string Tag_SecondTarin_Player = "Tag_SecondTrain_Player";
    //

    // Tegs Enemy
    public static string Tag_FirstTarin_Enemy = "Tag_FirstTrain_Enemy";
    public static string Tag_SecondTarin_Enemy = "Tag_SecondTrain_Enemy";
    //

    // Флаги
    public Transform[] Flagi = new Transform[5];
    public GameObject[] Flagi_Left = new GameObject[5];
    public GameObject[] Flagi_Right = new GameObject[5];
    //

    // Характеристика для Left
    public float Speed_Left;
    public float Massa_Left;
    public int Strong_Left;
    public float SpeedAtack_Left;
    public float CreateSpeed_Left;
    public float MinesLeft;
    //

    //Характеристика для Right
    public float Speed_Right;
    public float Massa_Right;
    public int Strong_Right;
    public float SpeedAtack_Right;
    public float CreateSpeed_Right;
    public float MinesRight;
    //

    // Общие характеристики 
    public int StrongOfAttack; // Cила атаки, боевых поездов

    // Ресурсы
    public Text Inf_ResursesLeft;
    public Text Inf_ResursesRight;

    public double Resurses_left;
    public double Resurses_right;
    //

    // priceList
    public int Cost_FirstTrain;
    public int Cost_SecondTrain;
    //

    // Степени прокачки
    public float Speed_Inf_LevelUP;
    public float Massa_Inf_LevelUP;
    public int Strong_Inf_LevelUP;
    public float SpeedAtack_Inf_LevelUP;
    public float Mines_Inf_LevelUP;
    //

    // see for ИИ
    public List<GameObject> TrainOn_1_line = new List<GameObject>();
    public List<GameObject> TrainOn_2_line = new List<GameObject>();
    public List<GameObject> TrainOn_3_line = new List<GameObject>();
    public List<GameObject> TrainOn_4_line = new List<GameObject>();
    public List<GameObject> TrainOn_5_line = new List<GameObject>();
    //

    void Start()
    {
        StartFlags();
        CheckINF_left();
        CheckINF_Right();
        StartCoroutine(Resurses());
    }

    void FixedUpdate()
    {
        Inf_ResursesLeft.text = Math.Round(Resurses_left, 1).ToString();
        Inf_ResursesRight.text = Math.Round(Resurses_right, 1).ToString();

        Inf_Resurses_lvlUP.text = Inf_ResursesLeft.text;
    }

    IEnumerator Resurses()
    {
        double l = 0;
        double r = 0;
        for (int i = 0; i < Flagi.Length; i++)
        {
            //Resurses_left += Math.Round(Flagi[i].position.x, 1);
            //Resurses_left += Math.Round(Vector2.Distance(LeftBorden.position, Flagi[i].position), 1);
            Resurses_left += (9 + Flagi[i].position.x) / 10 + MinesLeft;
            l += (9 + Flagi[i].position.x) / 10 + MinesLeft;

            //Resurses_right += Math.Round(Vector2.Distance(RightBroden.position, Flagi[i].position), 1);
            Resurses_right += (9 - Flagi[i].position.x) / 10 + MinesLeft;
            r += (9 - Flagi[i].position.x) / 10 + MinesRight;
        }

        LeftPlus.text = "+ " + Math.Round(l, 1);
        RightPlus.text = "+ " + Math.Round(r, 1);

        yield return new WaitForSeconds(1f);

        StartCoroutine(Resurses());
    }

    // раставление флагов 
    void StartFlags()
    {
        float a = UnityEngine.Random.Range(0f, 6f);
        float b = UnityEngine.Random.Range(0f, 6f);

        for (int i = Flagi.Length - 1; i >= 1; i--)
        {
            int j = UnityEngine.Random.Range(0, i + 1);

            var tmp = Flagi[j];
            Flagi[j] = Flagi[i];
            Flagi[i] = tmp;
        }

        Flagi[0].position = new Vector2(-a, Flagi[0].position.y);
        Flagi[1].position = new Vector2(a, Flagi[1].position.y);
        Flagi[2].position = new Vector2(b, Flagi[2].position.y);
        Flagi[3].position = new Vector2(-b, Flagi[3].position.y);
        Flagi[4].position = new Vector2(0, Flagi[4].position.y);
    }


    public void BTN_UP_Strong()
    {
        if (Resurses_left >= Lvl_Cost_Left)
        {
            PaayOFUpDate();
            Strong_Left += Strong_Inf_LevelUP;
            Lvl_Strong++;
            CheckINF_left();
        }
    }
    public void BTN_UP_Massa()
    {
        if (Resurses_left >= Lvl_Cost_Left)
        {
            PaayOFUpDate();
            Massa_Left += Massa_Inf_LevelUP;
            Lvl_Massa++;
            CheckINF_left();
        }
    }
    public void BTN_UP_Mines()
    {
        if (Resurses_left >= Lvl_Cost_Left)
        {
            PaayOFUpDate();
            MinesLeft += Mines_Inf_LevelUP;
            Lvl_Mines++;
            CheckINF_left();
        }
    }
    public void BTN_UP_SpeedOfMove()
    {
        if (Resurses_left >= Lvl_Cost_Left)
        {
            PaayOFUpDate();
            Speed_Left += Speed_Inf_LevelUP;
            Lvl_SpeedOfMove++;
            CheckINF_left();
        }
    }
    public void BTN_UP_SpeedOfAttack()
    {
        if (Resurses_left >= Lvl_Cost_Left)
        {
            PaayOFUpDate();
            SpeedAtack_Left -= SpeedAtack_Inf_LevelUP;
            Lvl_SpeedOfAttack++;
            CheckINF_left();
        }
    }

    private void PaayOFUpDate()
    {
        Resurses_left -= Lvl_Cost_Left;
        Lvl_Up_All_Left++;
    }

    private void CheckINF_left()
    {
        Lvl_Cost_Left = Convert.ToInt32(Lvl_Cost_Left + Lvl_Up_All_Left + 1.1f * Lvl_Up_All_Left);
        Inf_Cost.text = Lvl_Cost_Left.ToString();

        Inf_Lvl_Strong.text = "lvl: " + Lvl_Strong;
        Inf_Lvl_Massa.text = "lvl: " + Lvl_Massa;
        Inf_Lvl_SpeedOfMove.text = "lvl: " + Lvl_SpeedOfMove;
        Inf_Lvl_Mines.text = "lvl: " + Lvl_Mines;
        Inf_Lvl_SpeedOfAttack.text = "lvl: " + Lvl_SpeedOfAttack;
    }

    public void CheckINF_Right()
    {
        Lvl_Cost_Right = Convert.ToInt32(Lvl_Cost_Left + Lvl_Up_All_Right + 1.1f * Lvl_Up_All_Right);
    }

}


