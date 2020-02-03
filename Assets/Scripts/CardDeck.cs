using System;
using System.Collections.Generic;
using UnityEngine;

public class CardDeck : MonoBehaviour
{
    [SerializeField] private Player _player;

    private List<Card> _cards = new List<Card>();
    private float _sideInterval = 200;
    private float _topInterval = 180;
    private int _maxColumnsCount = 3;

    public event Action<Card> CardSelected;

    private void Start()
    {
        foreach (var card in gameObject.GetComponentsInChildren<Card>())
        {
            card.Init(_player);
            card.Selected += OnCardSelected;
            _cards.Add(card);
        }

        ShuffleCards();
        DealCards();
    }

    private void OnDisable()
    {
        foreach (var card in _cards)
        {
            card.Selected -= OnCardSelected;
        }
    }

    public void ShuffleCards()
    {
        var shuffledCards = new List<Card>();
        var random = new System.Random();

        foreach (var card in _cards)
        {
            int j = random.Next(shuffledCards.Count + 1);
            
            if (j == shuffledCards.Count)
            {
                shuffledCards.Add(card);
            }
            else
            {
                shuffledCards.Add(shuffledCards[j]);
                shuffledCards[j] = card;
            }
        }

        _cards = shuffledCards;
    }

    public void DealCards()
    {
        Vector3 newPosition = new Vector3(-_sideInterval, 0, _topInterval);
        int columnNumber = 0;

        foreach (var card in _cards)
        {            
            card.TargetPosition = newPosition;

            columnNumber++;

            if (columnNumber >= _maxColumnsCount)
            {
                newPosition.x = -_sideInterval;
                newPosition.z -= _topInterval;

                columnNumber = 0;
            }
            else
            {
                newPosition.x += _sideInterval;
            }
        }
    }
   
    public void ShowCards()
    {
        foreach (var card in _cards)
        {
            card.Show();
        }
    }

    public void HideCards()
    {
        foreach (var card in _cards)
        {
            card.Hide();
        }
    }

    private void OnCardSelected(Card card)
    {
        CardSelected?.Invoke(card);
    }
}
