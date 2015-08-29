using UnityEngine;
using System.Collections;

// A quest is the quest reciever itself
public class Quest : Character {

    public int promisedReward;
    public bool isPersistentQuest = true;  // whether the quest persists when turned in
    public bool isFirstQuest = false;

    public Quest[] followUpQuests;

    public SpriteRenderer sprite;
    private Color originalColor;
    private Color disabledColor = Utils.colorFromHex("8C8C8CFF");

    private bool willRemoveSelf = false;

    protected override void Start() {
        base.Start();
        Debug.Assert(null != sprite);
        originalColor = sprite.color;

        exit(posX, posY);
        gameObject.SetActive(false);
        if (isFirstQuest) {
            Player.acceptQuest(this);
        }
    }

    protected override void Update() {
        base.Update();
        sprite.color = (canTurnIn())? originalColor : disabledColor;

        if (willRemoveSelf) {
            exit(posX, posY);
            gameObject.SetActive(false);
            willRemoveSelf = false;
        }
    }


    public virtual void begin() {
        gameObject.SetActive(true);
        enter(posX, posY);
    }

    protected override void hello(Character other) {
        respond_hello(other);
    }

    protected override void respond_hello(Character other) {
        if (!canTurnIn()) return;
        if (!(other is Player)) return;
        // Player player = other as Player;
        if (!Player.quests.Contains(this)) {
            Debug.LogWarning("player doesn't contain me! D:");
            return;
        }

        Player.food += promisedReward;

        foreach (Quest q in followUpQuests) {
            Debug.Log("ACCEPT!");
            Player.acceptQuest(q);
        }

        if (!isPersistentQuest) {
            Player.quests.Remove(this);
            willRemoveSelf = true;
        }
    }

    // whether we can complete this quest by touching the quest marker
    public virtual bool canTurnIn() {
        // return (int)(Time.time) % 2 == 0;
        return true;
    }
}
