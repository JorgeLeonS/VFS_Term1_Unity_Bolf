using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class GameMaster : MonoBehaviour
{
    public BowlingBall Ball;
    public PointingArrow Arrow;
    public Pins Pins;

    BowlingBall newBall;

    public Text ScoreText;
    public Text BallsText;

    public bool canShoot = true;

    private int chances;
    public int Chances
    {
        get
        {
            return chances;
        }
        set
        {
            chances = value;
            ChangeChancesText();
        }
    }

    [SerializeField]
    private XRControls xrControls;

    // Start is called before the first frame update
    void Start()
    {
        Chances = 2;
        InitalizeOculusInput();
        SpawnAnotherBall();
        //GameObject[] pins = Pins.GetComponentInChildren<Pin>().gameObject;
    }

    void ChangeChancesText()
    {
        BallsText.text = "Remaining balls: " + chances;
    }

    public void SpawnAnotherBall()
    {
        try
        {
            Destroy(newBall.gameObject);
        }
        catch (System.Exception)
        {
            Debug.Log("No object was found to destoy");
        }

        if(chances > 0)
        {
            newBall = Instantiate(Ball, new Vector3(0, -1, 2.75f), Quaternion.identity);
        }
        else
        {
            Debug.Log("GameOver");
        }
    }

    void InitalizeOculusInput()
    {
        xrControls = new XRControls();
        xrControls.Enable();
        xrControls.Default.Newaction.performed += Newaction_performed;
    }

    public void TryShoot()
    {
        if(canShoot && chances > 0)
        {
            newBall.ShootBall();
            canShoot = false;
        }
        else
        {
            Debug.Log("Cannot shoot yet");
        }
    }

    private void Newaction_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        TryShoot();
        Debug.Log("Pressed something");
        //throw new System.NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryShoot();
        }
    }
}
