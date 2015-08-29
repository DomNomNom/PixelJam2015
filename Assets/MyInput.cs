using UnityEngine;
using System.Collections;

public class MyInput : MonoBehaviour {

    public Character[] listeners;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

        // esc = quit
        if (Input.GetKeyDown(KeyCode.Escape   )) {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #elif UNITY_WEBPLAYER
                Application.OpenURL("http://google.com");
            #else
                Application.Quit();
            #endif
        }

        // space = restart
        if (Input.GetKeyDown(KeyCode.Space   )) {
            Application.LoadLevel(Application.loadedLevel);
        }


        if (Input.GetKeyDown(KeyCode.UpArrow   ))  singleMove( 0, 1); // dy += 1;
        if (Input.GetKeyDown(KeyCode.LeftArrow ))  singleMove(-1, 0); // dx -= 1;
        if (Input.GetKeyDown(KeyCode.DownArrow ))  singleMove( 0,-1); // dy -= 1;
        if (Input.GetKeyDown(KeyCode.RightArrow))  singleMove( 1, 0); // dx += 1;

        if (Input.GetKeyDown(KeyCode.W         ))  singleMove( 0, 1);
        if (Input.GetKeyDown(KeyCode.A         ))  singleMove(-1, 0);
        if (Input.GetKeyDown(KeyCode.S         ))  singleMove( 0,-1);
        if (Input.GetKeyDown(KeyCode.D         ))  singleMove( 1, 0);

    }

    void singleMove(int dx, int dy) {
        foreach (Character c in listeners) {
            c.onInput(dx, dy);
        }
    }
}
