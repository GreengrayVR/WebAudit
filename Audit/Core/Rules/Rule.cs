using Audit.Core.Rules.ErrorType;

namespace Audit.Core.Rules
{
    public class Rule : ICloneable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Error ErrorLevel { get; set; }

        public object Clone()
        {
            return new Rule() { Name = Name, Description = Description, ErrorLevel = ErrorLevel };
        }
    }
    //public class Rule<T, ErrorType> where ErrorType : IErrorType
    //{
    //    public Rule(T value)
    //    {
    //        Value = value;
    //        if (typeof(ErrorType) == typeof(Good))
    //            Error = Error.Information;
    //        else if (typeof(ErrorType) == typeof(Warning))
    //            Error = Error.Warning;
    //        else if (typeof(ErrorType) == typeof(Critical))
    //            Error = Error.Danger;
    //        else if (typeof(ErrorType) == typeof(None))
    //            Error = Error.None;
    //    }

    //    public T Value { get; set; }
    //    public Error Error { get; set; }
    //}
}
