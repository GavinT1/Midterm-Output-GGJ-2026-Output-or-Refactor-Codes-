using UnityEngine;

public class Bullet_Messy : MonoBehaviour
{
    private ObjectPool pool;
    private Rigidbody rb;
public void Init(ObjectPool poolRef)
{
    pool = poolRef;
    rb = GetComponent<Rigidbody>();
}

public void Fire(Vector3 dir)
{
    rb.linearVelocity = dir * 20f;
}

private void OnCollisionEnter(Collision collision)
{
    rb.linearVelocity = Vector3.zero;
    pool.Release(gameObject);

}
}