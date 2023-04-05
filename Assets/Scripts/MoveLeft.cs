using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    [SerializeField] private float speed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsGameRunning())
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }
}
