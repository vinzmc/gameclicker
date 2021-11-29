using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject MonsterPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        spawnMonster();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void spawnMonster()
    {
        var newMonster = Instantiate(
            MonsterPrefabs,
            new Vector3(transform.position.x, transform.position.y, transform.position.z),
            Quaternion.Euler(0f, gameObject.transform.rotation.eulerAngles.y, 0f),
            gameObject.transform
        );

        newMonster.GetComponent<MonsterBehavior>().initiateMonster(1000f, 0.5f, 1f, 100);

        // newMonster.transform.position = Vector3.zero;
        // newMonster.transform.rotation = Quaternion.Euler(0f, 0, 0f);
    }
}
