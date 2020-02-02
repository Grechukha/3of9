public class SecondCurrencyCard : Card
{
    protected override int GetAwardAmount()
    {
        return _awardAmount * _player.Level;
    }

    protected override string GetAwardName()
    {
        return "Валюта 2";
    }

    public override void RewardPlayer()
    {
        _player.SecondCurrencyCount += GetAwardAmount();
    }
}
