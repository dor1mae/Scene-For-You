public interface IActionPoint : IAction, IPoint
{
    // ������ ��� �������� ���
    public void OnNpcAction();
    public bool CanItAction(Player pl, float cost);
}
