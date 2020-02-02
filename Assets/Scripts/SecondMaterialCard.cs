using System;

public class SecondMaterialCard : Card
{
    private const float _divider = 2f;

    protected override int GetAwardAmount()
    {
        return _awardAmount * Convert.ToInt32(Math.Ceiling(_player.Level / _divider));
    }

    protected override string GetAwardName()
    {
        return "Материал 2";
    }

    public override void RewardPlayer()
    {
        _player.SecondMaterialCount += GetAwardAmount();
    }
}
