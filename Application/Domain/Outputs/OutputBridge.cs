
namespace Application.Domain.Outputs
{
    public class OutputBridge : IOutputBridgeBase
    { 

        public OutputBridge(IZipper zipper, IOutput output): base(zipper, output)
        {
          
        }
    

        public override string ExecuteOutput()
        {
            return this.Output.Execute(Zipper.Zipsaas());
        }
    }
}
