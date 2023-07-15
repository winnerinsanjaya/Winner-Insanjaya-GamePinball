using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnController : MonoBehaviour
{
    public static CoinSpawnController instance;

    public GameObject coinPrefabs;

    public List<spawnPos> spawnPos;

    public ObjectPool objectPool;

    public float spawnTimer;

    private float orSpawnTimer;

    public Collider bola;
    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        orSpawnTimer = spawnTimer;
    }

    private void Update()
    {
        if(spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;

            if(spawnTimer > 0)
            {
                return;
            }

            if(objectPool.active.Count < 3)
            {
                SpawnCoin();
            }
            
            spawnTimer = orSpawnTimer;
        }
    }
    private void SpawnCoin()
    {
        int rand = Random.Range(0, spawnPos.Count);


        var randPos = spawnPos[rand];

        if (!randPos.isTaken)
        {
            if (objectPool.dead.Count != 0)
            {

                GameObject go = objectPool.dead[0];
                objectPool.dead.RemoveAt(0);

                go.transform.parent = randPos.pos;

                CoinController coinController = go.GetComponent<CoinController>();
                coinController.SetStart();

                go.transform.position = randPos.pos.position;
                go.SetActive(true);
                spawnPos[rand].isTaken = true;
                AddToPoolAct(go);
                return;

            }
            else
            {
                GameObject go = Instantiate(coinPrefabs, randPos.pos.position, Quaternion.identity, randPos.pos);
                CoinController coinController = go.GetComponent<CoinController>();
                coinController.bola = bola;
                spawnPos[rand].isTaken = true;
                AddToPoolAct(go);
                return;
            }
        }

        else
        {
            SpawnCoin();
        }

    }
    public void AddToPoolAct(GameObject go)
    {
        objectPool.active.Add(go);
    }

    public void AddToPoolDead(GameObject go)
    {
        int ActIdx = objectPool.active.IndexOf(go);
        objectPool.active.RemoveAt(ActIdx);

        string name = go.transform.parent.name;
        int index = int.Parse(name);
        spawnPos[index].isTaken = false;
        go.SetActive(false);
        objectPool.dead.Add(go);
    }
}
