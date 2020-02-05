using TMPro;
using UnityEngine;

public class PlayerPropertiesDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _firstCurrencyCountText;
    [SerializeField] private TextMeshProUGUI _secondCurrencyCountText;
    [SerializeField] private TextMeshProUGUI _firstMaterialCountText;
    [SerializeField] private TextMeshProUGUI _secondMaterialCountText;
    [SerializeField] private TextMeshProUGUI _thirdMaterialCountText;
    [SerializeField] private TextMeshProUGUI _firstSpellCountText;
    [SerializeField] private TextMeshProUGUI _secondSpellCountText;
    [SerializeField] private TextMeshProUGUI _thirdSpellCountText;
    [SerializeField] private TextMeshProUGUI _levelText;

    private void OnEnable()
    {
        _player.PropertiesChanged += OnPropertiesChanged;
        _player.LevelChanged += OnLevelChanged;
        OnPropertiesChanged();
    }

    private void OnDisable()
    {
        _player.PropertiesChanged -= OnPropertiesChanged;
        _player.LevelChanged -= OnLevelChanged;
    }

    private void OnPropertiesChanged()
    {
        _firstCurrencyCountText.text = _player.FirstCurrencyCount.ToString();
        _secondCurrencyCountText.text = _player.SecondCurrencyCount.ToString();
        _firstMaterialCountText.text = _player.FirstMaterialCount.ToString();
        _secondMaterialCountText.text = _player.SecondMaterialCount.ToString();
        _thirdMaterialCountText.text = _player.ThirdMaterialCount.ToString();
        _firstSpellCountText.text = _player.FirstSpellCount.ToString();
        _secondSpellCountText.text = _player.SecondSpellCount.ToString();
        _thirdSpellCountText.text = _player.ThirdSpellCount.ToString();
    }

    private void OnLevelChanged()
    {
        _levelText.text = _player.Level.ToString();
    }
}
