using GeneralMetods;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_LevelUP : MonoBehaviour
{
    GeneralClass generalClass = new GeneralClass();
    private bool Up;

    public void DownPage()
    {
        generalClass.PlayAnimations(gameObject, "PageUp_anim", 1);
    }
    public void UpPage()
    {
        generalClass.PlayAnimations(gameObject, "PageUp_anim", 2);
    }

    public void OffAnim()
    {
        generalClass.PlayAnimations(gameObject, "PageUp_anim", 0);
    }

    public void Btn()
    {
        if (Up)
        {
            Up = false;
            UpPage();
        }
        else
        {
            Up = true;
            DownPage();
        }
    }

}
