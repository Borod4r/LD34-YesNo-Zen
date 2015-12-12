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
        public int Result;

        public Question()
        {
            OperationType = (OperationType) Random.Range(0, Enum.GetNames(typeof (OperationType)).Length);

            switch (OperationType)
            {
                case OperationType.addition:
                    OperationString = "+";
                    FirstOperand = Random.Range(0, 100);
                    SecondOperand = Random.Range(0, 100);
                    Result = FirstOperand + SecondOperand;
                    break;
                case OperationType.subtraction:
                    OperationString = "-";
                    FirstOperand = Random.Range(0, 100);
                    SecondOperand = Random.Range(0, FirstOperand);
                    Result = FirstOperand - SecondOperand;
                    break;
                case OperationType.multiplication:
                    FirstOperand = Random.Range(0, 10);
                    SecondOperand = Random.Range(0, 10);
                    OperationString = "x";
                    Result = FirstOperand*SecondOperand;
                    break;
                case OperationType.division:
                    SecondOperand = Random.Range(1, 100);
                    FirstOperand = SecondOperand*Random.Range(0, 10);
                    OperationString = "/";
                    Result = FirstOperand/SecondOperand;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}