using UnityEngine;

public class Launchpoint : MonoBehaviour
{
    public GameObject _projectile;
    public Transform _spawnPoint;

    public void Launch()
    {
        //Vector2 spawnPoint = new Vector2(Random.Range(-10f, 10f), Random.Range(-5f, 5f));
        Instantiate(_projectile, _spawnPoint.position, _spawnPoint.rotation);
    }
}
