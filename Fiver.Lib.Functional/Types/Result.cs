using Fiver.Lib.Functional.Extensions;
using System;

namespace Fiver.Lib.Functional.Types
{
    public sealed class Result<S, F>
    {
        public S SuccessValue { get; }
        public F FailureValue { get; }

        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;

        private Result(S successValue)
        {
            IsSuccess = true;
            SuccessValue = successValue;
            FailureValue = default(F);
        }

        private Result(F failureValue)
        {
            IsSuccess = false;
            FailureValue = failureValue;
            SuccessValue = default(S);
        }

        public static Result<S, F> Ok(S successValue)
            => new Result<S, F>(successValue);

        public static Result<S, F> Fail(F failureValue)
            => new Result<S, F>(failureValue);

        public TR Match<TR>(Func<S, TR> successFn, Func<F, TR> failureFn)
           => IsSuccess ? successFn(this.SuccessValue) : failureFn(this.FailureValue);

        public Unit Match(Action<S> success, Action<F> failure)
           => Match(success.ToFunc(), failure.ToFunc());
    }
}
