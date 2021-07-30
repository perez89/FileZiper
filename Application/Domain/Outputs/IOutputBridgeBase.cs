

namespace Application.Domain.Outputs
{
    public abstract class IOutputBridgeBase
    {
        protected IZipper Zipper;
        protected IOutput Output;

        protected IOutputBridgeBase(IZipper zipper, IOutput output)
        {
            this.Zipper = zipper;
            this.Output = output;
        }

        public abstract string ExecuteOutput();
    }
}
