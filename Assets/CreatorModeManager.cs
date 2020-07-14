using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorModeManager : MonoBehaviour
{
    private GameManager gm;
    private GameObject selected_body_part;

    private static CreatorModeManager instance = null;

    private bool highlights_on = true; 
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

    public static CreatorModeManager GetInstance()
    {
        return instance; 
    }
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectBodyPart(string ID)
    {
        if (selected_body_part != null && !selected_body_part.GetComponent<BodyPart>().placed_on_body)
        {
            Debug.Log("Destroying Previous Selected Body Part: " + selected_body_part.GetComponent<BodyPart>().id);
            Destroy(selected_body_part);
        }
        selected_body_part = Instantiate(gm.GetBodyPart(ID));
        BodyPart tempPart = selected_body_part.GetComponent<BodyPart>();
        tempPart.current_selected = true; 

    }

    public void ResetSelectedBodyPart()
    {
        selected_body_part = null; 
    }

    public void TriggerBodyPartHighlights()
    {
        GameObject[] g = GameObject.FindGameObjectsWithTag("Body Part");
        if (highlights_on)
        {
            foreach (GameObject s in g)
            {
                s.GetComponent<BodyPart>().place_boundary_highlight.SetActive(false);
            }
            highlights_on = false; 
        }
        else
        {
            foreach (GameObject s in g)
            {
                s.GetComponent<BodyPart>().place_boundary_highlight.SetActive(true);
            }
            highlights_on = true; 
        }

    }
}
