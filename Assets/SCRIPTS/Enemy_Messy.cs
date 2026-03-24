using UnityEngine;
using MyGame;

namespace MyGame 
{
public class Enemy_Messy : MonoBehaviour
{
    public float hp = 3f;
    public float speed = 3f;

    Transform player;
    private ObjectPool pool;

    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null) player = p.transform;
    }

    public void Init(ObjectPool poolRef)
    {
        pool = poolRef;
    }

    public void ResetEnemy()
    {
        hp = 3f;
        transform.localScale = Vector3.one;
    }

    void Update()
    {
        if (GameController_Messy.I == null) return;
        if (GameController_Messy.I.gameState != 1) return;

        if (player == null) return;

        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        transform.LookAt(player.position);

        if (transform.position.y < -50f) transform.position = Vector3.zero;
    }

    void OnCollisionEnter(Collision c)
    {
        Bullet_Messy b = c.gameObject.GetComponent<Bullet_Messy>();
        if (b != null)
        {
            hp -= 1f;

            if (hp <= 0)
            {
                // spawn explosion via factory
                if (GameController_Messy.I != null && GameController_Messy.I.factory != null)
                {
                    GameController_Messy.I.factory.SpawnExplosion(transform.position);
                }

                
                pool.Release(gameObject);
            }
        }
    }
}
}