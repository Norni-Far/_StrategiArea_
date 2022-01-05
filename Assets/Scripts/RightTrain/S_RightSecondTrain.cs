using GeneralMetods;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class S_RightSecondTrain : MonoBehaviour
{
    //
    private S_MainControls S_MainControls;
    private GeneralClass generalClass = new GeneralClass();
    //

    // Inf_HP
    public GameObject Inf_Health_forScale;
    //

    // Части поезда
    public GameObject MainCorpus;
    public GameObject Window;
    //public GameObject Armor;
    //

    // private 
    private float Inf_HP_StartScale;
    private bool Atack = false;
    private int StartStrong;
    //

    // Характеристии 
    //public float StartMassa = 1f;
    //public float StartSpeed = 1f;
    public int NowStrong;
    //public float StartSpeedAtack = 2f;

    //
    Rigidbody2D rb;

    void Start()
    {
        S_MainControls = GameObject.FindGameObjectWithTag("S_MainControls").GetComponent<S_MainControls>();

        // Установка Стартовых характеристик
        Inf_HP_StartScale = Inf_Health_forScale.transform.localScale.x;
        StartStrong = S_MainControls.Strong_Right;
        NowStrong = StartStrong;
        //

        rb = GetComponent<Rigidbody2D>();

        //Fire_Anim.speed = 25f;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(-S_MainControls.Speed_Right, rb.velocity.y);
        rb.mass = S_MainControls.Massa_Right / 2;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == S_MainControls.Tag_FirstTarin_Player)
        {
            NowStrong -= collision.gameObject.GetComponent<S_T_FirstTrain>().NowStrong * 80 / 100;

            if (NowStrong <= 0)
            {
                DeadTrain();
            }
            else
            {
                Atack = true;
                StartCoroutine(StartAtack());
            }

            CheckHP();
        }

        if (collision.gameObject.tag == S_MainControls.Tag_SecondTarin_Player)
        {
            Atack = true;
            StartCoroutine(StartAtack());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == S_MainControls.Tag_FirstTarin_Player ||
            collision.gameObject.tag == S_MainControls.Tag_SecondTarin_Player)
        {
            Atack = false;
        }
    }

    // Trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Damage")
        {
            NowStrong -= S_MainControls.StrongOfAttack;

            if (NowStrong < 0)
                DeadTrain();

            CheckHP();
        }
    }

    //

    // Health
    private void CheckHP()
    {
        float Y = (NowStrong * 100) / StartStrong;
        float X = (Inf_HP_StartScale * Y) / 100;


        Inf_Health_forScale.transform.localScale = new Vector2(X, Inf_Health_forScale.transform.localScale.y);
    }
    private IEnumerator StartAtack()
    {
        yield return new WaitForSeconds(S_MainControls.SpeedAtack_Right);
        AtackOn(Atack);
    }

    // atack
    void AtackOn(bool atack)
    {
        generalClass.PlayAnimations(gameObject, "fire_anim", atack);
    }

    public void AnimContinueAtack() // приходит от анимации Event
    {
        generalClass.PlayAnimations(gameObject, "fire_anim", false);
        StartCoroutine(StartAtack());
    }


    // dead 
    void DeadTrain()
    {
        Destroy(gameObject);
    }
}
