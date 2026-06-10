namespace Pongo.Scripts;

public static class GameSettings
{
    private static bool _isMultiPlayer = false;

    public static void SetMultiPlayer(bool isMultiPlayer)
    {
        _isMultiPlayer = isMultiPlayer;
    }

    public static bool isMultiPlayer()
    {
        return _isMultiPlayer;
    }
}