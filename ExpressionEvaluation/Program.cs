using System;
using System.Collections.Generic;

namespace ExpressionEvaluation
{
    class Program
    {
        static void Main(string[] args)
        {
            EvaluateExpressions("e + 8 - a + 5 ", new[] { "e" }, new[] { 1 });
        }


        static string[] EvaluateExpressions(string expression, string[] evalvars, int[] evalints)
        {
            var result = new string[evalvars.Length];
            
            //PEMDAS
            expression = $" {expression} ";
            var replacedExpression = "";
          
            for (var i = 0; i < evalvars.Length; i++)
                replacedExpression = expression.Replace($" {evalvars[i]} ", $" {evalints[i]} ");
            
            var test = " (1 + 2) * 3 - 8 / 4 ";
            test = test.Replace(" ", "");

            while (test.IndexOf('(') != -1)
            {
                var pStack = new Stack<char>();
                int startIndex = 0;
                
                for (var i = 0; i < test.Length; i++)
                {
                    if (test[i] == '(')
                    {
                        pStack.Push(test[i]);
                        startIndex = i;
                    }
                    else if (test[i] == ')')
                    {
                        if (pStack.Count == 0)
                        {
                            
                        }
                            
                    }
                        
                }
            }
            
            
            char[] operators = { '*', '/', '+', '-' };

            foreach (var op in operators)
            {
                while (test.IndexOf(op) != -1)  test = Evaluate(test, op);
            }
            
            Console.WriteLine(test);
            
            return result;
        }

        static string Evaluate(string expression, char op)
        {
            var opertorIndex = expression.IndexOf(op);
            var expression1 = expression.Substring(opertorIndex - 1, 3);
            var result = 0.0;

            switch (op)
            {
                case '+':
                    result = int.Parse(expression1[0].ToString()) + int.Parse(expression1[2].ToString());
                    break;
                case '-':
                    result = int.Parse(expression1[0].ToString()) - int.Parse(expression1[2].ToString());
                    break;
                case '*':
                    result = int.Parse(expression1[0].ToString()) * int.Parse(expression1[2].ToString());
                    break;
                case  '/':
                    result = int.Parse(expression1[0].ToString()) / int.Parse(expression1[2].ToString());
                    break;
            }
            
            return expression.Replace(expression1, result.ToString());
        }
        

    }
}