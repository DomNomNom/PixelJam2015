using UnityEngine;
using System.Collections;

public class Blink : MonoBehaviour {

    public GameObject childToBlink;
    public float animationSpeed = 1.0f;

    // Use this for initialization
    void Start () {
        Debug.Assert(childToBlink != null);
    }

    // Update is called once per frame
    void Update () {
        bool isActive = (int)(Mathf.Repeat(animationSpeed * Time.time, 2)) == 0;
        childToBlink.SetActive(isActive);
    }
}
