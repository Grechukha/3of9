using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSpellCard : Card
{
    protected override int GetAwardAmount()
    {
        return _awardAmount;
    }

    protected override string GetAwardName()
    {
        return "Заклинание 1";
    }

    public override void RewardPlayer()
    {
        _player.FirstSpellCount += GetAwardAmount();
    }
}
