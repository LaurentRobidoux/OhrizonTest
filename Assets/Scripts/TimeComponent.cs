using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeComponent : MonoBehaviour {

     float seconds = 5 * 60;
	// Use this for initialization
	void Start () {
		
	}

    public void ResetTimer()
    {
        seconds = 5 * 60;
    }
	
	// Update is called once per frame
	void Update () {
        seconds -= Time.deltaTime;
        TimeSpan t = TimeSpan.FromSeconds(seconds);

        string answer = string.Format("{1:D2}m:{2:D2}s:{3:D3}ms",
                        t.Hours,
                        t.Minutes,
                        t.Seconds,
                        t.Milliseconds);

        GetComponent<Text>().text = answer;
        if (seconds<0)
        {
         //   this.gameObject.active = false;
            //GameOver
        }
	}
}
