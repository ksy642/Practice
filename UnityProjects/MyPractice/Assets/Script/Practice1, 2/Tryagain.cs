using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tryagain : MonoBehaviour
{
    public GameObject block;
    List<GameObject> BlockList = new List<GameObject>();

    void Start()
    {
        GameObject _obj = Instantiate(block) as GameObject;
        BlockList.Add(_obj);
    }
}
