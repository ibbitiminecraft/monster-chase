using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerscripts : MonoBehaviour
{
    private string[] positions = {"Left","Right"};
    [SerializeField]
    private List<GameObject> enemies;
    [SerializeField]
    private Transform LeftPos;
    [SerializeField]
    private Transform RightPos;
    private SpriteRenderer renderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawnEnemies());
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator spawnEnemies()
    {
        
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1,3));
            int idx = Random.Range(0,enemies.Count);
            string position = positions[Random.Range(0,2)];
            var spawnEnemy = Instantiate(enemies[idx]);
            if (position == "Left")
            {
                spawnEnemy.transform.position = LeftPos.position;
                spawnEnemy.GetComponent<enemyScript>().speed = Random.Range(3,10);
                spawnEnemy.GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (position == "Right")
            {
                spawnEnemy.transform.position = RightPos.position;
                spawnEnemy.GetComponent<enemyScript>().speed = Random.Range(3,10) * -1;
                spawnEnemy.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        
    }
}
