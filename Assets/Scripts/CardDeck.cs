using System;
using System.Collections.Generic;
using UnityEngine;

public class CardDeck : MonoBehaviour
{
    [SerializeField] private Player _player;

    private List<Card> _cards = new List<Card>();

    public event Action<Card> CardSelected;

    private void Start()
    {
        foreach (var card in gameObject.GetComponentsInChildren<Card>())
        {
            card.Init(_player);
            card.Selected += OnCardSelected;
            _cards.Add(card);
        }
    }

    private void OnDisable()
    {
        foreach (var card in _cards)
        {
            card.Selected -= OnCardSelected;
        }
    }

    private void OnCardSelected(Card card)
    {
        CardSelected?.Invoke(card);
    }
}
