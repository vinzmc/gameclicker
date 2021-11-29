using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DFTController : MonoBehaviour
{
    private static DamageFloatingText popupText;
    private static GameObject canvas;

    public static void Initialize()
    {
        canvas = GameObject.Find("GameUI");
        popupText = Resources.Load<DamageFloatingText>("Prefabs/DamageTextParent");
    }
    
    public static void CreateFloatingText(string text, Transform location)
    {
        DamageFloatingText instance = Instantiate(popupText);
        
        instance.transform.SetParent(canvas.transform, false);
        instance.SetText(text);
    }
}
