using UnityEngine;
using UnityEngine.Pool;

public class CustomUnityPool<T> where T : MonoBehaviour
{
    private ObjectPool<T> _pool;
    private T _prefab;

    public CustomUnityPool(T prefab, int prewarmedEntityCount)
    {
        _prefab = prefab;
        _pool = new ObjectPool<T>(OnCreateEntity, OnGetEntity, OnReleaseEntity, OnEntityDestroy, false, prewarmedEntityCount);
    }

    public T Get()
    {
        var entity = _pool.Get();
        return entity;
    }

    public void Release(T entity)
    {
        _pool.Release(entity);
    }

    private void OnEntityDestroy(T entity)
    {
        GameObject.Destroy(entity);
    }

    private void OnReleaseEntity(T entity)
    {
        entity.gameObject.SetActive(false);
    }

    private void OnGetEntity(T entity)
    {
        entity.gameObject.SetActive(true);
    }

    private T OnCreateEntity()
    {
        return GameObject.Instantiate(_prefab);
    }
}