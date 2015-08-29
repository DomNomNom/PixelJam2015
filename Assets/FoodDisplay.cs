using UnityEngine;
using System.Collections;

public class FoodDisplay : MonoBehaviour {

    public static FoodDisplay instance;

    public float textVerticalOffset = 1.0f;

    public TextMesh text_food;
    public TextMesh text_foodEaten;
    public TextMesh text_expense;

    public GameObject template_movingText;
    public Transform container_movingText;

    // Use this for initialization
    void Start () {
        instance = this;
        Debug.Assert(null != text_food);
        Debug.Assert(null != text_foodEaten);
        Debug.Assert(null != text_expense);
        Debug.Assert(null != template_movingText);
        Debug.Assert(null != container_movingText);
    }

    public void displayFatAdd(int amount) {

    }
    public void displayFatBurn(int amount) {
        GameObject txt = Utils.Instantiate(
            template_movingText,
            container_movingText,
            text_food.transform.localPosition + new Vector3(0f, textVerticalOffset, 0f)
        );
        txt.GetComponent<TextMesh>().text = "+" + appendUnit(amount);
        iTween.MoveTo(
            txt,
            iTween.Hash(
                "y", text_foodEaten.transform.position.y - textVerticalOffset,
                "time", 1.0,
                "easeType", "easeOutQuad",
                "oncomplete", "onFinishMove",//"displayFatBurnComplete",
                "oncompletetarget", txt //.GetComponent<MovingText>()
                // "delay",1,
                // "onupdate","myUpdateFunction",
                // "looptype",iTween.LoopType.pingPong
            )
        );
    }
    public void displayFatBurnComplete() {
        Debug.Log("COMLETUM!");
    }

    private string appendUnit(int amount) {
        return amount + " kJ";
    }


    // Update is called once per frame
    void Update () {
        text_food.text      = appendUnit(Player.instance.fat);
        text_foodEaten.text = appendUnit(Player.instance.fatBurned);
        text_expense.text   = appendUnit(Player.instance.moveCost());
        // text_moveCost.text = "Work: " + Player.moveCost();
    }
}
