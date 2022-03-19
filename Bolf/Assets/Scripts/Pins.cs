using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pins : MonoBehaviour
{
    int FallenPins = 0;
    int FallenPinsInTurn = 0;
    GameMaster GM;

    public void CheckFallenPins()
    {
        StartCoroutine(CheckFallenPinsRoutine());
    }

    IEnumerator CheckFallenPinsRoutine()
    {
        yield return new WaitForSeconds(5f);
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).transform.localEulerAngles.z > 10)
            {
                //Debug.Log("Pin " + i + " has fallen");
                Destroy(transform.GetChild(i).gameObject);
                FallenPins++;
                FallenPinsInTurn++;
            }
            else
            {
                //Debug.Log("Pin " + i + " did not fall");
            }
        }

        if(FallenPinsInTurn == 0 && GM.Chances > 0)
        {
            GM.AlertText.text = "Gutter!";
            GM.ScoreText.text = "Shot down pins:" + FallenPins;
            GM.canShoot = true;
            GM.SpawnAnotherBall();
        }
        else if(FallenPinsInTurn == 10)
        {
            GM.GameOver();
            GM.AlertText.text = "Strike!";
            GM.ScoreText.text = "Shot down pins:" + FallenPins;
        }
        else 
        {
            GM.AlertText.text = "";
            GM.ScoreText.text = "Shot down pins:" + FallenPins;
            GM.canShoot = true;
            GM.SpawnAnotherBall();
        }

        FallenPinsInTurn = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
