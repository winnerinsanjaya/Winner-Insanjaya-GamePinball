using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    public KeyCode input;
    private HingeJoint hinge;

    private float targetPressed;
    private float targetRelease;
    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();

        targetPressed = hinge.limits.max;
        targetRelease = hinge.limits.min;
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        JointSpring jointSpring = hinge.spring;

        // mengubah value spring saat input ditekan dan dilepas
        if (Input.GetKey(input))
        {
            jointSpring.targetPosition = targetPressed; ;
        }
        else
        {
            jointSpring.targetPosition = targetRelease;
        }

        // mengubah spring pada Hinge Joint dengan value yang sudah di ubah
        hinge.spring = jointSpring;
    }
}
