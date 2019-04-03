using MordorsCruelPlan.Moods;

namespace MordorsCruelPlan.Factories
{
    static class MoodFactory
    {
        public static Mood CreateMood(int happiness)
        {
            if (happiness < -5)
            {
                return new Angry(happiness);
            }

            if (happiness <= 0)
            {
                return new Sad(happiness);
            }

            if (happiness <= 15)
            {
                return new Happy(happiness);
            }

            return new JavaScript(happiness);
        }
    }
}
