using UnityEngine;
using System.Collections;

public class TimeStats : ShowIfPlayerDead {

    public static readonly float songEndTime = 53.5f;
    public static readonly float beatPeriod = 60.0f / 135.1f;
    public static float timeRemaining = songEndTime;
    public static int beatCount;
    public static int beatCountModdable;

    public TextMesh countdownText;

    bool playerDead = false;

    private readonly float beatOffset = 0.0f;

    public float scaleMultiplyer = 1.2f;
    private Vector3 originalScale;
    public float ratioBig = 0.2f;

    // Use this for initialization
    void Start () {
        Player.instance.addDeathListener(this);
        originalScale = countdownText.transform.localScale;
    }

    public override void onPlayerDeath() {
        playerDead = true;
    }

    // Update is called once per frame
    void Update () {
        // if (Time.timeSinceLevelLoad > beatOffset && !startedPulse) {
        //     startedPulse = true;
        //     iTween.MoveTo(
        //         countdownText.gameObject,
        //         iTween.Hash(
        //             "scale", new Vector3(2.0f, 2.0f, 2.0f), //countdownText.transform.localScale * 10.5F,
        //             // "x", 2.0f,
        //             "time", beatPeriod,
        //             "easeType", "easeInQuart",
        //             // "delay", 1.0f, //0.5 * beatPeriod,

        //             // "oncomplete", "onFinishMove",//"displayFatBurnComplete",
        //             // "oncompletetarget", txt //.GetComponent<MovingText>()
        //             // "onupdate","myUpdateFunction",
        //             "looptype",iTween.LoopType.pingPong
        //         )
        //     );
        // }

        if (!playerDead) {
            float time = Time.timeSinceLevelLoad;
            beatCount = (int)((time + beatOffset) / beatPeriod);
            beatCountModdable = beatCount + 10007;

            timeRemaining = songEndTime - time;
            timeRemaining = Mathf.Max(0, timeRemaining);
            countdownText.text = timeRemaining.ToString("F2")  + "s";

            if (timeRemaining < 10.0f) {
                countdownText.color = Color.red;
            }
            bool isInBeat = Mathf.Repeat(time + beatOffset, beatPeriod) < ratioBig * beatPeriod;
            if (timeRemaining <= 0.0f) {
                isInBeat = true;
            }
            countdownText.transform.localScale = (isInBeat)? originalScale * scaleMultiplyer : originalScale;
        }
    }
}
