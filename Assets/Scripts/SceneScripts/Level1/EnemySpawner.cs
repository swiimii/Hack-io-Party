using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{
    List<Enemy> enemies = new List<Enemy>();
    public int numEnemies = 5;
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numEnemies; ++i)
        {
            var newEnemy = Instantiate(enemyPrefab, new Vector3(0.0f, i * 1.0f, 0.0f), Quaternion.identity).GetComponent<Enemy>();
            //newEnemy.SetRow(i + 1);
            enemies.Add(newEnemy);

        }
    }

    // Update is called once per frame
    void Update()
    {
    }

}
