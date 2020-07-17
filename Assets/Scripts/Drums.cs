using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drums : MonoBehaviour
{
    [SerializeField] private Camera _camera = null;
    private Collider2D _collider = null;

    [HideInInspector] public float _drumStartTime = 10f;
    [HideInInspector] public float _drumTimeLeft = 10f;
    private AudioSource audioSource;
    private bool druming = false;
    private float timeChange = 1;

    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<Collider2D>();
        _drumTimeLeft = _drumStartTime;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        _drumTimeLeft -= Time.deltaTime *timeChange;
        Debug.Log(_drumTimeLeft);

        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
			Collider2D plant = Physics2D.OverlapPoint(mousePosition);
            if(plant == _collider && druming == false)
            {
                druming = true;
                
                audioSource.Play();
                timeChange = -1;
            }
            else if (plant == _collider && druming == true)
            {
                druming = false;
                timeChange = 1;
                audioSource.Stop();
            }
            
        }
        if (_drumTimeLeft >= _drumStartTime)
        {
            Debug.Log("weee");
            _drumTimeLeft = _drumStartTime;
            druming = false;
            timeChange = 1;
            audioSource.Stop();
        }

    }
}
