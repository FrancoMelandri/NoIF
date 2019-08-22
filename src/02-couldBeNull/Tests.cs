using NUnit.Framework;
using CouldBeNull;

namespace Tests
{
    public class CouldBeNullTests
    {
        private CouldBeNull.CouldBeNull sut;

        [SetUp]
        public void Setup()
        {
            sut = new CouldBeNull.CouldBeNull();
        }

        [Test]
        public void ShouldCheckNullIfException()
        {
            const string id = "ivalidId";
            var response = sut.getResponse(id);
            if (response != null)
                Assert.IsTrue(false);
            else
                Assert.IsTrue(true);
        }
    
        [Test]
        public void ShouldGetValueIFNoexception()
        {
            const string id = "123";
            var response = sut.getResponse(id);
            if (response != null)
                Assert.IsTrue(true);
            else
                Assert.IsTrue(false);
        }

        [Test]
        public void AsMain() 
        {
            var response = sut.getResponse("1212");
            if (response != null)
                System.Console.WriteLine (response.message);
            else
                System.Console.WriteLine ("No Id !!!!");

            response = sut.getResponse("ASC");
            if (response != null)
                System.Console.WriteLine (response.message);
            else
                System.Console.WriteLine ("No Id !!!!");

            Assert.IsTrue(true);
        }
    }

    public class CallbackNoIfTests
    {
        private CouldBeNull.Callback sut;

        [SetUp]
        public void Setup()
        {
            sut = new CouldBeNull.Callback();
        }

        [Test]
        public void ShouldgetWrongReponse()
        {
            const string id = "invalidId";
            sut.getResponse(id, 
                            (response) => Assert.Fail(),
                            (response) => Assert.IsTrue(true)) ;
        }
    
        [Test]
        public void ShouldgetRightReponse()
        {
            const string id = "123";
            sut.getResponse(id, 
                            (response) => Assert.IsTrue(true),
                            (response) => Assert.Fail()) ;
        }

        [Test]
        public void AsMain() {

            sut.getResponse("invalidId",
                            (res) => System.Console.WriteLine (res.message),
                            (res) => System.Console.WriteLine ("No Id !!!!"));
                            
            sut.getResponse("123",
                            (res) => System.Console.WriteLine (res.message),
                            (res) => System.Console.WriteLine ("No Id !!!!"));

            Assert.IsTrue(true);
        }
    }

    public class MaybeNoIfTests
    {
        private CouldBeNull.MaybeClass sut;

        [SetUp]
        public void Setup()
        {
            sut = new CouldBeNull.MaybeClass();
        }

        [Test]
        public void ShouldgetWrongReponse()
        {
            const string id = "invalidId";
            Assert.IsTrue (sut.getResponse(id)
                            .Match<bool>((response) => false,
                                         () => true)) ;
        }
    
        [Test]
        public void ShouldgetRightReponse()
        {
            const string id = "123";
            Assert.IsTrue (sut.getResponse(id)
                            .Match<bool>((response) => true,
                                         () => false)) ;
        }

        [Test]
        public void ShouldgetWrongReponseEither()
        {
            const string id = "invalidId";
            Assert.IsTrue (sut.getResponseEither(id)
                            .Match<bool>(_ => false,
                                         _ => true)) ;
        }
    
        [Test]
        public void ShouldgetRightReponseEither()
        {
            const string id = "123";
            Assert.IsTrue (sut.getResponseEither(id)
                            .Match<bool>(_ => true,
                                         _ => false)) ;
        }

        [Test]
        public void AsMain() {

            sut.getResponse("invalidId")
                .Match<bool>((res) => {
                                System.Console.WriteLine (res.message);
                                return true;
                             },               
                             () => {
                                 System.Console.WriteLine ("No Id !!!!");
                                 return false;
                             });
                            
            sut.getResponse("123")
                .Match<bool>((res) => {
                                System.Console.WriteLine (res.message);
                                return true;
                             },               
                             () => {
                                 System.Console.WriteLine ("No Id !!!!");
                                 return false;
                             });

            Assert.IsTrue(true);
        }
    }

    public class MaybeMonad
    {

        [Test]
        public void ShouldGetSome()
        {
            Maybe<Response> result = 
                    Maybe<Response>.Some(new Response { message = "hello"  } );
            Assert.IsTrue (result
                            .Match<bool>(_ => true,
                                         () => false)) ;
        }
  
        [Test]
        public void ShouldGetNone()
        {
            Maybe<Response> result = Maybe<Response>.None();
            Assert.IsTrue (result
                            .Match<bool>(_ => false,
                                         () => true)) ;
        }
    }

    public class EitherMonad
    {
        [Test]
        public void ShouldGetLeft()
        {
            Either<string, int> result = 
                    Either<string, int>.Left("error");
            Assert.IsTrue (result
                            .Match<bool>(_ => false,
                                         _ => true)) ;
        }

        [Test]
        public void ShouldGetRight()
        {
            Either<string, int> result = 
                    Either<string, int>.Right(42);
            Assert.IsTrue (result
                            .Match<bool>(_ => true,
                                         _ => false)) ;
        }

    }
}
