using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float time;
    public float startTime;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        time = 60.0f;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        scoreText.text = time.ToString("0");
        if (time < 0) {
            //end game
        }
    }
}
