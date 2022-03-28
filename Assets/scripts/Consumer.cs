using UnityEngine;

public class Consumer : MonoBehaviour
{
    Collider _collider;
    PlayerBehaviour player;
    void Start()
    {
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;
        player = GetComponentInParent<PlayerBehaviour>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Consumable consumable = other.GetComponent<Consumable>();

        if (consumable != null)
        {
            Debug.Log("Consu;ing food") ;
            player.eat(consumable.drinkIncrease, consumable.eatIncrease);
            consumable.Consume();
        }
    }
}
