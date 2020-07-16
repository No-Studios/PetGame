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
    [SerializeField] private Pet _pet = null;
    public bool isEmpty = false;
    public bool filledEnough = false; 
    // Start is called before the first frame update

    void Update()
    {
        if(_clickAndDrag.bottlePour == true && _transform.localPosition.y <= _maxY)
        {
            _transform.position += new Vector3(0f, 1f, 0f) * _riseSpeed;
            Debug.Log("goingUp");
        }
        if(_pet.state == Pet.PetState.Drinking && _transform.localPosition.y >= _minY)
        {
            Debug.Log(_minY + " > " + _transform.localPosition.y);
            _transform.position += new Vector3(0f, 1f, 0f) * (-1 * _riseSpeed);
        }

        if (_transform.localPosition.y < _minY)
        {
            Debug.Log("Slime empty");
            isEmpty = true;
        }
        else if (_transform.localPosition.y > _minY + 1) 
        {
            Debug.Log("Slime filled");
            isEmpty = false;
        }

        //if(_transform.localPosition.y >)
    }
}
