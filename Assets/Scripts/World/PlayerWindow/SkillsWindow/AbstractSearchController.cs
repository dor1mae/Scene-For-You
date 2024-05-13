public abstract class AbstractSearchController<Window, SearchTarget, Output>
{
    protected Window _window;
    protected SearchTarget _target;
    protected SkillsWindowPresenter window;

    public AbstractSearchController(Window window, SearchTarget target)
    {
        _window = window;
        _target = target;
    }

    protected AbstractSearchController(SkillsWindowPresenter window)
    {
        this.window = window;
    }

    public abstract Output SearchItems();
}
