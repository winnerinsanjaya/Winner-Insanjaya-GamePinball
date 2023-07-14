using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float maxSpeed;

    private Rigidbody rig;

    private Vector3 pos;

    public Collider detector;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (rig.velocity.magnitude > maxSpeed)
        {
            // kalau melebihi buat vector velocity baru dengan besaran max speed
            rig.velocity = rig.velocity.normalized * maxSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == detector)
        {
            backToPos();
        }
    }

    private void backToPos()
    {
        transform.position = pos;
        GateController.instance.OpenGate();
    }
}
