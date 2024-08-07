using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class CustomPool : MonoBehaviour
{
    private ObjectPool<GameObject> _pool;
    private CustomPool _button;
    [SerializeField] private GameObject _prefab;
    public CustomPool(GameObject prefab)
    {
        _prefab = prefab;
        _pool = new ObjectPool<GameObject>(OnCreateGameObject, OnGetGameObject, OnRelease, OnGameObjectDestroy, prefab);
    }

    /*public GameObject Get()
    {   
        /var obj = _pool.Get();
        return obj;
    }*/

    public void Release(GameObject obj)
    {
        _pool.Release(obj);
    }

    private void OnGameObjectDestroy(GameObject obj)
    {
        GameObject.Destroy(obj);
    }

    private void OnRelease(GameObject obj)
    {
        obj.gameObject.SetActive(false);
    }

    private void OnGetGameObject(GameObject obj)
    {
        obj.gameObject.SetActive(true);
    }

    private GameObject OnCreateGameObject()
    {
        return GameObject.Instantiate(_prefab);
    }

    public void Destr() {
        OnGameObjectDestroy(_prefab);
    }
}

