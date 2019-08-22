using System;

namespace CouldBeNull
{
    public struct Either<L, R>
    {
        private L _left;
        private R _right;

        public static Either<L, R> Right(R value) => 
            new Either<L, R> { _right = value };

        public static Either<L, R> Left(L value) => 
            new Either<L, R> { _left = value };

        public T Match<T>(Func<R, T> right, Func<L, T> left)
        {
           if (!Equals(_right, default(R))) return right(_right);
           else return left(_left);
        }
    }
}
