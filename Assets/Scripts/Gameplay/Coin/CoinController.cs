using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{

    public float spawnTimer;

    private float orSpawnTimer;

    public Collider bola;
    // Start is called before the first frame update
    void Start()
    {
        orSpawnTimer = spawnTimer;
    }

    public void SetStart()
    {
        spawnTimer = orSpawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0)
        {
            CoinSpawnController.instance.AddToPoolDead(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if(bola != null)
        {
            if (other == bola)
            {
                CoinSpawnController.instance.AddToPoolDead(this.gameObject);
            }
        }
        
    }
}