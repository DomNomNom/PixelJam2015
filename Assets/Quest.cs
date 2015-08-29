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

    protected override void Start() {
        posX = (int)Mathf.Round(transform.position.x);
        posY = (int)Mathf.Round(transform.position.y);
        // note: we don't enter(posX, posY) yet as we'll disable ourselves

        Debug.Assert(null != sprite);
        originalColor = sprite.color;

        gameObject.SetActive(false);
        if (isFirstQuest) {
            Player.instance.acceptQuest(this);
        }
    }

    protected override void Update() {
        base.Update();
        sprite.color = (canTurnIn())? originalColor : disabledColor;
    }


    // the quest (this object) has been accepted by the player
    public virtual void begin() {
        gameObject.SetActive(true);
        enter(posX, posY);
    }

    protected override void hello(Character other) {
    }

    protected override void respond_hello(Character other) {
        if (!canTurnIn()) return;
        if (!(other is Player)) return;
        // Player player = other as Player;
        if (!Player.instance.quests.Contains(this)) {
            Debug.LogWarning("player doesn't contain me! D:");
            return;
        }

        Player.instance.fat += promisedReward;

        if (!isPersistentQuest) {
            Player.instance.quests.Remove(this);
            gameObject.SetActive(false);
            exit(posX, posY);
        }

        foreach (Quest q in followUpQuests) {
            Player.instance.acceptQuest(q);
        }
    }

    // whether we can complete this quest by touching the quest marker
    public virtual bool canTurnIn() {
        // return (int)(Time.time) % 2 == 0;
        return true;
    }
}
