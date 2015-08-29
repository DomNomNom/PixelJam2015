using UnityEngine;
using System.Collections;

public class QuestGiver : Character {

    public Quest[] quests;

    protected override void respond_hello(Character other) {
        if (other is Player) {
            // Player player = other as Player;

            foreach (Quest q in quests) {
                Player.acceptQuest(q);
            }
            gameObject.SetActive(false);

        }
    }
}
