
namespace Application.Domain
{
    using Application.Domain.DTOs;
    using Application.Domain.Enums;
    using Application.Domain.Exclusions;
    using Application.Domain.Outputs;
    using Application.Factory.Interfaces;
    using System.Collections.Generic;

    public class OutputBuilder : IOutputBuilder
    {
        IOutputFactory OutputFactory { get; set; } 
        IZipper _zipper { get; set; }

        IOutput _output;

        public string Source { get; set; }
        public string Name { private get; set; }

        public string fileName;
        public IList<Exclusion> Exclusions { get; set; }
        public OutputType Output_Type { get; set; }
        public string Destination { get; set; }

        private IOutputBridgeBase Output_Bridge;
        public string[] folderAndSubFilesToZip { get; set; }


        public OutputBuilder(IOutputFactory outputFactory, IZipper zipper)
        {
            OutputFactory = outputFactory;
            _zipper = zipper;
        }

        public IOutputBuilder Build()
        {
            CreateZip();
            CreateOutput();
            this.Output_Bridge=new OutputBridge(_zipper, _output);
  
            return this;
        }

        public IOutputBuilder CreateOutputBuilder(UserInputDTO argumentsDTO)
        {
            Destination = argumentsDTO.OutputDestination.Destination;
            Output_Type = argumentsDTO.OutputDestination.Type;
            fileName = argumentsDTO.gGetFileName();
            folderAndSubFilesToZip = argumentsDTO.folderAndSubFilesToZip;
            Source = argumentsDTO.Source;
            return this;
        }

        public IOutputBridgeBase Get()
        {
            return this.Output_Bridge;
        }

        private void CreateOutput()
        {
            this._output = this.OutputFactory.CreateOutputFromArguments(Output_Type, Destination, fileName);
        }

        private void CreateZip()
        {
            this._zipper =  this._zipper.Configure(folderAndSubFilesToZip, Source);
        }
    }
}
