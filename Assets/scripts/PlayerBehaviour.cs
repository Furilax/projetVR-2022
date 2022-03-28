using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    private float thirst, hunger;

    [SerializeField]
    private Image thirstBar, hungerBar;

    [SerializeField]
    private float maxThirst = 100, maxHunger = 100;


    [SerializeField]
    private float thirstDecreaseSpeed = 1, hungerDecreaseSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        hunger = maxHunger;
        thirst = maxThirst;
    }

    void Update()
    {
        thirst -= Time.deltaTime * thirstDecreaseSpeed;
        hunger -= Time.deltaTime * hungerDecreaseSpeed;
        hungerBar.rectTransform.localScale = new Vector3(hunger / maxHunger, 1, 1);
        thirstBar.rectTransform.localScale = new Vector3(thirst / maxThirst, 1, 1);

        hunger = Mathf.Clamp(hunger, 0, maxHunger);
        thirst = Mathf.Clamp(thirst, 0, maxThirst);

        if(hunger<=0 || thirst <= 0)
        {
            //Deathhhhhhhhhh
            //isAlive = false
        }
    }

    public void eat(int food, int drink)
    {
        hunger += food;
        thirst += drink;
    }
}
