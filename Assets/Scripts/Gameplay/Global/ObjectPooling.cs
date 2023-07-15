using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class ObjectPool
{
    public List<GameObject> active;
    public List<GameObject> dead;
}
