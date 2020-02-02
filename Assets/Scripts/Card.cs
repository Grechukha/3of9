using System;
using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] protected TextMeshPro _awardTypeText;
    [SerializeField] protected TextMeshPro _awardAmountText;
    [SerializeField] protected int _awardAmount;

    protected Player _player;

    public event Action<Card> CardSelected; 

    private void OnMouseDown()
    {
        CardSelected.Invoke(this);
    }

    public void Init(Player player)
    {
        _player = player;
        WriteCardParameters();
    }

    protected void WriteCardParameters()
    {
        _awardTypeText.text = GetAwardName();
        _awardAmountText.text = GetAwardAmount().ToString();
    }

    protected virtual int GetAwardAmount()
    {
        return _awardAmount;
    }

    protected virtual string GetAwardName()
    {
        return "Award Type";
    }

    public virtual void RewardPlayer()
    {
    }
}
