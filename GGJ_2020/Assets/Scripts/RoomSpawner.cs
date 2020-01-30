using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehavior {

    // 1 opens bottom, 2 opens top, 3 opens left, 4 opens right
    public int openingDirection;
    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;

    void Start() {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    void Spawn() {
        if (!spawned) {
            switch(openingDirection) {
                case 1 : //spawn botton door
                    rand = Random.Range(0, templates.bottomRooms.Length);
                    Instantiate(templates.bottomRooms[rand], transform.position, Quaternion.identity);
                    break;
                case 2 : //spawn top door
                rand = Random.Range(0, templates.topRooms.Length);
                    Instantiate(templates.topRooms[rand], transform.position, Quaternion.identity);
                    break;
                case 3 : //spawn left door
                rand = Random.Range(0, templates.leftRooms.Length);
                    Instantiate(templates.leftRooms[rand], transform.position, Quaternion.identity);
                    break;
                case 4 : //spawn right door
                rand = Random.Range(0, templates.rightRooms.Length);
                    Instantiate(templates.rightRooms[rand], transform.position, Quaternion.identity);
                    break;
            }
            spawned = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("SpawnPoint")) {
            if (!other.GetComponent<RoomSpawner>().spawned && !spawned) {
                //spawn walls blocking off openings
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(GameObject);
            }
            spawned = true;
        }
    }
}