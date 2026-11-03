using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public GameObject posisikamera;
    public GameObject fokuskamera;
    public float kecepatankamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position =
        Vector3.Slerp(this.gameObject.transform.position,
        posisikamera.transform.position, Time.deltaTime * kecepatankamera);

        this.gameObject.transform.LookAt(fokuskamera.transform);
    }
}
