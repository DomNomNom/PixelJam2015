using UnityEngine;
using System.Collections;

public class DanceFloor : MonoBehaviour {

    public int posX, posY;

    private SpriteRenderer sprite;
    public Color[] colorScheme1;
    // public Color[] colorScheme2;

	// Use this for initialization
	void Start () {
        posX = (int)Mathf.Round(transform.position.x);
        posY = (int)Mathf.Round(transform.position.y);
        // sprite = GetComponentInChildren<SpriteRenderer>();

        // // Color[] currentColorScheme = colorScheme1;
        // int numba = posX + posY + TimeStats.beatCount;
        // int index = (numba + 10000) % colorScheme1.Length;
        // Debug.Log(colorScheme1.Length);
        // sprite.color = colorScheme1[index];
	}

}
