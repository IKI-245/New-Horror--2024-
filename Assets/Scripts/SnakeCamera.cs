using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeCamera : MonoBehaviour
{
    public float amount = 1;
    public float speed = 1;

    private Vector3 startPos;
    private float distation;
    private Vector3 rotation = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distation += (transform.position - startPos).magnitude;
        startPos = transform.position;
        rotation.z = Mathf.Sin(distation * speed) * amount;
        transform.localEulerAngles = rotation;
    }
}
