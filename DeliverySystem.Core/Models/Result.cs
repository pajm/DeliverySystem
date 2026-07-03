namespace DeliverySystem.Core.Models
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        private T _Value { get; set; }
        private string _Error { get; set; }
        public T Value
        {
            get
            {
                if (!IsSuccess) throw new InvalidOperationException();
                return _Value;
            }
        }
        public string Error
        {
            get
            {
                if (IsSuccess) throw new InvalidOperationException();
                return _Error;
            }
        }

        public static Result<T> Ok(T Value)
        {
            return new Result<T> { _Value = Value, IsSuccess = true };
        }

        public static Result<T> Fail(string error)
        {
            return new Result<T> { _Error = error, IsSuccess = false };
        }
    }
}
