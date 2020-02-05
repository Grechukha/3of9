using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondSpellCard : Card
{
    protected override int GetAwardAmount()
    {
        return _awardAmount;
    }

    protected override string GetAwardName()
    {
        return "Заклинание 2";
    }

    public override void RewardPlayer()
    {
        _player.SecondSpellCount += GetAwardAmount();
    }
}
