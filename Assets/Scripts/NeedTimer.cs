using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedTimer : MonoBehaviour
{
    [SerializeField] private Pet _pet = null;
    [SerializeField] private bool _thirst = false;
    [SerializeField] private bool _hunger = false;
    [SerializeField] private bool _fun = false;
    [SerializeField] private Drums _drums = null;
    private Transform _timer;

    private float _initialScale;
    private float _initialTime;
    private float _timeLeft = 10f;

    // Start is called before the first frame update
    void Awake()
    {        
        _timer = GetComponent<Transform>();
        _initialScale = _timer.localScale.x;
        _initialTime = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if(_thirst == false && _hunger == true && _fun == false)
        {
            _timeLeft = _pet.current_hungry_time;
        } else if(_thirst == true && _hunger == false && _fun == false){
            _timeLeft = _pet.current_thirsty_time;
        } else if(_thirst == false && _hunger == false && _fun == true){
            _timeLeft = _drums._drumTimeLeft;
        }
        print(_drums._drumTimeLeft);
        //_timeLeft -= Time.deltaTime;
        //print(_pet.current_hungry_time);
        //print(_initialTime);
        //print(_initialScale);


        float newX = Mathf.Lerp(0, _initialScale, _timeLeft / _initialTime);
        Vector3 newScale = new Vector3(newX, _timer.localScale.y, _timer.localScale.z);
        _timer.localScale = newScale;
        
    }   
}
