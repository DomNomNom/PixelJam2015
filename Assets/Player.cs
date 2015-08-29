using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : Character {

    public static int food = 100;
    public static int foodEaten = 0;
    private static float lastMoveTime;
    public AudioSource movementSound;

    private static Player defaultInstance;
    public AnimationCurve moveCostCurve;
    public static int moveCost() {
        float restingTime = Time.time - lastMoveTime;
        return (int)defaultInstance.moveCostCurve.Evaluate(restingTime);
    }
    public static void eat(int amount) {
        if (food < 0) return;
        food -= amount;
        foodEaten += amount;
    }

    private float nextEatPeriod;
    public float eatPeriod = 3.0f;

    public static List<Quest> quests = new List<Quest>();
    public static void acceptQuest(Quest q) {
        if(!quests.Contains(q)) {
            quests.Add(q);
        }
        q.begin();
        Debug.Log("Player accepted: " + q); 
    }

    // Use this for initialization
    protected override void Start () {
        if (defaultInstance == null) {
            defaultInstance = this;
        }

        base.Start();
        nextEatPeriod = Time.time + eatPeriod;
    }

    // Update is called once per frame
    protected override void Update () {
        if (Time.time > nextEatPeriod) {
           nextEatPeriod += eatPeriod;
           eat(1); // execute block of code here
        }

        base.Update();
    }


    protected override void hello(Character other) {
        Debug.Log("hello other: " + other);
    }

    public override void onInput(int dx, int dy) {
        if (food < 0) return;
        if (enter(posX + dx, posY + dy)) {
            exit(posX, posY);
            posX += dx;
            posY += dy;

            food -= moveCost();
            lastMoveTime = Time.time;
        }
        movementSound.Play();
    }

}
