using System;
using UnityEngine.UI;
using UnityEngine;

public class Fixit : MonoBehaviour
{
    public GameObject player;
    private float inputTime = 1.5f;
    private static char[] QTEvent = { 'y', 'u', 'i', 'o', 'p', 'h', 'j', 'k', 'l', 'n', 'm' };
    private char currentQT = 'A';
    private int numQTEvents = 3;
    private int rand;
    public Animator animator;
    public Text text;
    public GameObject coll;


    void Start() {
        animator.Play("Broke", 0);
    }

    void OnTriggerEnter2D()
    {
        player.GetComponent<Animator>().Play("Dancing", 0);
        if (numQTEvents == 3 && inputTime == 1.5f)
        {
            rand = UnityEngine.Random.Range(0, QTEvent.Length);
            currentQT = QTEvent[rand];
        }

        text.text = "" + currentQT;
        bool success = false;

        //had to resort to this method because KeyCode.variable does not work
        switch (rand)
        {
            case 0:
                success = Input.GetKeyDown(KeyCode.Y);
                break;
            case 1:
                success = Input.GetKeyDown(KeyCode.U);
                break;
            case 2:
                success = Input.GetKeyDown(KeyCode.I);
                break;
            case 3:
                success = Input.GetKeyDown(KeyCode.O);
                break;
            case 4:
                success = Input.GetKeyDown(KeyCode.P);
                break;
            case 5:
                success = Input.GetKeyDown(KeyCode.H);
                break;
            case 6:
                success = Input.GetKeyDown(KeyCode.J);
                break;
            case 7:
                success = Input.GetKeyDown(KeyCode.K);
                break;
            case 8:
                success = Input.GetKeyDown(KeyCode.L);
                break;
            case 9:
                success = Input.GetKeyDown(KeyCode.N);
                break;
            case 10:
                success = Input.GetKeyDown(KeyCode.M);
                break;
        }

        if (success)
        {
            rand = UnityEngine.Random.Range(0, QTEvent.Length);
            currentQT = QTEvent[rand];
            inputTime = 1.5f;
            isFixed();
        }

        inputTime -= Time.deltaTime;

        if (inputTime < 0)
        {
            numQTEvents = 3;
            inputTime = 1.5f;
        }
    }

    void isFixed()
    {
        numQTEvents--;
        if (numQTEvents == 1)
        {
            animator.Play("Repair", 0);
        }
        if (numQTEvents == 0)
        {
            text.GetComponent<TextMesh>().text = "";
            animator.Play("Dancing", 0);
            this.GetComponent<Fixit>().enabled = !this.GetComponent<Fixit>().enabled;
            text.enabled = !text.enabled;
        }
    }

}
