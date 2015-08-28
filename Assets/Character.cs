﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour {

    private static Dictionary<int, Dictionary<int, List<Character>>> rooms = new Dictionary<int, Dictionary<int, List<Character>>>();

    // returns or creates a room at a given coordinate
    static List<Character> getRoom(int x, int y) {

        // get or create row
        Dictionary<int, List<Character>> row = null;
        if (!rooms.TryGetValue(y, out row)) {
            row = new Dictionary<int, List<Character>>();
            rooms[y] = row;
        }

        // get or create room
        List<Character> room = null;
        if (!row.TryGetValue(x, out room)) {
            room = new List<Character>();
            row[x] = room;
        }

        Utils.Assert(room != null);
        return room;
    }


    // end static

    protected int posX, posY;

    protected virtual void Start() {
        posX = (int)Mathf.Round(transform.position.x);
        posY = (int)Mathf.Round(transform.position.y);
        enter(posX, posY);
    }
    protected virtual void Update() {
        transform.position = new Vector3(
            posX,
            posY,
            transform.position.z
        );
    }


    private bool gotMovementBlocked;
    protected virtual bool enter(int x, int y) {
        List<Character> room = getRoom(x,y);
        Utils.Assert(!room.Contains(this));

        gotMovementBlocked = false;
        List<Character> greeted = new List<Character>();
        foreach (Character roomie in room) {
            hello(roomie);
            roomie.respond_hello(this);
            greeted.Add(roomie);
            if (gotMovementBlocked){
                break;
            }
        }

        if (gotMovementBlocked) {
            // say bye to all we said hello to
            foreach (Character roomie in greeted) {
                bye(roomie);
                roomie.respond_bye(this);
            }
        }
        else {
            room.Add(this);
        }

        return !gotMovementBlocked;
    }
    public virtual void blockEnter() {
        gotMovementBlocked = true;
    }

    protected virtual void exit(int x, int y) {
        List<Character> room = getRoom(x,y);
        Utils.Assert(room.Contains(this));

        foreach (Character roomie in room) {
            bye(roomie);
            roomie.respond_bye(this);
        }
        room.Remove(this);

        // TODO: clean up empty rooms and cells
    }


    protected virtual void hello(Character other) { }          // when we come enter a room we say hello to everyone
    protected virtual void respond_hello(Character other) { }  // when someone comes into our room

    protected virtual void bye(Character other) { }
    protected virtual void respond_bye(Character other) { }



    public virtual void onInput(int dx, int dy) { }  // we have received input from something

}