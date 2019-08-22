using System;

namespace CouldBeNull
{
    public struct Maybe<T>
    {
        private bool hasValue;
        private T value;

        public static Maybe<T> Some(T value) 
        { 
            return new Maybe<T> {hasValue = true, value = value};
        }

        public static Maybe<T> None() 
        { 
            return new Maybe<T> {hasValue = false};
        }

        public R Match<R>(Func<T, R> some, Func<R> none)
        {
           return hasValue ? some(value) : none();
        }
    }

    public class MaybeResponse
    {
        private bool hasValue;
        private Response response;

        public static MaybeResponse Some(Response response) 
        { 
            return new MaybeResponse {hasValue = true, response = response};
        }

        public static MaybeResponse None() 
        { 
            return new MaybeResponse {hasValue = false};
        }

        public T Match<T>(Func<Response, T> some, Func<T> none)
        {
           return hasValue ? some(response) : none();
        }
    }

    public class MaybeClass    
    {
        public MaybeResponse getResponse(string id) 
        {
            try
            {
                return MaybeResponse.Some(new Response
                {
                    message = string.Format("Your id is {0}", Convert.ToInt32(id))
                });
            }
            catch (Exception)
            {
                return MaybeResponse.None();
            }
        }
    }
}