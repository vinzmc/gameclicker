using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public bool spawn = true;
    public GameObject MonsterPrefabs;
    GuiScript script;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gui = GameObject.Find("GameUI");
        script = gui.GetComponent<GuiScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
            spawnMonster();
            spawn = false;
        }
    }

    void spawnMonster()
    {
        var newMonster = Instantiate(
            MonsterPrefabs,
            new Vector3(transform.position.x, transform.position.y, transform.position.z),
            Quaternion.Euler(0f, gameObject.transform.rotation.eulerAngles.y, 0f),
            gameObject.transform
        );
        float monsterHP = script.wave * 1000f;
        float monsterArmor = script.wave * 0.01f;
        float monsterSpeed = script.wave * 1f;
        int droppedMoney = 100 + script.wave * 20;

        newMonster.GetComponent<MonsterBehavior>().initiateMonster(monsterHP, monsterArmor, monsterSpeed, droppedMoney);

        // newMonster.transform.position = Vector3.zero;
        // newMonster.transform.rotation = Quaternion.Euler(0f, 0, 0f);
    }
}
