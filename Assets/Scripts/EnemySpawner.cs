using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyReference;

    [SerializeField]
    private Transform leftPos,
        rightPos;

    private GameObject spawnedEnemy;

    private int randomIndex;
    private int randomSide;

    private Vector3 tempPos;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonster());
    }

    // Update is called once per frame
    // void Update() { }

    IEnumerator SpawnMonster()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 7));

            randomIndex = Random.Range(0, enemyReference.Length);
            randomSide = Random.Range(0, 2);

            spawnedEnemy = Instantiate(enemyReference[randomIndex]);
            tempPos = spawnedEnemy.transform.position;

            // left side
            if (randomSide == 0)
            {
                tempPos.x = leftPos.position.x;
                spawnedEnemy.transform.position = tempPos;
                spawnedEnemy.GetComponent<Enemy>().speed = Random.Range(4, 10);
            }
            // right side
            else
            {
                tempPos.x = rightPos.position.x;
                spawnedEnemy.transform.position = tempPos;
                spawnedEnemy.GetComponent<Enemy>().speed = -Random.Range(4, 10);
                spawnedEnemy.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }
}
