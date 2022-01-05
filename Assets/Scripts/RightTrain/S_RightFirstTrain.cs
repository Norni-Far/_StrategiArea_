using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class S_RightFirstTrain : MonoBehaviour
{
    //
    private S_MainControls S_MainControl;
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


    // Характеристика 
    //public float StartMassa;
    //public float StartSpeed;
    public int NowStrong;
    //

    // private 
    private float Inf_HP_StartScale;
    private bool tuchEnemy = false;
    private int StartStrong;
    //

    Rigidbody2D rb;

    void Start()
    {
        S_MainControl = GameObject.FindGameObjectWithTag("S_MainControls").GetComponent<S_MainControls>();

        // Установка Стартовых характеристик
        Inf_HP_StartScale = Inf_Health_forScale.transform.localScale.x;
        StartStrong = S_MainControl.Strong_Right;
        NowStrong = StartStrong;
        //

        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(-S_MainControl.Speed_Right, rb.velocity.y);
        rb.mass = S_MainControl.Massa_Right;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Damage")
        {
            NowStrong -= S_MainControl.StrongOfAttack;

            if (NowStrong < 0)
                TrainisDaed();

            CheckHP();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == S_MainControls.Tag_FirstTarin_Player)
        {
            tuchEnemy = true;
            StartCoroutine(Protivistiyanie());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == S_MainControls.Tag_FirstTarin_Player)
        {
            tuchEnemy = false;
        }
    }

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

    // Health
    private void CheckHP()
    {
        float Y = (NowStrong * 100) / StartStrong;
        float X = (Inf_HP_StartScale * Y) / 100;

        Inf_Health_forScale.transform.localScale = new Vector2(X, Inf_Health_forScale.transform.localScale.y);
    }

    private void TrainisDaed()
    {
        Destroy(gameObject);
    }

}
