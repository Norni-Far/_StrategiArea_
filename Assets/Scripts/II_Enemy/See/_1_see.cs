using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class _1_see : MonoBehaviour
{
    //
    public S_MainControls S_MainControls;
    //


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == S_MainControls.Tag_FirstTarin_Player ||
            collision.gameObject.tag == S_MainControls.Tag_SecondTarin_Player ||
            collision.gameObject.tag == S_MainControls.Tag_FirstTarin_Enemy ||
            collision.gameObject.tag == S_MainControls.Tag_SecondTarin_Enemy)
            S_MainControls.TrainOn_1_line.Add(collision.gameObject);

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == S_MainControls.Tag_FirstTarin_Player ||
           collision.gameObject.tag == S_MainControls.Tag_SecondTarin_Player ||
           collision.gameObject.tag == S_MainControls.Tag_FirstTarin_Enemy ||
           collision.gameObject.tag == S_MainControls.Tag_SecondTarin_Enemy)
            S_MainControls.TrainOn_1_line.Remove(collision.gameObject);
    }

}
