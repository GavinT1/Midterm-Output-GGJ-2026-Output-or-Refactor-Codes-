using UnityEngine;

public class EnemySpawner_Messy : MonoBehaviour
{
    public GameplayFactory factory;

void Start()
{
    InvokeRepeating(nameof(SpawnEnemy), 1f, 2f);
}

void SpawnEnemy()
{
    factory.SpawnEnemy(transform.position, Quaternion.identity);
}

}
