using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float zBound = -30.0f;
    private float yBound = -0.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HitFloor();
        OffScreen();
    }

    void HitFloor()
    {
        if (transform.position.y < yBound)
        {
            Destroy(gameObject);
            // play a particle effect to add later
        }
    }

    void OffScreen()
    {
        if (transform.position.z < zBound)
        {
            Destroy(gameObject);
        }
    }
}
