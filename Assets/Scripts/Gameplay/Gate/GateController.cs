using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{

    public GameObject gate;
    private bool isClosed;

    public Collider bola;

    public static GateController instance;
    // Start is called before the first frame update



    private void Awake()
    {
        instance = this;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other == bola)
        {
            Debug.Log("detected");
            CloseGate();
        }
    }


    public void OpenGate()
    {
            gate.SetActive(false);
    }

    public void CloseGate()
    {
        gate.SetActive(true);
    }
}
