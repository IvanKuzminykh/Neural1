namespace Neural1
{
    internal class Perceptron
    {
        public Perceptron() 
        {
            this.Weights = new List<double>();
            Random random = new Random();
            // 2 веса под входы, один под смещение
            for(int i = 0; i < 3; i++)
            {
                this.Weights.Add(random.NextDouble());
            }
        }
        public List<double> Weights { get; set; }
        public int Solve(List<int> x)
        {
            // Во входной вектор добавляется постоянный элемент для веса смещения
            x.Add(1);
            double sum = 0;
            for (int i = 0; i < x.Count; ++i)
            {
                sum += x[i] * Weights[i];
            }
            // Удаляется постоянный элемент
            x.RemoveAt(2);
            return ActivationFunction(sum);
        }
        int ActivationFunction(double x)
        {
            if (x >= 0.5) return 1;
            else return 0;
        }
    }
}
