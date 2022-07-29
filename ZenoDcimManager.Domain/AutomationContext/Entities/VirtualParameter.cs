using System;
using System.Collections.Generic;
using ZenoDcimManager.Domain.ZenoContext.Entities;

namespace ZenoDcimManager.Domain.AutomationContext.Entities
{
    public class VirtualParameter : Parameter
    {
        public string Expression { get; set; }
        public Dictionary<string, double> Variables { get; private set; } = new Dictionary<string, double>();

        public double CalculateResult()
        {
            if (string.IsNullOrWhiteSpace(this.Expression))
                throw new Exception("An expression must be defined in the Expression property.");

            double? result = null;
            string operation = string.Empty;

            //This will be necessary for priorities operations such as parentheses, etc... It is not being used at this point.
            List<double> aux = new List<double>();

            foreach (var lexema in Expression.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries))
            {
                //If it is an operator
                if (lexema == "*" || lexema == "/" || lexema == "+" || lexema == "-" || lexema == "&&" || lexema == "||")
                {
                    operation = lexema;
                }
                else //It is a number or a variable
                {
                    double value = double.MinValue;
                    if (Variables.ContainsKey(lexema.ToLower())) //If it is a variable, let's get the variable value
                        value = Variables[lexema.ToLower()];
                    else //It is just a number, let's just parse
                        value = double.Parse(lexema);

                    if (!result.HasValue) //No value has been assigned yet
                    {
                        result = value;
                    }
                    else
                    {
                        switch (operation) //Let's check the operation we should perform
                        {
                            case "*":
                                result = result.Value * value;
                                break;
                            case "/":
                                result = result.Value / value;
                                break;
                            case "+":
                                result = result.Value + value;
                                break;
                            case "-":
                                result = result.Value - value;
                                break;
                            // case "^":
                            //     result = result.Value;
                            //     break;
                            // case "&&":
                            //     result = result.Value && value;
                            //     break;
                            // case "||":
                            //     result = result.Value || value;
                            //     break;
                            default:
                                throw new Exception("The expression is not properly formatted.");
                        }
                    }
                }
            }

            if (result.HasValue)
                return result.Value;
            else
                throw new Exception("The operation could not be completed, a result was not obtained.");
        }
        public void AddVariable(string variableDeclaration)
        {
            if (!string.IsNullOrWhiteSpace(variableDeclaration))
            {
                var variable = variableDeclaration.ToLower().Split('=');    //Let's make sure the variable's name is LOWER case and then get its name/value
                string variableName = variable[0];
                double variableValue = 0;

                if (double.TryParse(variable[1], out variableValue))
                    this.Variables.Add(variableName, variableValue);
                else
                    throw new Exception("Variable value is not a number");
            }
            else
            {
                //Could throw an exception... or just ignore as it not important...
            }
        }
    }
}