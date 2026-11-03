using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatihanFind : MonoBehaviour
{
    public GameObject Temukan;
    public string NamaObject = "Player";

    void Start()
    {
        Temukan = GameObject.Find(NamaObject);
        Debug.Log(Temukan.name);
    }

    void Update()
    {

    }
}
