using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : Character {


    public List<Quest> quests = new List<Quest>();
    public void acceptQuest(Quest q) {
        quests.Add(q);
        q.gameObject.SetActive(true);
    }

    // // Use this for initialization
    // protected override void Start () {
    //     base.Start();
    // }

    // // Update is called once per frame
    // protected override void Update () {
    //     base.Update();
    // }


    protected override void hello(Character other) {
        Debug.Log("hello other: " + other);
    }

    public override void onInput(int dx, int dy) {
        if (enter(posX + dx, posY + dy)) {
            exit(posX, posY);
            posX += dx;
            posY += dy;
        }
    }

}
