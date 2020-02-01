using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour //attach to room
{
    public GameObject room;
    public GameObject virtualCamera;
    public string Objective;
    public GameObject[] doors; //fill this with door prefabs
    public Canvas canvas;


    public void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && !other.isTrigger) {
            virtualCamera.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player") && !other.isTrigger) {
            virtualCamera.SetActive(false);
        }
    }

    void Start()
    {
        //Yeet Player??

        if (room.tag == "incomplete") {
            for (int i = 0; i < doors.Length; i++) {
                Spawn(doors[i], new Vector2(doors[i].transform.position.x, doors[i].transform.position.y));
            }


        }
        //Display Objective if room not complete
        //Undisplay objective


        //Spawn entities on delay if room not complete
    }

    // Update is called once per frame
    void Update()
    {
        //check if objective complete
        //if complete, update room tag
        //destroy doors
    }

    void Spawn(GameObject g, Vector2 v) {
        Instantiate(g, v, Quaternion.identity);
    }
}
