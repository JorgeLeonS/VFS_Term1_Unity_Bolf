using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;

public class GameMaster : MonoBehaviour
{
    public BowlingBall Ball;
    public PointingArrow Arrow;
    public Pins Pins;

    public GameObject LaunchButton;

    BowlingBall newBall;

    public Text ScoreText;
    public Text BallsText;
    public Text AlertText;

    public Button ReplayButton;
    public Button NextLevelButton;
    public Button MainMenuButton;

    [SerializeField]
    GameObject DirectXRRig;

    [SerializeField]
    GameObject RayXRRig;

    bool ActiveXRRig = true;

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
            Debug.Log("No ball was found to destoy");
        }

        if(chances > 0)
        {
            newBall = Instantiate(Ball, new Vector3(0, -1, 2.75f), Quaternion.identity);
        }
        else
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        AlertText.text = "Game Over";
        ReplayButton.gameObject.SetActive(true);
        MainMenuButton.gameObject.SetActive(true);
        try
        {
            NextLevelButton.gameObject.SetActive(true);
        }
        catch (System.Exception)
        {
            Debug.Log("There is not a next level");
        }
        
        ChangeRigs();
    }

    void InitalizeOculusInput()
    {
        xrControls = new XRControls();
        xrControls.Enable();
        xrControls.Default.Newaction.performed += Newaction_performed;
    }

    public void CheckLaunchWithVRButton()
    {
        if (LaunchButton.transform.localPosition.y < 0.027)
        {
            TryShoot();
        }
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
        //throw new System.NotImplementedException();
    }

    void ChangeRigs()
    {
        if (ActiveXRRig)
        {
            DirectXRRig.SetActive(false);
            RayXRRig.SetActive(true);
            ActiveXRRig = false;
        }
        else
        {
            DirectXRRig.SetActive(true);
            RayXRRig.SetActive(false);
            ActiveXRRig = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryShoot();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            ChangeRigs();
        }

        CheckLaunchWithVRButton();
    }
}
