public static class UIManager
{
    private static bool _isBusy = false;

    public static bool IsBusy()
    {
        return _isBusy;
    }

    public static void SetBusy(bool value)
    {
        _isBusy = value;
    }
}
