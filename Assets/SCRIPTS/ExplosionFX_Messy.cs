using UnityEngine;

public class ExplosionFX_Messy : MonoBehaviour
{
    private ObjectPool pool;

public void Init(ObjectPool poolRef)
{
    pool = poolRef;
}

public void Play()
{
    Invoke(nameof(ReturnToPool), 1f);
}

void ReturnToPool()
{
    pool.Release(gameObject);
}
}
