using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    public float speed = 10;
    public PointingArrow arrow;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void ShootBall()
    {
        
        Vector3 direction = -arrow.gameObject.transform.right;
        Vector3 velocity = speed * direction;

        //Vector3 newDirection = new Vector3(0, 0, 70);

        GetComponent<Rigidbody>().velocity = velocity;
        //GetComponent<Rigidbody>().velocity = transform.TransformDirection( newDirection);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
