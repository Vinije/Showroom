namespace Showroom.Presentation.UserInterface
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.JSInterop;

    public class JsProgressUpdater : IProgressUpdater
    {
        private const string UpdateMethodName = "UpdateProgress";

        private readonly IJSRuntime _jsRuntime;

        public JsProgressUpdater(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public bool IsFinished { get; set; } = false;

        public event EventHandler Finished;

        public async Task UpdateProgress(int value)
        {
            try
            {
                await _jsRuntime.InvokeVoidAsync(UpdateMethodName, value);
            }
            catch (JSException e)
            {
                throw new JSException(e.Message);
            }
        }

        public void OnFinished()
        {
            IsFinished = true;
            Finished?.Invoke(this, EventArgs.Empty);
        }
    }
}