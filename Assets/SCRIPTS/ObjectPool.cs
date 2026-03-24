using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    private Queue<GameObject> pool = new Queue<GameObject>();

    public void Warmup(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public GameObject Get()
    {
        if (pool.Count > 0)
        {
            GameObject obj = pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }

        return Instantiate(prefab);
    }

    public void Release(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}