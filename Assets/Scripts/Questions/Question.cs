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

        public Question()
        {
            OperationType = (OperationType) Random.Range(0, Enum.GetNames(typeof (OperationType)).Length);

            switch (OperationType)
            {
                case OperationType.Addition:
                    OperationString = "+";
                    FirstOperand = Random.Range(0, 100);
                    SecondOperand = Random.Range(0, 100);
                    // True result
                    TrueResult = FirstOperand + SecondOperand;
                    break;
                case OperationType.Subtraction:
                    OperationString = "-";
                    FirstOperand = Random.Range(0, 100);
                    SecondOperand = Random.Range(0, FirstOperand);
                    // True result
                    TrueResult = FirstOperand - SecondOperand;
                    break;
                case OperationType.Multiplication:
                    FirstOperand = Random.Range(0, 10);
                    SecondOperand = Random.Range(0, 10);
                    OperationString = "x";
                    // True result
                    TrueResult = FirstOperand*SecondOperand;
                    break;
                case OperationType.Division:
                    SecondOperand = Random.Range(1, 100);
                    FirstOperand = SecondOperand*Random.Range(0, 10);
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