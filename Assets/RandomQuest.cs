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
        posX = (int)Random.Range(-5, 5);
        posY = (int)Random.Range(-5, 5);

        enter(posX, posY);
        Debug.Log("random begin: " + posX + " " + posY);
    }
}
