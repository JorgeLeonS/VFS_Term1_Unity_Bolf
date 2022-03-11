using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    public float speed = 10;
    public PointingArrow arrow;

    GameMaster GM;
    Rigidbody RB;

    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameMaster>();
        arrow = GM.Arrow;
        RB = GetComponent<Rigidbody>();
    }   

    public void ShootBall()
    {
        Vector3 direction = -arrow.gameObject.transform.right;
        //Vector3 direction = gameObject.transform.forward;
        Vector3 velocity = speed * direction;
        RB.velocity = velocity;

        GM.Chances--;

        GM.Pins.CheckFallenPins();
    }


    private void OnTriggerEnter(Collider other)
    {
        //if(other.tag == "Pin")
        //{
        //    Debug.Log("The object " + other.name + " and Z: " + other.transform.localEulerAngles.z);
        //}
    }

    // Update is called once per frame
    void Update()
    {
    }
}
