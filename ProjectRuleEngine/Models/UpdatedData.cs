using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectRuleEngine.Models
{
    public class UpdatedData
    {
        public int Id { get; set; }

        public string Signal { get; set; }

        public string Value { get; set; }

        public string Value_type { get; set; }

        public DateTime IncomingTime { get; set; }
        public bool CorrectSignal { get; set; }

        public string ErrorMessage { get; set; }

        public UpdatedData(ReceivedData data)
        {
            this.Signal = data.Signal;
            this.Value = data.Value;
            this.Value_type = data.Value_type;
            this.IncomingTime = DateTime.Now;
        }

        public void Process(ReceivedData data)
        {
            dynamic val;
            switch (Value_type)
            {
                case "Integer":
                    val = Convert.ToDouble(Value);
                    if (val <= 240)
                    {
                        CorrectSignal = true;
                    }
                    else
                    {
                        ErrorMessage = "Value should not rise above 240";
                    }
                    break;

                case "String":
                    if (Value == "HIGH")
                    {
                        CorrectSignal = true;
                    }
                    else
                    {
                        ErrorMessage = "Value should not be LOW";
                    }
                    break;

                case "Datetime":
                    val = Convert.ToDateTime(Value);
                    if (val <= DateTime.Now)
                    {
                        CorrectSignal = true;
                    }
                    else
                    {
                        ErrorMessage = "Value should not be in future";
                    }
                    break;

                default:
                    CorrectSignal = false;
                    ErrorMessage = "BadData";
                    break;
            }
        }

    }
}