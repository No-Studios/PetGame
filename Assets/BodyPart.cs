using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    public string id = "";
    public bool current_selected = false;
    public bool placed_on_body = false;
    private bool can_place_part = false;
    public GameObject place_boundary_highlight; 

    // Start is called before the first frame update
    void Start()
    {
        if (!placed_on_body)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (current_selected)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }

        if (can_place_part && Input.GetMouseButtonDown(0))
        {
            current_selected = false;
            Cursor.SetCursor(GameManager.GetInstance().default_cursor, Vector2.zero, CursorMode.ForceSoftware);
            CreatorModeManager.GetInstance().ResetSelectedBodyPart(); 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (current_selected)
        {
            Cursor.SetCursor(GameManager.GetInstance().place_bodypart_cursor, Vector2.zero, CursorMode.ForceSoftware);
            can_place_part = true; 
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (current_selected)
        {
            Cursor.SetCursor(GameManager.GetInstance().default_cursor, Vector2.zero, CursorMode.ForceSoftware);
            can_place_part = true; 
        }
    }
}
