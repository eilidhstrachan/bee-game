public class MainSystem : Feature
{
    public MainSystem(Contexts contexts)
    {
        Add( new TestSystem(contexts.game) );
    }
}