// ���� ��� �����, ������� ����� ������� � ���� ������ �� ������ �������, ����������� �������, ����� ���������
// �� � ������ "������������"
public delegate void ItemAction(Unit unit);
public class ActionData
{
    public ItemAction _action;

    public ActionData(ItemAction action)
    {
        this._action = action;
    }
}
