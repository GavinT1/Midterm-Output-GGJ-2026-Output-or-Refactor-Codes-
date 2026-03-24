using UnityEngine;
using MyGame;

public class GameplayFactory : MonoBehaviour
{
    [Header("Pools")]
    public ObjectPool bulletPool;
    public ObjectPool enemyPool;
    public ObjectPool explosionPool;


    public GameObject SpawnBullet(Vector3 pos, Quaternion rot)
    {
        GameObject bullet = bulletPool.Get(); // get from pool
        bullet.transform.SetPositionAndRotation(pos, rot);

        Bullet_Messy b = bullet.GetComponent<Bullet_Messy>();
        if (b != null)
        {
            b.Init(bulletPool);             // assign pool
            b.Fire(rot * Vector3.forward);  // shoot
        }

        return bullet;
    }

    public GameObject SpawnEnemy(Vector3 pos, Quaternion rot)
    {
        GameObject enemy = enemyPool.Get();
        enemy.transform.SetPositionAndRotation(pos, rot);

        Enemy_Messy e = enemy.GetComponent<Enemy_Messy>();
        if (e != null)
        {
            e.Init(enemyPool);   // assign pool
            e.ResetEnemy();      // reset HP, scale, etc.
        }

        return enemy;
    }

    public GameObject SpawnExplosion(Vector3 pos)
    {
        GameObject fx = explosionPool.Get();
        fx.transform.position = pos;

        ExplosionFX_Messy ex = fx.GetComponent<ExplosionFX_Messy>();
        if (ex != null)
        {
            ex.Init(explosionPool); // assign pool
            ex.Play();              // start FX
        }

        return fx;
    }
}