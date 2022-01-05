using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class S_MainCreators : MonoBehaviour
{
    //
    public S_MainControls S_MainControls;
    //

    public GameObject MainCamera;

    // Create
    public GameObject PrefabFirstTrain;
    public GameObject PrefabSecondTarin;
    public Transform[] PositionGarageCreate_Left = new Transform[5];

    private string NameofCreate = "";
    private bool StopCreate = false;
    public bool TuchGarage = false;

    private bool SwordTrain = false;

    public GameObject Btn_Shield;
    public GameObject Btn_Sword;
    //

    // Control

    private void Update()  // использование сцены как канваса 
    {

        for (int i = 0; i < Input.touchCount; ++i)
        {
            Vector2 test = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);

            if (Input.GetTouch(i).phase == TouchPhase.Stationary)
            {
                RaycastHit2D hit = Physics2D.Raycast(test, (Input.GetTouch(i).position));

                // что делать при соприкосновении с определённым колайдером 
                if (!StopCreate && hit.collider && (hit.collider.gameObject.name == "Garage_0"
                    || hit.collider.gameObject.name == "Garage_1"
                    || hit.collider.gameObject.name == "Garage_2"
                    || hit.collider.gameObject.name == "Garage_3"
                    || hit.collider.gameObject.name == "Garage_4"))
                {
                    NameofCreate = hit.collider.gameObject.name;
                    Create();
                }
            }
        }

        // информция о включенной кнопке 
        if (!SwordTrain)
        {
            Btn_Shield.GetComponent<Image>().color = new Color(0, 1, 0, 0.2f);
            Btn_Sword.GetComponent<Image>().color = new Color(1, 1, 1, 0.2f);
        }
        else
        {
            Btn_Sword.GetComponent<Image>().color = new Color(0, 1, 0, 0.2f);
            Btn_Shield.GetComponent<Image>().color = new Color(1, 1, 1, 0.2f);
        }

    }

    void Create()
    {
        if (SwordTrain)
        {
            if (S_MainControls.Resurses_left >= S_MainControls.Cost_SecondTrain)
            {
                StopCreate = true;
                S_MainControls.Resurses_left -= S_MainControls.Cost_SecondTrain;
                StartCoroutine(CreateTarinLeft());
            }
        }
        else if (!SwordTrain)
        {
            if (S_MainControls.Resurses_left >= S_MainControls.Cost_FirstTrain)
            {
                StopCreate = true;
                S_MainControls.Resurses_left -= S_MainControls.Cost_FirstTrain;
                StartCoroutine(CreateTarinLeft());
            }
        }
        else
        {
            SwordTrain = false;
        }

    }

    IEnumerator CreateTarinLeft()
    {
        int a = 0;

        switch (NameofCreate)
        {
            case "Garage_0":
                a = 0;
                break;

            case "Garage_1":
                a = 1;
                break;

            case "Garage_2":
                a = 2;
                break;

            case "Garage_3":
                a = 3;
                break;

            case "Garage_4":
                a = 4;
                break;
        }

        if (SwordTrain)
            Instantiate(PrefabSecondTarin, PositionGarageCreate_Left[a].position, PositionGarageCreate_Left[a].rotation);
        else
            Instantiate(PrefabFirstTrain, PositionGarageCreate_Left[a].position, PositionGarageCreate_Left[a].rotation);

        yield return new WaitForSeconds(S_MainControls.CreateSpeed_Left);

        StopCreate = false;

    }

    // button
    public void Sword_Train()
    {
        SwordTrain = true;
    }
    public void Shield_Train()
    {
        SwordTrain = false;
    }
}
