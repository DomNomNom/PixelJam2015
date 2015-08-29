using UnityEngine;
using System.Collections;

public class GameOverDisplay : MonoBehaviour {

    public TextMesh text_moveCost;

	// Use this for initialization
	void Start () {
        Debug.Assert(null != text_moveCost);
	}

	// Update is called once per frame
	void Update () {
        if (Player.instance.fat < 0) {
            text_moveCost.gameObject.SetActive(true);
        }

	}
}
