namespace Mindfulness
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        { }

        // Overridden method to implement specific activity logic for Breathing
        protected override void ExecuteActivity()
        {
            DateTime endTime = DateTime.Now.AddSeconds(_duration);

            while (DateTime.Now < endTime)
            {
                Console.WriteLine();
                Console.Write("Breathe in...");
                ShowCountdownWithNumbers(4);

                Console.Write($"Now breathe out...");
                ShowCountdownWithNumbers(4);
            }
        }
    }
}
