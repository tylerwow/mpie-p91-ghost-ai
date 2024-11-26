using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GhostTrigger : MonoBehaviour
{
    public bool hasTriggered;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Player") {
            hasTriggered = true;
        }
    }
}
