public class ThirdSpellCard : Card
{
    protected override int GetAwardAmount()
    {
        return _awardAmount;
    }

    protected override string GetAwardName()
    {
        return "Заклинание 3";
    }

    public override void RewardPlayer()
    {
        _player.ThirdSpellCount += GetAwardAmount();
    }
}
