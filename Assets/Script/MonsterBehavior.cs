using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MonsterBehavior : MonoBehaviour
{
    public float health; //darah monster
    public float armor; //persentase
    public float speed; //darah regen berdasarkan speed

    //Dropped Items
    public int droppedMoney;//total uang yang di drop oleh monster

    // parameter untuk check
    float deathDelay;
    float baseHealth;
    float regenDelay;
    float attackSpeed = 10f;
    float autoAttackDelay;
    int regenCount;

    //healthbar dari monster
    HealthBar healthBar;

    //dari object bernama GameUI di scene
    GuiScript script;
    // animator dari object
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        regenCount = 0;
        //Get the Animator attached to the GameObject you are intending to animate.
        animator = gameObject.GetComponent<Animator>();

        //dari object gameUI, ambil script GuiScript
        GameObject gui = GameObject.Find("GameUI");
        script = gui.GetComponent<GuiScript>();

        GameObject healthBarGui = GameObject.Find("Health Bar");
        healthBar = healthBarGui.GetComponent<HealthBar>();
        DFTController.Initialize();

        speed = 120f / speed;
        regenDelay = Time.time + speed;

        baseHealth = health;

        autoAttackDelay = Time.time + (5f / attackSpeed);
        //inisiasi status monster
        // initiateMonster();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !animator.GetBool("died") && !EventSystem.current.IsPointerOverGameObject())
        {
            health -= totalDamage(script.dps);
            healthBar.setHealth((int)health);
            animator.SetTrigger("hitted");
            DFTController.CreateFloatingText(totalDamage(script.dps).ToString(), transform);
        }


        if (Time.time > autoAttackDelay && !animator.GetBool("died"))
        {
            // Debug.Log(script.idleDps);
            health -= totalDamage(script.idleDps);
            healthBar.setHealth((int)health);
            // animator.SetTrigger("hitted");
            autoAttackDelay = Time.time + (5f / attackSpeed);
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
                script.wave += 1;
                MonsterSpawner monsterSpawnerScript = gameObject.GetComponentInParent<MonsterSpawner>();
                monsterSpawnerScript.spawn = true;
                deathDelay = 0f;
            }
        }
        else
        {
            animator.SetBool("died", false);
        }
        //reset darah
        if (Time.time > regenDelay)
        {
            health = baseHealth;
            healthBar.setHealth((int)health);

            regenDelay = Time.time + speed;
            regenCount++;

            if (regenCount > 5)
            {
                if (script.wave % 10 > 1)
                {
                    //reduce wave if player not strong enough
                    Destroy(gameObject);
                    script.wave -= 1;
                    MonsterSpawner monsterSpawnerScript = gameObject.GetComponentInParent<MonsterSpawner>();
                    monsterSpawnerScript.spawn = true;
                }
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
