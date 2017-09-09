using Fiver.Lib.Functional.Types;
using System;

namespace Fiver.Lib.Functional.Extensions
{
    public static class ResultExtensions
    {
        public static Result<R, F> Map<S, F, R>
           (this Result<S, F> @this, Func<S, R> fn)
        =>
            @this.Match(
                s => Result<R, F>.Ok(fn(s)),
                f => Result<R, F>.Fail(f));

        public static Result<R, F> Bind<S, F, R>
           (this Result<S, F> @this, Func<S, Result<R, F>> fn)
        =>
            @this.Match(
                s => fn(s),
                f => Result<R, F>.Fail(f));

        public static Result<S, F> Do<S, F>(
            this Result<S, F> @this, Action<S> successFn)
        {
            if (@this.IsSuccess)
                successFn(@this.SuccessValue);
            return @this;
        }

        public static Result<S, F> Do<S, F>(
            this Result<S, F> @this, Action<S> successFn, Action<F> failureFn)
        {
            if (@this.IsSuccess)
                successFn(@this.SuccessValue);
            if (@this.IsFailure)
                failureFn(@this.FailureValue);
            return @this;
        }
    }
}
