using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject[] body_parts;

    public Texture2D default_cursor;
    public Texture2D place_bodypart_cursor; 
    private static GameManager instance;

    private void Awake()
    {

        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public static GameManager GetInstance()
    {
        return instance; 
    }

    public GameObject GetBodyPart(string ID)
    {
        foreach(GameObject g in body_parts)
        {
            if(g.GetComponent<BodyPart>().id == ID)
            {
                return g;
            }
        }
        Debug.LogWarning("Body Part ID not in list");
        return null; 
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(default_cursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
