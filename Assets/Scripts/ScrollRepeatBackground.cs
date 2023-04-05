using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollRepeatBackground : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    private Vector3 startPos;
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.z / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //only move background if game is running
        if (GameManager.Instance.IsGameRunning())
        {
            ScrollBackground();
            CheckAndRepeatBackground();
        }

    }

    void CheckAndRepeatBackground()
    {
        if (transform.position.z < startPos.z - repeatWidth)
        {
            transform.position = startPos;
            //Debug.Log("Current x: " + transform.position.x + " start x: " + startPos.x + " + repeat width: " + repeatWidth + " Repeating Background");
        }
    }

    void ScrollBackground()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
