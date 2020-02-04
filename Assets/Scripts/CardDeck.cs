using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeck : MonoBehaviour
{
    [SerializeField] private Player _player;

    private List<Card> _cards = new List<Card>();
    private System.Random _random = new System.Random();
    private int _sideInterval = 200;
    private int _topInterval = 180;
    private int _maxColumnsCount = 3;
    private int _shuffleNumber = 4;
    private int _shuffleNumberOriginal;
    private float _shuffleTime = 0.35f;
    private bool _isMovingCards = false;

    public event Action<Card> CardSelected;

    private void Start()
    {
        _shuffleNumberOriginal = _shuffleNumber;

        foreach (var card in gameObject.GetComponentsInChildren<Card>())
        {
            card.Init(_player);
            card.Selected += OnCardSelected;
            _cards.Add(card);
        }

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

        HideCards();

        foreach (var card in _cards)
        {
            int i = _random.Next(shuffledCards.Count + 1);

            if (i == shuffledCards.Count)
            {
                shuffledCards.Add(card);
            }
            else
            {
                shuffledCards.Add(shuffledCards[i]);
                shuffledCards[i] = card;
            }
        }

        _cards = shuffledCards;

        _isMovingCards = true;

        StartCoroutine(MoveCards());
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

    public void CollectCards()
    {
        foreach (var card in _cards)
        {
            card.TargetPosition = new Vector3(0, card.transform.position.y, 0);
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

    private IEnumerator MoveCards()
    {
        while (_shuffleNumber > 0)
        {
            if (_shuffleNumber % 2 == 0)
            {
                foreach (var card in _cards)
                {
                    var pointInCircle = UnityEngine.Random.insideUnitCircle * _topInterval;
                    card.TargetPosition = new Vector3(pointInCircle.x, card.transform.position.y, pointInCircle.y);
                }
            }
            else
            {
                CollectCards();
            }

            _shuffleNumber--;

            yield return new WaitForSeconds(_shuffleTime);
        }

        DealCards();

        yield return new WaitForSeconds(_shuffleTime);

        _shuffleNumber = _shuffleNumberOriginal;
        _isMovingCards = false;
    }


    private void OnCardSelected(Card card)
    {
        if (_isMovingCards != true)
        {
            CardSelected?.Invoke(card);
        }
    }
}
