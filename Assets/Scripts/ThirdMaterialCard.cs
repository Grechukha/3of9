public class ThirdMaterialCard : Card
{
    protected override int GetAwardAmount()
    {
        return _awardAmount;
    }

    protected override string GetAwardName()
    {
        return "Материал 3";
    }

    public override void RewardPlayer()
    {
        _player.ThirdMaterialCount += GetAwardAmount();
    }
}
