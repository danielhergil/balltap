using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    private Rigidbody ballRb;
    public float forzeX;
    public float forzeY;
    public int points;
    public bool isFirstTouch = false;
    public bool aroTouched = false;
    public int notAroTouchedCounter = 0;
    public int passes = 0;
    private float ballRbZAxis;

    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        ballRbZAxis = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !ballRb.useGravity)
        {
            ballRb.useGravity = true;
            isFirstTouch = true;
            ballRb.velocity = new Vector3(forzeX, forzeY, ballRb.velocity.z);
        }
        if (Input.GetMouseButtonDown(0) && ballRb.useGravity)
        {
            forzeX *= -1;
            ballRb.velocity = new Vector3(forzeX, forzeY, ballRb.velocity.z);
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, ballRbZAxis);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "dontTouch")
        {
            Debug.Log("Has muerto JAJA");
        }
        if(collision.gameObject.tag == "aro")
        {
            aroTouched = true;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, ballRbZAxis);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "basket")
        {
            passes++;
            if(aroTouched)
            {
                points += 1;
                aroTouched = false;
                notAroTouchedCounter = 0;
            } else
            {
                if (notAroTouchedCounter >= 5)
                {
                    points += 300;
                }
                points += 5;
                notAroTouchedCounter++;   
            }
        }
    }
}
