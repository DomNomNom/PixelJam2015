using UnityEngine;
using System.Collections;

// A quest is the quest reciever itself
public class Quest : Character {

    public int promisedReward;

    protected override void Start() {
        gameObject.SetActive(false);
    }

    protected override void respond_hello(Character other) {
        if (other is Player) {
            Player player = other as Player;
            player.quests.Remove(this);
        }
    }

    // whether we can complete this quest by touching the quest marker
    public virtual bool canTurnIn() {
        return true;
    }
}
