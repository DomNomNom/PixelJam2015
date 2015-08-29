using UnityEngine;
using System.Collections;

public class FoodDisplay : MonoBehaviour {

    public TextMesh text_food;
    public TextMesh text_foodEaten;
    public TextMesh text_moveCost;

	// Use this for initialization
	void Start () {
        text_food = GetComponentInChildren<TextMesh>();
        Debug.Assert(null != text_food);
        Debug.Assert(null != text_foodEaten);
        Debug.Assert(null != text_moveCost);
	}

	// Update is called once per frame
	void Update () {
        text_food.text = "Food: " + Player.food;
        text_foodEaten.text = "Food eaten: " + Player.foodEaten;
        text_moveCost.text = "Move cost: " + Player.moveCost();
	}
}
