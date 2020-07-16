using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndDrag : MonoBehaviour
{
    [SerializeField] private Transform _canSpot;
    [SerializeField] private Sprite _normalSprite = null;
    [SerializeField] private Sprite _pourSprite = null;
    
    private bool _isClick = false;
    private Rigidbody2D _can = null;
    private SpriteRenderer _spriteRenderer = null;
    // Start is called before the first frame update
    void Awake()
    {
        _can = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        _isClick = true;
    }

    void OnMouseDrag()
    {
        if (_isClick == true){
            Vector2 cursorPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            _can.position = cursorPosition;
        }
    }

    void OnMouseUp()
    {
        _isClick = false;
        _can.position = _canSpot.position;
    }

    void OnTriggerEnter2D()
    {
        _spriteRenderer.sprite = _pourSprite;
    }

    void OnTriggerExit2D()
    {
        _spriteRenderer.sprite = _normalSprite;
    }
}
