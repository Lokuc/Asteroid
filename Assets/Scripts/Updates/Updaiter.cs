using System;

namespace Updates
{
    public interface Updaiter
    {
        float timer{ get; }
        bool active { get; }
        float time { get; }
        void activate();
    }
}