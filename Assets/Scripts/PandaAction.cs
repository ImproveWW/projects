using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

[RequireComponent (typeof(Panda))]
[RequireComponent(typeof(SpriteRenderer))]

public class PandaAction : MonoBehaviour
{
    private Panda _panda;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _right, _left;
    [SerializeField] public GameObject _button;

    public GameObject _projectile;
    public Transform _spawnPoint;


    private void Awake()
    {
        _panda = GetComponent<Panda>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _panda.Down += OnDown;
    }

    private void OnDisable()
    {
        _panda.Down -= OnDown;
    }



    private void OnDown()
    {
        if (_spriteRenderer.sprite == _right)
        {
            _spriteRenderer.sprite = _left;
        }
        else _spriteRenderer.sprite = _right;

        Instantiate(_projectile, _spawnPoint.position, Random.rotation);
    }       
}
