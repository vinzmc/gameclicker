using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDetection : MonoBehaviour
{
    private Animator animator;
    public float health;
    public float armor;//persentase
    public float speed; //per menit

    public HealthBar healthBar;

    //Dropped Items
    public int droppedMoney = 50;//total uang yang di drop oleh monster
    

    //dari object bernama GameUI di scene
    public GameObject gui;
    GuiScript script;

    // Start is called before the first frame update
    void Start()
    {
        //Get the Animator attached to the GameObject you are intending to animate.
        animator = gameObject.GetComponent<Animator>();

        //dari object gameUI, ambil script GuiScript
        gui = GameObject.Find("GameUI");
        script = gui.GetComponent<GuiScript>();

        

        //inisiasi status monster
        initiateMonster();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !animator.GetBool("died"))
        {
            health -= totalDamage(script.dps);
            healthBar.setHealth((int)health);
            animator.SetTrigger("hitted");
        }

        if (health <= 0 && !animator.GetBool("died"))
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
        script.wave += 1;

        //delay untuk death animation
        float delay = 1.5f;
        Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length + delay);

        //tambahkan uang saat musuh mati
        script.money += droppedMoney;
    }

    void initiateMonster()
    {
        //inisiasi status monster
        health = 100f;
        healthBar.SetMaxHealth((int)health);
        armor = 0.1f;
        speed = 6f;
    }
}
