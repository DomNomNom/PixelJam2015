using UnityEngine;
using System.Collections;

public class Quest : MonoBehaviour {

    void Start() {
        // b.SetActive(false);
    }

    // whether we can complete this quest by touching the quest marker
    public virtual bool canTurnIn() {
        return true;
    }
}
