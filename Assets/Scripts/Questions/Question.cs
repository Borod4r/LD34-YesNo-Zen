using System;
using Random = UnityEngine.Random;

namespace Borodar.LD34.Questions
{
    public class Question
    {
        public int FirstOperand;
        public int SecondOperand;
        public OperationType OperationType;
        public string OperationString;
        public int TrueResult;
        public int FakeResult;

        public Question(int complexity)
        {
            OperationType = (OperationType) Random.Range(0, Enum.GetNames(typeof (OperationType)).Length);

            var complexityPow = (int) Math.Pow(10, complexity);

            switch (OperationType)
            {
                case OperationType.Addition:
                    OperationString = "+";
                    FirstOperand = Random.Range(1, 10 * complexityPow);
                    SecondOperand = Random.Range(1, 10 * complexityPow);
                    // True result
                    TrueResult = FirstOperand + SecondOperand;
                    break;
                case OperationType.Subtraction:
                    OperationString = "-";
                    
                    FirstOperand = Random.Range(1, 10 * complexityPow);
                    SecondOperand = Random.Range(1, FirstOperand);
                    // True result
                    TrueResult = FirstOperand - SecondOperand;
                    break;
                case OperationType.Multiplication:
                    FirstOperand = Random.Range(1, 10 * complexity);
                    SecondOperand = Random.Range(1, 10 * complexity);
                    OperationString = "x";
                    // True result
                    TrueResult = FirstOperand*SecondOperand;
                    break;
                case OperationType.Division:
                    SecondOperand = Random.Range(1, 10 * complexity);
                    FirstOperand = SecondOperand * Random.Range(1, 10 * complexity);
                    OperationString = "/";
                    // True result
                    TrueResult = FirstOperand/SecondOperand;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            // Fake result
            FakeResult = TrueResult + Random.Range(-TrueResult / 2, TrueResult / 2);
            if (FakeResult == TrueResult) FakeResult++;
        }

        public string GetTrueString()
        {
            return FirstOperand + " " + OperationString + " " + SecondOperand + " = " + TrueResult;
        }

        public string GetFakeString()
        {
            return FirstOperand + " " + OperationString + " " + SecondOperand + " = " + FakeResult;
        }

    }
}