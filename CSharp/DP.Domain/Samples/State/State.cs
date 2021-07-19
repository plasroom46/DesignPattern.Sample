namespace DP.Domain.Samples.State
{
    public abstract class State
    {
        public abstract void Action(Context context);

        public abstract void ActionBack(Context context);
    }
}