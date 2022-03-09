using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class GameMaster : MonoBehaviour
{
    public BowlingBall ball;

    [SerializeField]
    private XRControls xrControls;

    // Start is called before the first frame update
    void Start()
    {
        xrControls = new XRControls();

        xrControls.Enable();

        xrControls.Default.Newaction.performed += Newaction_performed;

    }

    private void Newaction_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        ball.ShootBall();
        Debug.Log("Pressed something");
        //throw new System.NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ball.ShootBall();
        }
        //if (Input.GetButtonDown("Axis1D.PrimaryHandTrigger"))
        //{
        //    ball.ShootBall();
        //}
    }
}
