using UnityEngine;

public class Consumer : MonoBehaviour
{
    Collider _collider;
    [SerializeField]
    VieJoueur player;
    void Start()
    {
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;
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
