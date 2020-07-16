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
    public GameObject base_body;

    public GameObject[] CreationModeAssets; 

    public bool creation_mode = true; 
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


    public void CreatorMode()
    {
        if (creation_mode)
        {
            creation_mode = false;
            foreach(GameObject g in CreationModeAssets)
            {
                g.SetActive(false);
            }
        }
        else
        {
            creation_mode = true;
            foreach (GameObject g in CreationModeAssets)
            {
                g.SetActive(true);
            }
        }
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
