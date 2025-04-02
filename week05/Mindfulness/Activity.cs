namespace Mindfulness
{
     public abstract class Activity
    {
        private string _activityName;
        private string _description;
        protected int _duration;
        protected static Random _random = new Random();
        public string ActivityNameProp => _activityName;
        public Activity(string activityName, string description)
        {
            _activityName = activityName;
            _description = description;
        }

        // Method to start the activity process
        public void StartActivity()
        {
            Console.Clear();
            DisplayStartMessage();
            _duration = GetValidInput("Please enter the duration of the activity in seconds: ");
            PrepareToStart();
            ExecuteActivity();  // Calls the abstract method to be implemented by derived classes
            EndActivity();
        }

        // Display start message: Activity name and description
        private void DisplayStartMessage()
        {
            Console.WriteLine($"Welcome to the {_activityName}!\n");
            Console.WriteLine(_description);
            Console.WriteLine();
        }

        private static int GetValidInput(string prompt)
        {
            int value;
            Console.Write(prompt);
            while (!int.TryParse(Console.ReadLine(), out value) || value <= 0)
            {
                Console.Write("Invalid input. Please enter a positive number: ");
            }
            return value;
        }

        // Prepare the user for starting the activity (with a countdown)
        private void PrepareToStart()
        {
            Console.Clear();
            Console.WriteLine("Get ready...");
            ShowSpinner(5); // You can change this number to adjust spinner speed
        }

        // Show a countdown with a spinner animation (for activity preparation)
        protected void ShowSpinner(int iterations)
        {

            List<string> spinner = new List<string> { "|", "/", "-", "\\" };

            for (int i = 0; i < iterations; i++)
            {
                foreach (var item in spinner)
                {
                    Console.Write(item);
                    Thread.Sleep(500);
                    Console.Write("\b \b");
                }
            }
        }

        // Show countdown with numbers for user to prepare (e.g., waiting for activity to begin)
        protected void ShowCountdownWithNumbers(int seconds)
        {

            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000); // Wait 1 second
                Console.Write("\b \b"); // Backspace the character to overwrite
            }
            Console.Write("\n");
        }

        private void EndActivity()
        {

            Console.WriteLine("\nGreat job!! ");
            ShowSpinner(3); // Spinner effect after activity
            Console.WriteLine($"\nYou completed {_activityName} for {_duration} seconds.");
            ShowSpinner(3); // Another spinner effect
        }

        protected abstract void ExecuteActivity();
    }

    
}