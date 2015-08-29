﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : Character {
    public static Player instance;


    public int fatBurned = 0;

    public int fatHigh;
    public int fatLow;

    private int _fat = 100;
    public int fat
    {
        get { return _fat; }
        set {
            int diff = value - _fat;
            if (diff == 0) {  // no change
                return;
            }
            else if (diff < 0) {  // burn
                fatBurned += -diff;
                FoodDisplay.instance.displayFatBurn(-diff);
            }
            else {  // fat gain
                FoodDisplay.instance.displayFatAdd(diff);
            }

            _fat = value;
        }
    }


    private float lastMoveTime = 0;
    public AudioSource movementSound;
    public TextMesh textMesh;

    public AnimationCurve moveCostCurve;
    public int moveCost() {
        float restingTime = Time.time - lastMoveTime;
        return (int)moveCostCurve.Evaluate(restingTime);
    }

    bool wasDead = false;
    private List<ShowIfPlayerDead> deathListeners = new List<ShowIfPlayerDead>();
    public void addDeathListener(ShowIfPlayerDead listener) {
        deathListeners.Add(listener);
    }

    public List<Quest> quests = new List<Quest>();
    public void acceptQuest(Quest q) {
        if (!quests.Contains(q)) {
            quests.Add(q);
        }
        else {
            Debug.LogWarning("Quest is being added twice: "+ q);
        }
        q.begin();
        // Debug.Log("Player accepted: " + q);
    }

    // Use this for initialization
    protected override void Start () {
        instance = this;

        base.Start();
        Debug.Assert(textMesh != null);
    }

    // Update is called once per frame
    protected override void Update () {
        base.Update();
        this.RefreshColor();

        if (fat < 0 && !wasDead) {
            wasDead = true;
            foreach (var listener in deathListeners) {
                listener.onPlayerDeath();
            }
        }
    }

    private void RefreshColor() {
       Color c = Color.red;
       if (fat < fatLow) {
            c = Color.red;
       } else if (fat < fatHigh) {
            c = Color.yellow;
       } else {
            c = Color.green;
       }
       textMesh.color = c;
    }



    protected override void hello(Character other) {
        Debug.Log("hello other: " + other);
    }

    public override void onInput(int dx, int dy) {
        if (fat < 0) return;
        if (enter(posX + dx, posY + dy)) {
            exit(posX, posY);
            posX += dx;
            posY += dy;

            fat -= moveCost();
            lastMoveTime = Time.time;
        }
        movementSound.Play();
    }

}
