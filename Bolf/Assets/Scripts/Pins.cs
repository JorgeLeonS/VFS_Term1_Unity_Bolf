using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pins : MonoBehaviour
{
    int FallenPins = 0;
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
            if (transform.GetChild(i).transform.localEulerAngles.z > 5)
            {
                //Debug.Log("Pin " + i + " has fallen");
                Destroy(transform.GetChild(i).gameObject);
                FallenPins++;
            }
            else
            {
                //Debug.Log("Pin " + i + " did not fall");
            }
        }
        GM.ScoreText.text = "Shot down pins:" + FallenPins;
        GM.canShoot = true;
        GM.SpawnAnotherBall();
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
