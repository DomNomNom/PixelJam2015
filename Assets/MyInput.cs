using UnityEngine;
using System.Collections;

public class MyInput : MonoBehaviour {

    public Character[] listeners;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        int dx = 0;
        int dy = 0;

        if (Input.GetKeyDown(KeyCode.UpArrow   )) dy += 1;
        if (Input.GetKeyDown(KeyCode.LeftArrow )) dx -= 1;
        if (Input.GetKeyDown(KeyCode.DownArrow )) dy -= 1;
        if (Input.GetKeyDown(KeyCode.RightArrow)) dx += 1;

        if (Input.GetKeyDown(KeyCode.W         )) dy += 1;
        if (Input.GetKeyDown(KeyCode.A         )) dx -= 1;
        if (Input.GetKeyDown(KeyCode.S         )) dy -= 1;
        if (Input.GetKeyDown(KeyCode.D         )) dx += 1;

        if (dx != 0  ||  dy != 0) {
            foreach (Character c in listeners) {
                c.onInput(dx, dy);
            }
        }
	}
}
