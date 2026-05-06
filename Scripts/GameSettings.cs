namespace Pongo.Scripts;

public static class GameSettings
{
    private static bool _isMultiPlayer = false;

    public static void SetMultiPlayer()
    {
        _isMultiPlayer = !_isMultiPlayer;
    }

    public static bool isMultiPlayer()
    {
        return _isMultiPlayer;
    }
}