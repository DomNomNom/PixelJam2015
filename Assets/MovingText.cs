using UnityEngine;
using System.Collections;

public class MovingText : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

    void onFinishMove() {
        Object.Destroy(gameObject);
    }
}
