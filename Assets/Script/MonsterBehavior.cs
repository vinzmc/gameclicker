using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehavior : MonoBehaviour
{
    public float health; //darah monster
    public float armor; //persentase
    public float speed; //per menit

    //Dropped Items
    public int droppedMoney;//total uang yang di drop oleh monster

    //healthbar dari monster
    public HealthBar healthBar;

    //dari object bernama GameUI di scene
    public GuiScript script;
    // animator dari object
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //Get the Animator attached to the GameObject you are intending to animate.
        animator = gameObject.GetComponent<Animator>();

        //dari object gameUI, ambil script GuiScript
        GameObject gui = GameObject.Find("GameUI");
        script = gui.GetComponent<GuiScript>();

        GameObject healthBarGui = GameObject.Find("Health Bar");
        healthBar = healthBarGui.GetComponent<HealthBar>();

        //inisiasi status monster
        // initiateMonster();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !animator.GetBool("died"))
        {
            Debug.Log(script.dps);
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
        float delay = 0.2f;
        float multiplier = animator.GetFloat("deadAnimationSpeed");
        Destroy(gameObject, (animator.GetCurrentAnimatorStateInfo(0).length * multiplier) + delay);

        //tambahkan uang saat musuh mati
        script.money += droppedMoney;
    }

    public void initiateMonster(float startHealth, float startArmor, float startSpeed, int startDroppedMoney)
    {
        //inisiasi healthbar
        GameObject healthBarGui = GameObject.Find("Health Bar");
        healthBar = healthBarGui.GetComponent<HealthBar>();

        //inisiasi status monster
        health = startHealth;
        healthBar.SetMaxHealth((int)startHealth);
        armor = startArmor;
        speed = startSpeed;
        droppedMoney = startDroppedMoney;
    }
}
