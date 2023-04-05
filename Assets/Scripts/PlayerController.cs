using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpForce = 250.0f;
    //[SerializeField] private float wallBounceForce = 1.0f;
    [SerializeField] private float gravityModifier = 1.1f;
    [SerializeField] private float zBound = 5.5f;

    public bool onGround;

    private ScoreKeeper scoreKeeper;
    private Rigidbody myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        scoreKeeper = GameObject.Find("Score Keeper").GetComponent<ScoreKeeper>();

        myRigidBody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        // allow movement if game is running
        if (GameManager.Instance.IsGameRunning())
        {
            // move based on Horizontal axis
            MovePlayer();

            // jump based on input of space bar if player is on ground
            if (onGround)
            {
                Jump();
            }
        }

        // keep object in bound
        KeepInBounds();

    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * (horizontalInput * speed) * Time.deltaTime);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onGround = false;
        }
    }

    void KeepInBounds()
    {
        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
            //myRigidBody.AddForce(Vector3.forward * wallBounceForce * -speed, ForceMode.Impulse);
            //myRigidBody.velocity.Set(myRigidBody.velocity.x, myRigidBody.velocity.y, 0);
        }
        else if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
            //myRigidBody.velocity.Set(myRigidBody.velocity.x, myRigidBody.velocity.y, 0);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            onGround = true;
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            scoreKeeper.LoseLife();
            //Debug.Log("Hit Obstacle: " + other.gameObject.name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            scoreKeeper.UpdateScore(other.GetComponent<PointsHolder>().GetPointValue());
            //Debug.Log("Hit Item: " + other.gameObject.name);
            Destroy(other.gameObject);
        }
    }

}
