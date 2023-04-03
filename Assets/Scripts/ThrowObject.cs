using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    [SerializeField] float horizontalForce = 10.0f;
    [SerializeField] float verticalForce = 10.0f;
    Rigidbody myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();

        float forceMultiplier = Random.Range(1.0f, 1.5f);

        myRigidbody.AddForce(Vector3.back * (horizontalForce * forceMultiplier), ForceMode.Impulse);
        myRigidbody.AddForce(Vector3.up * (verticalForce * forceMultiplier), ForceMode.Impulse);

        myRigidbody.AddTorque(Vector3.back * forceMultiplier, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }

}
