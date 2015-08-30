using UnityEngine;
using System.Collections;

public class DanceFloorManager : MonoBehaviour {

    public Transform ColContainer;

    public float changeStartTime = 7.0f;

    private int colIndex = -1;
    public int delay = 5;
    public int currentDelay = 0;


    public Color color2;
    public Color color3;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
        transform.localPosition = new Vector3(
            0.0f,
            -(float)(TimeStats.beatCountModdable % 2),
            0.0f
        );

        if (Time.timeSinceLevelLoad < changeStartTime) return;
        currentDelay += 1;
        if (currentDelay < delay) {
            return;
        }
        currentDelay = 0;

        colIndex += 1;
        // int colIndex = TimeStats.beatCount;
        // if (colIndex == prevDoneCol) return;
        // prevDoneCol = colIndex;
        // if (colIndex < 0) return;
        if (colIndex >= ColContainer.childCount) return;


        // Debug.Log(allChildren[colIndex]);
        foreach (Transform floor in ColContainer.GetChild(colIndex)) {
            DanceFloor dance = floor.GetComponent<DanceFloor>();
            floor.GetComponentInChildren<SpriteRenderer>().color = (
                ((colIndex + dance.posY) % 2 == 0)? color2 : color3
            );
        }
    }
}
