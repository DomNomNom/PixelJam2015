using UnityEngine;
using System.Collections;

public class QuestActivator : MonoBehaviour {

    public float time_start;
    public float time_end;
    public Quest[] quests;

    private int prevIndex = 0;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        float ratioFinished = (Time.timeSinceLevelLoad - time_start) / (time_end - time_start);
        int currentMaxIndex = (int)(ratioFinished * quests.Length);
        for (; prevIndex < currentMaxIndex && prevIndex < quests.Length; ++prevIndex) {
            // Debug.Log(prevIndex);
            Player.instance.acceptQuest(quests[prevIndex]);
        }
        // if ()
	}
}
