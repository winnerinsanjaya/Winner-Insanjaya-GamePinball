using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float maxSpeed;

    private Rigidbody rig;

    private Vector3 pos;

    public Collider detector;

    public static BallController instance;

    private void Awake()
    {
        instance = this;
    }
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

    public void backToPos()
    {
        transform.position = pos;
        rig.velocity = rig.velocity.normalized * 0;
        GateController.instance.OpenGate();
    }
}
