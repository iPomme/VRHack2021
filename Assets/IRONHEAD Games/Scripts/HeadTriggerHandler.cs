using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTriggerHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.LogFormat("OnTriggerEnter with {0}", other.gameObject.name);
    }
}
