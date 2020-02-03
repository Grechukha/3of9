using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _level;

    private int _firstCurrencyCount = 250;
    private int _secondCurrency;

    public int SecondCurrencyCount { get; set; }
    public int FirstMaterialCount { get; set; }
    public int SecondMaterialCount { get; set; }
    public int ThirdMaterialCount { get; set; }
    public int FirstSpellCount { get; set; }
    public int SecondSpellCount { get; set; }
    public int ThirdSpellCount { get; set; }

    public int Level
    {
        get
        {
            return _level;
        }
    } 
}
