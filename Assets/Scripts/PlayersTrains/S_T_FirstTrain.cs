using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class S_T_FirstTrain : MonoBehaviour
{
    //
    private S_MainControls S_MainControls;
    //

    // Inf_HP
    public GameObject Inf_Health_forScale;
    //

    // Части поезда
    public GameObject MainCorpus;
    public GameObject Roof;
    public GameObject Window;
    public GameObject Brony;
    //

    // Характеристии 
    //public float StartMassa = 1f;
    //public float StartSpeed = 1f;
    public int NowStrong;
    //public float StartSpeedAtack = 2f;
    //

    // private
    private float Inf_HP_StartScale;
    private bool tuchEnemy;
    private int StartStrong;
    //


    //
    Rigidbody2D rb;
    //

    void Start()
    {
        S_MainControls = GameObject.FindGameObjectWithTag("S_MainControls").GetComponent<S_MainControls>();

        // Установка Стартовых характеристик
        Inf_HP_StartScale = Inf_Health_forScale.transform.localScale.x;
        StartStrong = S_MainControls.Strong_Left;
        NowStrong = StartStrong;
        //

        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(S_MainControls.Speed_Left, rb.velocity.y);
        rb.mass = S_MainControls.Massa_Left;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Damage")
        {
            NowStrong -= S_MainControls.StrongOfAttack;

            if (NowStrong < 0)
                TrainisDaed();

            CheckHP();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == S_MainControls.Tag_FirstTarin_Enemy)
        {
            tuchEnemy = true;
            StartCoroutine(Protivistiyanie());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == S_MainControls.Tag_FirstTarin_Enemy)
        {
            tuchEnemy = false;
        }
    }

    // отнимание прочности при долгом противостоянии с врагом 
    IEnumerator Protivistiyanie()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(1.1f, 2f));

        if (tuchEnemy)
        {
            NowStrong--;
            StartCoroutine(Protivistiyanie());
        }

        if (NowStrong <= 0)
            TrainisDaed();

        CheckHP();
    }

    private void CheckHP()
    {
        float Y = (NowStrong * 100) / StartStrong;
        float X = (Inf_HP_StartScale * Y) / 100;


        Inf_Health_forScale.transform.localScale = new Vector2(X, Inf_Health_forScale.transform.localScale.y);
    }

    // Поезд погиб 
    private void TrainisDaed()
    {
        Destroy(gameObject);
    }

}
