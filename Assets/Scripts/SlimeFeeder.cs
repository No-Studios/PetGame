using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeFeeder : MonoBehaviour
{
    [SerializeField] private Transform _transform = null;
    [SerializeField] private float _riseSpeed = 2f;
    [SerializeField] private float _minY = 0f;
    [SerializeField] private float _maxY = 2f;
    [SerializeField] private ClickAndDrag _clickAndDrag = null;
    // Start is called before the first frame update

    void Update()
    {
        if(_clickAndDrag.bottlePour == true && _transform.position.y <= _maxY)
        {
            _transform.position += new Vector3(0f, 1f, 0f) * _riseSpeed;
            //print("goingUp");
        }
    }
}
