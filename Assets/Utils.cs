#define DEBUG


using UnityEngine;
using System.Collections;
using System;


public class Utils {
    /*
    A class to hold misc. static stuff
    */

    public static bool Raycast(Vector3 screenPos, out RaycastHit hit, string layerName) {
        Ray ray = Camera.main.ScreenPointToRay(screenPos);
        int layerMask = 1 << LayerMask.NameToLayer(layerName);  // 2 ^ layernumber
        return Physics.Raycast(ray, out hit, 10000, layerMask);
    }

    public static GameObject RaycastObject(Vector3 screenPos, string layerName) {
        RaycastHit hit;
        if (Raycast(screenPos, out hit, layerName)) {
            return hit.transform.gameObject;
        }
        return null;
    }


    public static void Assert(bool condition) {
        #if DEBUG
            if (!condition) throw new Exception();
        #endif
    }


    public static string ArrayToString<T>(T[] array) {
        string ret = "[";
        foreach (T element in array) {
            ret += element + ", ";
        }
        return ret + "]";
    }

    public static T RandomSample<T>(T[] array) {
        Assert(array.Length > 0);
        return array[UnityEngine.Random.Range(0, array.Length)];
    }


    // returns a new instance of the object. puts it under the transform. un-disables it. sets position
    public static GameObject Instantiate(GameObject template, Transform container, Vector3 position) {
        GameObject newObj = (GameObject) GameObject.Instantiate(
            template
        );
        newObj.transform.parent = container;
        newObj.transform.localPosition = position;

        // un-disable the object
        DisableOnStart disabler = newObj.GetComponent<DisableOnStart>();
        if (disabler != null) {
            disabler.enabled = false;
            newObj.SetActive(true);
        }

        return newObj;
    }

    public static Color colorFromHex(string hexString) {
        Color clr = new Color(0,0,0);
        if (hexString!=null && hexString.Length>0) {
            try {
                string str = hexString.Substring(1, hexString.Length - 1);
                clr.r =            (float) System.Int32.Parse(hexString.Substring(0,2), System.Globalization.NumberStyles.AllowHexSpecifier) / 255.0f;
                clr.g =            (float) System.Int32.Parse(hexString.Substring(2,2), System.Globalization.NumberStyles.AllowHexSpecifier) / 255.0f;
                clr.b =            (float) System.Int32.Parse(hexString.Substring(4,2), System.Globalization.NumberStyles.AllowHexSpecifier) / 255.0f;
                if(str.Length==8) clr.a =  System.Int32.Parse(hexString.Substring(6,2), System.Globalization.NumberStyles.AllowHexSpecifier) / 255.0f;
                else clr.a = 1.0f;
            } catch(Exception e) {
                Debug.Log("Could not convert "+hexString+" to Color. "+e);
                return new Color(0,0,0,0);
            }
        }
        return clr;
    }

}
