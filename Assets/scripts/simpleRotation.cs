using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleRotation : MonoBehaviour
{
    public float speed = 40;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);

    }
}
