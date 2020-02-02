public class FirstMaterialCard : Card
{
    protected override int GetAwardAmount()
    {
        return _awardAmount * _player.Level;
    }

    protected override string GetAwardName()
    {
        return "Материал 1";
    }

    public override void RewardPlayer()
    {
        _player.FirstMaterialCount += GetAwardAmount();
    }
}
