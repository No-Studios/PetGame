using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toes : MonoBehaviour
{
    [SerializeField] private Manager _manager = null;
    //variables for clicking
    [SerializeField] private Camera _camera = null;

    private Animator _animator = null;
    private Collider2D _collider = null;


    //variables for spawner
    [SerializeField] private Transform _spawnPoint = null;
    [SerializeField] private GameObject _toe = null;
    



    void Start()
    {
        _collider = GetComponent<Collider2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if you click on the toe, it will trigger an animation of being pulled out of the dirt
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
			Collider2D plant = Physics2D.OverlapPoint(mousePosition);
            if(plant == _collider && _animator.GetCurrentAnimatorStateInfo(0).IsName("ToePulled") != true)
            {
                _animator.SetTrigger("pulled");
                _manager.toeNumber++;
                print(_manager.toeNumber);
                ToeSpawn();
            }
        }
    }

    void ToeSpawn()
    {
        Instantiate(_toe, _spawnPoint.position, Quaternion.identity);
    }
}
