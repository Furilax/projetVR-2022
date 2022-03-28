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

    // Update is called once per frame
    void Update()
    {
        thirst -= Time.deltaTime * thirstDecreaseSpeed;
        hunger -= Time.deltaTime * hungerDecreaseSpeed;
        Debug.Log("hunger: "+hunger);
        hungerBar.rectTransform.localScale = new Vector3(hunger / maxHunger, 1, 1);
        thirstBar.rectTransform.localScale = new Vector3(thirst / maxThirst, 1, 1);
    }

    public void eat(int food, int drink)
    {
        hunger += food;
        hunger = Mathf.Clamp(hunger, 0, maxHunger);
        thirst += drink;
        thirst = Mathf.Clamp(thirst, 0, maxThirst);
    }
}
