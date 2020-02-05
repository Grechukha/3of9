using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _level = 1;

    private int _firstCurrencyCount = 250;
    private int _secondCurrencyCount;
    private int _firstMaterialCount;
    private int _secondMaterialCount;
    private int _thirdMaterialCount;
    private int _firstSpellCount;
    private int _secondSpellCount;
    private int _thirdSpellCount;

    public event Action PropertiesChanged;
    public event Action LevelChanged;

    public int FirstCurrencyCount
    {
        get => _firstCurrencyCount;
        set
        {
            _firstCurrencyCount = value;
            PropertiesChanged.Invoke();
        }
    }
    public int SecondCurrencyCount
    {
        get => _secondCurrencyCount;
        set
        {
            _secondCurrencyCount = value;
            PropertiesChanged.Invoke();
        }
    }
    public int FirstMaterialCount
    {
        get => _firstMaterialCount;
        set
        {
            _firstMaterialCount = value;
            PropertiesChanged.Invoke();
        }
    }
    public int SecondMaterialCount
    {
        get => _secondMaterialCount;
        set
        {
            _secondMaterialCount = value;
            PropertiesChanged.Invoke();
        }
    }
    public int ThirdMaterialCount
    {
        get => _thirdMaterialCount;
        set
        {
            _thirdMaterialCount = value;
            PropertiesChanged.Invoke();
        }
    }
    public int FirstSpellCount
    {
        get => _firstSpellCount;
        set
        {
            _firstSpellCount = value;
            PropertiesChanged.Invoke();
        }
    }
    public int SecondSpellCount
    {
        get => _secondSpellCount;
        set
        {
            _secondSpellCount = value;
            PropertiesChanged.Invoke();
        }
    }
    public int ThirdSpellCount
    {
        get => _thirdSpellCount;
        set
        {
            _thirdSpellCount = value;
            PropertiesChanged.Invoke();
        }
    }

    public int Level
    {
        get => _level;
        set
        {
            _level = value;
            LevelChanged.Invoke();
        }
    }

    private void Start()
    {
        PropertiesChanged.Invoke();
        LevelChanged.Invoke();
    }
}
