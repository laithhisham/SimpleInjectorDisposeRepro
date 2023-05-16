namespace SimpleInjectorDisposeRepro
{
    public class TestDisposableAsyncClass : IAsyncDisposable
    {
        public bool Disposed { get; set; }

        public async ValueTask DisposeAsync()
        {
            Disposed = true;
            Console.WriteLine("TestDisposableAsyncClass - DisposeAsync called");

            await Task.CompletedTask;
        }

        public string TestMethod()
        {
            return "Test";
        }
    }
}
