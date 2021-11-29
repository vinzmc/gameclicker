using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageFloatingText : MonoBehaviour
{
    public Animator anim;
    private Text damageText;

    void Start()
    {
        AnimatorClipInfo[] clipInfo = anim.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, clipInfo[0].clip.length);
        damageText = GetComponent<Text>();
    }

    public void SetText(string text)
    {
        damageText.text = text;
        
    }
}
