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


    public static Color HSVToRGB(float H, float S, float V) {
        if (S == 0f)
            return new Color(V,V,V);
        else if (V == 0f)
            return Color.black;
        else {
            Color col = Color.black;
            float Hval = H * 6f;
            int sel = Mathf.FloorToInt(Hval);
            float mod = Hval - sel;
            float v1 = V * (1f - S);
            float v2 = V * (1f - S * mod);
            float v3 = V * (1f - S * (1f - mod));
            switch (sel + 1) {
                case 0:
                    col.r = V;
                    col.g = v1;
                    col.b = v2;
                    break;
                case 1:
                    col.r = V;
                    col.g = v3;
                    col.b = v1;
                    break;
                case 2:
                    col.r = v2;
                    col.g = V;
                    col.b = v1;
                    break;
                case 3:
                    col.r = v1;
                    col.g = V;
                    col.b = v3;
                    break;
                case 4:
                    col.r = v1;
                    col.g = v2;
                    col.b = V;
                    break;
                case 5:
                    col.r = v3;
                    col.g = v1;
                    col.b = V;
                    break;
                case 6:
                    col.r = V;
                    col.g = v1;
                    col.b = v2;
                    break;
                case 7:
                    col.r = V;
                    col.g = v3;
                    col.b = v1;
                    break;
            }
            col.r = Mathf.Clamp(col.r, 0f, 1f);
            col.g = Mathf.Clamp(col.g, 0f, 1f);
            col.b = Mathf.Clamp(col.b, 0f, 1f);
            return col;
        }
    }


}
