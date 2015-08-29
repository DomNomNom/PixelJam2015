using UnityEngine;
using System.Collections;

public class ShowIfPlayerDead : MonoBehaviour {

    public bool showIfDead = false;
    public GameObject target;

    // Use this for initialization
    void Start () {
        if (target == null) {
            target = gameObject;
        }

        if (showIfDead) {
            target.SetActive(false);
        }

        Player.instance.addDeathListener(this);
    }

    public void onPlayerDeath() {
        target.SetActive(showIfDead);
    }
}
