using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drums : MonoBehaviour
{
    [SerializeField] private Camera _camera = null;
    private Collider2D _collider = null;

    [HideInInspector] public float _drumStartTime = 10f;
    [HideInInspector] public float _drumTimeLeft = 10f;
    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<Collider2D>();
        _drumTimeLeft = _drumStartTime;
    }

    // Update is called once per frame
    void Update()
    {
        _drumTimeLeft -= Time.deltaTime;

        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
			Collider2D plant = Physics2D.OverlapPoint(mousePosition);
            if(plant == _collider)
            {
                _drumTimeLeft = _drumStartTime;
            }
        }
    }
}
