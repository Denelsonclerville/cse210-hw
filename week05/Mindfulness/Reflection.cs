namespace Mindfulness
{
    public class ReflectionActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "---Think of a time when you stood up for someone else.---",
            "---Think of a time when you did something really difficult.---",
            "---Think of a time when you helped someone in need.---",
            "---Think of a time when you did something truly selfless.---"
        };

        private List<string> _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        public ReflectionActivity() 
            : base("Reflection Activity", 
                   "This activity will help you reflect on times in your life when you have shown strength and resilience.\n" +
                   "This will help you recognize the power you have and how you can use it in other aspects of your life."){ }

    
        protected override void ExecuteActivity()
        {
            DateTime endTime = DateTime.Now.AddSeconds(_duration);

            Console.WriteLine("Consider the following prompt: ");
            string prompt = _prompts[_random.Next(_prompts.Count)];
            Console.WriteLine(prompt);

            // Wait for user to press Enter to begin
            Console.WriteLine("\nPress Enter when you're ready to begin...");
            Console.ReadLine();
            Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
            Console.Write("You may begin in...");
            ShowCountdownWithNumbers(4);
            Console.Clear();

            
            while (DateTime.Now < endTime)
            {
                string question = _questions[_random.Next(_questions.Count)];
                Console.Write($"> {question} \n");
                ShowSpinner(3); 
            }
        }
    }

}