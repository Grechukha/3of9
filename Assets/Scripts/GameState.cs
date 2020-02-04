using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private CardDeck _cardDeck;
    [SerializeField] private int _costFourthOpening = 1;
    [SerializeField] private int _costFifthOpening = 3;

    private int _maxFreeOpeningsNumber = 3;
    private int _openingsNumber = 0;
    private States _gameState;

    private void OnEnable()
    {
        _cardDeck.CardSelected += OnCardSelected;
    }

    private void OnDisable()
    {
        _cardDeck.CardSelected -= OnCardSelected;
    }

    private void Start()
    {
        _gameState = States.ShowingCards;
    }

    private void OnCardSelected(Card card)
    {
        if (_gameState == States.ShowingCards)
        {
            _gameState = States.ShufflingCards;

            _cardDeck.ShowCards();
            _cardDeck.DealCards();

            SetRandomPlayerLevel();
        }
        else if (_gameState == States.ShufflingCards)
        {
            _gameState = States.SelectionCards;

            _cardDeck.ShuffleCards();
        }
        else if (_gameState == States.SelectionCards)
        {
            TryOpenCard(card);
        }
        else if (_gameState == States.CollectedCards)
        {
            _cardDeck.HideCards();
            _cardDeck.CollectCards();

            _gameState = States.ShowingCards;
        }
    }

    private void TryOpenCard(Card card)
    {
        if (card.IsOpen != true)
        {
            if (_openingsNumber < _maxFreeOpeningsNumber)
            {
                OpenCard(card);
            }
            else if (_openingsNumber == _maxFreeOpeningsNumber)
            {
                if (TryGetPaid(_costFourthOpening))
                {
                    OpenCard(card);
                }
            }
            else if (_openingsNumber == _maxFreeOpeningsNumber + 1)
            {
                if (TryGetPaid(_costFifthOpening))
                {
                    OpenCard(card);
                }
            }
        }

        if (_openingsNumber >= _maxFreeOpeningsNumber + 2)
        {
            _openingsNumber = 0;

            _gameState = States.CollectedCards;
        }
    }

    private void OpenCard(Card card)
    {
        card.Show();
        card.RewardPlayer();
        _openingsNumber++;
    }

    private bool TryGetPaid(int cost)
    {
        if (_player.FirstCurrencyCount >= cost)
        {
            _player.FirstCurrencyCount -= cost;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SetRandomPlayerLevel()
    {
        _player.Level = new System.Random().Next(1, 10);
    }

    private enum States
    {
        ShowingCards,
        ShufflingCards,
        SelectionCards,
        CollectedCards
    }
}
