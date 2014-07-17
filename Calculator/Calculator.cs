﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator
    {
        public Calculator(double firstOperand, double secondOperand, Operation operation, int accuracy)
        {
            FirstOperand = firstOperand;
            SecondOperand = secondOperand;
            TypeOperation = operation;
            Accuracy = accuracy;
            Result = GetResult(FirstOperand, SecondOperand, TypeOperation);
        }

        public double FirstOperand { get; set; }
        public double SecondOperand { get; set; }
        public double Result { get; set; }
        public int Accuracy { get; set; }
        public Operation TypeOperation { get; set; }

        public override string ToString()
        {
            var operation = String.Empty;
            switch (TypeOperation)
            {
                case Operation.Addition:
                    operation = "+";
                    break;
                case Operation.Subtraction:
                    operation = "-";
                    break;
                case Operation.Multiplication:
                    operation = "*";
                    break;
                case Operation.Division:
                    operation = "/";
                    break;
                default:
                    break;
            }
            return String.Format("{0} {1} {2} = {3}{4}", FirstOperand, operation, SecondOperand, Math.Round(Result, Accuracy), Environment.NewLine);
        }

        public double GetResult(double firstOperand, double secondOperand, Operation operation)
        {
            var result = 0.0;
            switch (operation)
            {
                case Operation.Addition:
                    result = firstOperand + secondOperand;
                    break;
                case Operation.Subtraction:
                    result = firstOperand - secondOperand;
                    break;
                case Operation.Multiplication:
                    result = firstOperand * secondOperand;
                    break;
                case Operation.Division:
                    result = firstOperand / secondOperand;
                    break;
                default:
                    break;
            }
            return result;
        }
    }
} 
