using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pet : MonoBehaviour
{
    public string pet_name;

    [SerializeField]
    private int max_slime;
    private int current_slime;

    public Text hungerUI;
    public Text thirstUI;

    private bool isHungry = false;
    private bool isThirsty = false; 
    [SerializeField]
    private int max_toes;
    private int current_toes;

    private Animator anim; 

    private int max_happiness_level = 10;
    private int happiness_level;
    public bool game_start; 

    [SerializeField]
    private float hungry_timer = 10f;
    private float current_hungry_time;

    [SerializeField]
    private float thirsty_timer = 10f;
    private float current_thirsty_time; 
    public PetState state = PetState.Idle;

    [SerializeField]
    private float eating_timer = 5f;
    private float current_eating_time;

    [SerializeField]
    private float drinking_timer = 5f;
    private float current_drinking_time;


    private Queue<PetState> queued_actions; 

    // Start is called before the first frame update
    void Start()

    {
        anim = GetComponent<Animator>();
        anim.SetBool("Hungry", false);
        anim.SetBool("Thirsty", false);
        current_eating_time = eating_timer;
        current_drinking_time = drinking_timer;
        queued_actions = new Queue<PetState>();
        current_hungry_time = hungry_timer;
        current_thirsty_time = thirsty_timer;

        happiness_level = max_happiness_level; 
    }

    // Update is called once per frame
    void Update()
    {
        if (game_start)
        {
            hungerUI.text = ""+current_hungry_time;
            thirstUI.text = ""+current_thirsty_time;
            // Queues Thirst action based on timer

            if (!isThirsty)
            {
                if (current_thirsty_time <= 0)
                {
                    queued_actions.Enqueue(PetState.Drinking);
                    current_thirsty_time = thirsty_timer;
                    isThirsty = true; 
                }
                else
                {
                    current_thirsty_time -= Time.deltaTime;
                }
            }

            // Queues Hunger action based on Timer
            if (!isHungry)
            {
                if (current_hungry_time <= 0)
                {
                    queued_actions.Enqueue(PetState.Eating);
                    current_hungry_time = hungry_timer;
                    isHungry = true;
                }
                else
                {
                    current_hungry_time -= Time.deltaTime;
                }
            }
        }
        switch (state) {
            case PetState.Idle:
                Debug.Log("Pet is idle");
                if(queued_actions.Count > 0)
                {
                    state = queued_actions.Dequeue(); 
                }
                break; 
            case PetState.Drinking:
                Debug.Log("Pet is drinking sum slime");
                anim.SetBool("Thirsty", true);
                // TODO: Decrement total slime inside of feeding tube
                // If no slime inside of tube, increment pet thirst by 1
                if (current_drinking_time <= 0)
                {
                    current_drinking_time = drinking_timer;
                    anim.SetBool("Thirsty", false);
                    state = PetState.Idle;
                    isThirsty = false;
                }
                else
                {
                    current_drinking_time -= Time.deltaTime;
                }

                break;
            case PetState.Eating:
                anim.SetBool("Hungry", true);
                Debug.Log("Pet is eatin sum toes");
                // TODO: Decrement total toes inside of feeding bowl
                // If no toes inside of bowl, increment pet hunger by 1
                if (current_eating_time <= 0)
                {
                    anim.SetBool("Hungry", false);
                    current_eating_time = eating_timer;
                    state = PetState.Idle;
                    isHungry = false;
                }
                else
                {
                    current_eating_time -= Time.deltaTime;
                }

                break;
            

        }

        ManageSatisfaction(); 
    }

    public void IncreaseCurrentToes(int amount_to_add)
    {
        current_toes += amount_to_add; 
        if(current_toes >= max_toes)
        {
            current_toes = max_toes;
        }
    }

    public void IncreaseCurrentSlime(int amount_to_add)
    {
        current_slime += amount_to_add;
        if(current_slime >= max_slime)
        {
            current_slime = max_slime; 
        }
    }

    public void MakeDance()
    {
        //TODO: Play Animation that makes pet dance 
        //TODO: Make Drums button that call MakeDance()
    }

    private void ManageSatisfaction()
    {
        
    }

    public enum PetState
    {
        Eating, 
        Drinking,
        Idle
    }
    
}
