namespace Mindfulness 
{

    public class ListingActivity : Activity
    {
         private List<string> _prompts = new List<string>
        {
            "---Who are people that you appreciate?---",
            "---What are personal strengths of yours?---",
            "---Who are people you have helped this week?---",
            "---When have you felt the Holy Ghost this month?---",
            "---Who are your personal heroes?---"
        };

        public  ListingActivity() : base("Listing Activity", "In this activity, you will list things related to a specific theme. Think of as many items as you can during the activity."){ }

       
        protected override void ExecuteActivity()
        {
            DateTime endTime = DateTime.Now.AddSeconds(_duration);
            int count = 0;

            // Randomly select a prompt
            string prompt = _prompts[_random.Next(_prompts.Count)];

            Console.WriteLine("Please list as many things as you can think of related to the following prompt:");
            Console.WriteLine(prompt);
            Console.Write("You may begin in...");
            ShowCountdownWithNumbers(4);

            while (DateTime.Now < endTime)
            {
                Console.Write(">");
                string item = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(item))
                {
                    count++;
                }
            }

            Console.WriteLine($"You listed {count} items.");
        }
    }
}
