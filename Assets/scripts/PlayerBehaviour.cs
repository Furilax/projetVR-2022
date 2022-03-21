using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private float hunger;
    [SerializeField]
    private float thirst;

    [SerializeField]
    private float thirstDecreaseSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        hunger = 100;
        thirst = 100;
    }

    // Update is called once per frame
    void Update()
    {
        thirst -= Time.deltaTime * thirstDecreaseSpeed;
    }
}
