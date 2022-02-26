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
        
    }

    // Update is called once per frame
    void Update()
    {
        KillOldEnemies();
        SpawnNewEnemies();
    }

    private void KillOldEnemies()
    {
        var enemiesArray = enemies.ToArray();
        foreach(var enemy in enemiesArray)
        {
            if (enemy.IsOutOfScreenspace())
            {
                enemies.Remove(enemy);
                Destroy(enemy);
            }
        }
        
    }

    private void SpawnNewEnemies()
    {
        int num = enemies.Count();

        if (num < numEnemies)
        {
            for(int i = 0; i < numEnemies - num; ++i)
            {
                var instance = Instantiate(enemyPrefab);
                enemies.Add(instance.GetComponent<Enemy>());
            }
        }
    }
}
