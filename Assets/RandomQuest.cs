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
            exit(posX, posY);
        }
        int new_posX = posX;
        int new_posY = posY;
        while (new_posX == posX && new_posY == posY) {
            new_posX = (int)Random.Range(-5, 5);
            new_posY = (int)Random.Range(-5, 5);
        }
        posX = new_posX;
        posY = new_posY;
        enter(posX, posY);
        Debug.Log("random begin: " + posX + " " + posY);
    }
}
