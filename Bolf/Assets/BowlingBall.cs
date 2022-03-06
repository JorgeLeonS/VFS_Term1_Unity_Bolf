using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ShootBall();
    }

    public void ShootBall()
    {
        float speed = 10;
        Vector3 direction = Vector3.forward;
        Vector3 velocity = speed * direction;
        GetComponent<Rigidbody>().velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
