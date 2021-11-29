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

    // parameter untuk check
    float deathDelay;
    //healthbar dari monster
    HealthBar healthBar;

    //dari object bernama GameUI di scene
    GuiScript script;
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
        DFTController.Initialize();

        //inisiasi status monster
        // initiateMonster();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !animator.GetBool("died"))
        {
            health -= totalDamage(script.dps);
            healthBar.setHealth((int)health);
            animator.SetTrigger("hitted");
            DFTController.CreateFloatingText(totalDamage(script.dps).ToString(), transform);
        }

        if (health <= 0)
        {
            animator.SetBool("died", true);

            //delay animation
            if (deathDelay == 0f)
            {
                float delay = 1.5f;
                deathDelay = Time.time + delay;
            }

            //destroy object + give money after delay
            if (Time.time > deathDelay)
            {
                Destroy(gameObject);
                script.money += droppedMoney;
                MonsterSpawner monsterSpawnerScript = gameObject.GetComponentInParent<MonsterSpawner>();
                monsterSpawnerScript.spawn = true;
                deathDelay = 0f;
            }
        }
    }

    float totalDamage(float hitDamage)
    {
        hitDamage -= (hitDamage * armor);
        return hitDamage;
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
