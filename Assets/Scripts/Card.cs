using System;
using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] protected TextMeshPro _awardTypeText;
    [SerializeField] protected TextMeshPro _awardAmountText;
    [SerializeField] protected int _awardAmount;
    [SerializeField] private float _speed = 300;

    protected Player _player;

    public event Action<Card> Selected; 

    public Vector3 TargetPosition { get; set; }
    public bool IsOpen { get; private set; }

    private void Update()
    {
        if (TargetPosition != transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetPosition, _speed * Time.deltaTime);
        }
    }

    private void OnMouseDown()
    {
        Selected.Invoke(this);
    }

    private void OnDisable()
    {
        _player.LevelChanged -= OnLevelChanged;
    }

    public void Init(Player player)
    {
        _player = player;
        _player.LevelChanged += OnLevelChanged;

        WriteCardParameters();
    }

    public void Show()
    {
        transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
        IsOpen = true;
    }
  
    public void Hide()
    {
        transform.localRotation = new Quaternion(0f, 180f, 0f, 0f);
        IsOpen = false;
    }

    public virtual void RewardPlayer()
    {
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

    private void OnLevelChanged()
    {
        _awardAmountText.text = GetAwardAmount().ToString();
    }
}
