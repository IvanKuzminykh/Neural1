using Neural1;

internal class Program
{
    private static void Main(string[] args)
    {
        Dictionary<List<int>, int> examples = new Dictionary<List<int>, int>();
        examples.Add(new List<int> { 0, 0 }, 1);
        examples.Add(new List<int> { 0, 1 }, 0);
        examples.Add(new List<int> { 1, 0 }, 1);
        examples.Add(new List<int> { 1, 1 }, 1);
        Perceptron perceptron = new Perceptron();
        int genCount = 0;
        int successCount = 0;
        do
        {
            successCount = 0;
            Console.WriteLine($"GENERATION #{genCount}");
            foreach (var example in examples)
            {
                int answer = perceptron.Solve(example.Key);
                Console.WriteLine($"f({example.Key[0]}, {example.Key[1]}) = {example.Value}, answer = {answer}");

                if (answer == example.Value)
                {
                    successCount++;
                }
                else
                {
                    int weightCount = perceptron.Weights.Count;
                    for (int i = 0; i < weightCount - 1; i++)
                    {
                        perceptron.Weights[i] += 0.1 * (example.Value - answer) * example.Key[i];
                    }
                    // для исправления берется постоянный вход смещения
                    perceptron.Weights[weightCount - 1] += 0.1 * (example.Value - answer) * perceptron.Weights[weightCount - 1];

                }
            }
            genCount++;
        } while (successCount < examples.Count);
        Console.WriteLine($"{genCount} generations passed");
        foreach(var example in examples)
        {
            Console.WriteLine($"f({example.Key[0]}, {example.Key[1]}) = {perceptron.Solve(example.Key)}");
        }
    }
}