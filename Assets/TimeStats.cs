using UnityEngine;
using System.Collections;

public class TimeStats : ShowIfPlayerDead {

    public static readonly float songEndTime = 53.5f;
    public static float timeRemaining = songEndTime;

    public TextMesh countdownText;

    bool playerDead = false;

	// Use this for initialization
	void Start () {
        Player.instance.addDeathListener(this);
	}

    public override void onPlayerDeath() {
        playerDead = true;
    }

	// Update is called once per frame
	void Update () {
        if (!playerDead) {
            timeRemaining = songEndTime - Time.timeSinceLevelLoad;
            timeRemaining = Mathf.Max(0, timeRemaining);
            countdownText.text = timeRemaining.ToString("F2")  + "s";
        }
	}
}
