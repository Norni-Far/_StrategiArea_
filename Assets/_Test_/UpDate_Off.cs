using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDate_Off : MonoBehaviour
{
    public void offAnimator()
    {
        gameObject.GetComponent<Animator>().enabled = false;
    }
}
