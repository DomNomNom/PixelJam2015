using UnityEngine;
using System.Collections;

public class Wall : Character {


    protected override void respond_hello(Character other) {
        other.blockEnter();
    }
}
