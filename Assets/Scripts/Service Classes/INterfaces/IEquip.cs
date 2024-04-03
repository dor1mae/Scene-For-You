/// <summary>
/// ��������� ���� �������, ������� ��������� ���� ��� ����� ������� ���������� ���������
/// </summary>
public interface IEquip<T>
{
    public void Equip(T item);
    public void TakeOff(T item);
}
