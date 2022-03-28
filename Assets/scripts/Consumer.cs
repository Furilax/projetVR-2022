using UnityEngine;

public class Consumer : MonoBehaviour
{
    Collider _collider;
    VieJoueur player;
    void Start()
    {
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;
        player = GetComponentInParent<VieJoueur>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Consumable consumable = other.GetComponent<Consumable>();

        if (consumable != null)
        {
            player.eat(consumable.drinkIncrease, consumable.eatIncrease);
            consumable.Consume();
        }
    }
}
