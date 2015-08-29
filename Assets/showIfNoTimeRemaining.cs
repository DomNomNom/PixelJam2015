using UnityEngine;
using System.Collections;

public class showIfNoTimeRemaining : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
	   GetComponent<MeshRenderer>().enabled = (TimeStats.timeRemaining <= 0.0f);
	}
}
