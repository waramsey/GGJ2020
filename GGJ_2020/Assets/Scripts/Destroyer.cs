using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehavior {

    void OnTriggerEnter2D(Collider2D other) {
        Destroyer(other.gameObject);
    }
}