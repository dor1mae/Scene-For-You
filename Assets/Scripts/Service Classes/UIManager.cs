using UnityEditor;

public static class UIManager
{
    private static bool _isBusy = false;
    private static bool _canPlayerMove = true;

    public static bool CanPlayerMove => _canPlayerMove;

    public static bool IsBusy()
    {
        return _isBusy;
    }

    public static void SetBusy(bool value)
    {
        _isBusy = value;
    }

    public static void SetCanPlayerMove(bool value)
    {
        _canPlayerMove=value;
    }
}
