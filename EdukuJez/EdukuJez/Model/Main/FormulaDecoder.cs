using EdukuJez.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace EdukuJez.Model.Main
{
    public class FormulaDecoder
    {
        static int currentIndex = 0;

        static double ParseExpression(string expression)
        {
            currentIndex = 0;
            return ParseAdditionSubtraction(expression);
        }

        static double ParseAdditionSubtraction(string expression)
        {
            double leftValue = ParseMultiplicationDivision(expression);

            while (currentIndex < expression.Length)
            {
                char op = expression[currentIndex];

                if (op != '+' && op != '-')
                    break;

                currentIndex++;

                double rightValue = ParseMultiplicationDivision(expression);

                if (op == '+')
                    leftValue += rightValue;
                else
                    leftValue -= rightValue;
            }

            return leftValue;
        }

        static double ParseMultiplicationDivision(string expression)
        {
            double leftValue = ParsePrimary(expression);

            while (currentIndex < expression.Length)
            {
                char op = expression[currentIndex];

                if (op != '*' && op != '/')
                    break;

                currentIndex++;

                double rightValue = ParsePrimary(expression);

                if (op == '*')
                    leftValue *= rightValue;
                else
                {
                    if (rightValue != 0)
                        leftValue /= rightValue;
                    else
                        throw new DivideByZeroException("Division by zero is not allowed.");
                }
            }

            return leftValue;
        }

        static double ParsePrimary(string expression)
        {
            char currentChar = expression[currentIndex];

            if (char.IsDigit(currentChar) || currentChar == '.')
            {
                string number = "";
                while (currentIndex < expression.Length && (char.IsDigit(expression[currentIndex]) || expression[currentIndex] == '.'))
                {
                    number += expression[currentIndex];
                    currentIndex++;
                }

                return double.Parse(number);
            }
            else if (currentChar == '(')
            {
                currentIndex++;
                double result = ParseAdditionSubtraction(expression);
                if (currentIndex >= expression.Length || expression[currentIndex] != ')')
                    throw new ArgumentException("Mismatched parentheses.");
                currentIndex++;
                return result;
            }
            else if (currentChar == '-' && currentIndex + 1 < expression.Length && char.IsDigit(expression[currentIndex + 1]))
            {
                currentIndex++;
                return -ParsePrimary(expression);
            }
            else
                throw new ArgumentException("Invalid character in expression.");
        }
        static string ReplaceValues(string input, List<Grade> grades)
        {
            string result = Regex.Replace(input, @"\$(\d+)", match =>
            {
                if (int.TryParse(match.Groups[1].Value, out int index))
                {
                    return grades.First(x=>x.Activity.Id==index).GradeValue.ToString();
                }
                return match.Value;
            });

            return result;
        }
        public static double ParseForUser(string expression, User u)
        {
            expression = ReplaceValues(expression, u.Grades.ToList());
            return ParseExpression(expression);
        }
    }
}