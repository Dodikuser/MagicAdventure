
public class WoodCounter : CoinCounter
{
    private void OnEnable()
    {
        _player.WoodChange += UpdateCounter;
    }

    private void OnDisable()
    {
        _player.WoodChange -= UpdateCounter;
    }
}
