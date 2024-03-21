// Пока что класс, который будет вмещать в себя ссылку на функию объекта, выбраннного игроком, чтобы поместить
// ее в кнопку "Использовать"
public delegate void ItemAction(Unit unit);
public class ActionData
{
    public ItemAction _action;

    public ActionData(ItemAction action)
    {
        this._action = action;
    }
}
