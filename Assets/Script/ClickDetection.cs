using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDetection : MonoBehaviour
{
    private Animator animator;
    public float health;
    public float armor;//persentase
    public float speed; //attack per menit
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        //Get the Animator attached to the GameObject you are intending to animate.
        animator = gameObject.GetComponent<Animator>();
        health = 100f;
        armor = 0.1f;
        speed = 6f;
        damage = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !animator.GetBool("died"))
        {
            health -= totalDamage(50f);
            animator.SetTrigger("hitted");
        }

        if (health <= 0)
        {
            Debug.Log(health);
            animator.SetBool("died", true);
            deathFunction();
        }
        
    }

    float totalDamage(float hitDamage)
    {
        hitDamage -= (hitDamage * armor);
        return hitDamage;
    }

    void deathFunction()
    {
        float delay = 1.5f;
        Debug.Log(animator.GetCurrentAnimatorStateInfo(0));
        Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length + delay);
    }
}
