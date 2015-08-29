using UnityEngine;
using System.Collections;

public class EndSongOnDeath : ShowIfPlayerDead {


    // Use this for initialization
    void Start () {
        Player.instance.addDeathListener(this);
    }

    public override void onPlayerDeath() {
        GetComponent<AudioSource>().time = TimeStats.songEndTime;
    }

}
