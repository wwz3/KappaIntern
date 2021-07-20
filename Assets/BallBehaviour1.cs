using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour1 : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform checkgr;
    private bool Jump;
    private Rigidbody rb;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       /* Rigidbody myBall = this.GetComponent<Rigidbody>();

        if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey("d")) 
        {
            Vector3 forceVector = new Vector3 (100, 0, 0);
            myBall.AddForce (forceVector);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a")) 
        {
            //Debug.Log("Moving left");
            Vector3 forceVector = new Vector3 (-100, 0, 0);
            myBall.AddForce (forceVector);
        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey("w")) 
        {
            Vector3 forceVector = new Vector3 (0, 0, 100);
            myBall.AddForce (forceVector);
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s")) 
        {
            Vector3 forceVector = new Vector3 (0, 0, -100);
            myBall.AddForce (forceVector);
        }*/
        
        if (Input.GetKeyDown (KeyCode.Space))
        {
            Debug.Log("I'm jumping");
            //myBall.AddForce(Vector3.up * 8, ForceMode.VelocityChange);
            Jump = true;
            /*
            Vector3 position = this.transform.position;
            position.y += 2;
            this.transform.position = position;*/
        }
    }

    private void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moverVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0 ,moverVertical);
        rb.AddForce(movement * 100);

        if(Physics.OverlapSphere(checkgr.position, 0.1f).Length == 1)
        {
            return;
        }

        if(Jump)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 18, ForceMode.VelocityChange);
            Jump = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Destroy(other.gameObject);
        }

        /*else if (other.gameObject.layer == 7)
        {
            // Destroy(other.gameObject);
            Debug.Log("You Won !!!");
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            // Destroy(other.gameObject);
            Debug.Log("You Won !!!");
        }
    }


}


