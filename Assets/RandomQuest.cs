using UnityEngine;
using System.Collections;

public class RandomQuest : Quest {

    private bool firstEnter = true;

    public override void begin() {
        gameObject.SetActive(true);
        if (firstEnter) {
            firstEnter = false;
        }
        else {
            //willRemoveSelf = true;
            // exit(posX, posY);
        }
        int new_posX = posX;
        int new_posY = posY;
        // Debug.Log("random begin: " + new_posY + " " + new_posX);
        while (Character.getRoom(new_posX, new_posY).Count != 0) {
            new_posX = (int)Random.Range(-5, 5);
            new_posY = (int)Random.Range(-5, 5);
            // Debug.Log("random loop: " + new_posY + " " + new_posX);
        }
        posX = new_posX;
        posY = new_posY;
        enter(posX, posY);
    }
}
