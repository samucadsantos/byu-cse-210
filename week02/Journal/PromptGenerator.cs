public class PromptGenerator
{
    private Random _random = new Random();
    private List<string> _prompts = new List<string>
    {
        "What are you grateful for today?",
        "Describe a challenge you faced recently.",
        "What is a goal you want to achieve this week?",
        "Reflect on a recent success.",
        "Write about a person who inspires you.",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?"
    };

    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}
