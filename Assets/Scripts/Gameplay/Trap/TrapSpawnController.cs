using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawnController : MonoBehaviour
{
    public static TrapSpawnController instance;

    public GameObject trapPrefabs;

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
        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;

            if (spawnTimer > 0)
            {
                return;
            }

            if (objectPool.active.Count < 3)
            {
                SpawnTrap();
            }

            spawnTimer = orSpawnTimer;
        }
    }
    private void SpawnTrap()
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

                TrapController trapController = go.GetComponent<TrapController>();
                trapController.SetStart();

                go.transform.position = randPos.pos.position;
                go.SetActive(true);
                spawnPos[rand].isTaken = true;
                AddToPoolAct(go);
                return;

            }
            else
            {
                GameObject go = Instantiate(trapPrefabs, randPos.pos.position, Quaternion.identity, randPos.pos);
                TrapController trapController = go.GetComponent<TrapController>();
                trapController.bola = bola;
                spawnPos[rand].isTaken = true;
                AddToPoolAct(go);
                return;
            }
        }

        else
        {
            SpawnTrap();
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
