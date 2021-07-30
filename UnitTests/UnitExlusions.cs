

namespace UnitTests
{
    using Application.Domain.DTOs;
    using Application.Domain.Enums;
    using Application.Domain.Exclusions;
    using Application.Domain.Exclusions.Interfaces;
    using Application.Factory;
    using Application.Services;
    using Application.Services.Interfaces;
    using Moq;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;
    public class UnitExlusions
    {
        [Fact]
        public void TestExclusionFactory()
        {
            //Arrange
            //Mock<IExclusionFactory> mock = 
            var exclusionFactory = new ExclusionFactory();
            ExclusionType type = ExclusionType.EExtension;

            List<string> exclusions = new List<string>(new string[] { "png", "txt", "pdf" });

            var filePath = "C:\fsdsd";

            var filePathTxt = "C:\fsdsd.txt";

            var filePathTPdf = "C:\fsdsd.pdf";

            //Act 
            var exclusionCreated = exclusionFactory.CreateExclusion(type, exclusions);


            //Assert
            Assert.True(exclusionCreated.GetType() ==  typeof(ExtensionExclusion));

            Assert.False(exclusionCreated.Exclude(filePath));

            Assert.True(exclusionCreated.Exclude(filePathTxt)); 
            Assert.True(exclusionCreated.Exclude(filePathTPdf));

        }
       

        [Fact]
        public void TestExclusionService()
        {
            string[] laodLines = { "luis.jpeg", "lemos.txt", "perez.png" };

            string[] laodLinesFiltered = { "luis.jpeg" };

            string pathSource = @"C:\Users\Perez\Pictures\WC";
            List<string> exclusionsValues = new List<string> { "png", "txt"};
            ExclusionType exclusionType = ExclusionType.EExtension;

            var exclusion = new Exclusion {
                ExclusionType = exclusionType,
                Exclusions = exclusionsValues
            };


            var extensionExclusions = new ExtensionExclusion(exclusionsValues);

            var inputUserCommands = new UserInputDTO {
                Source = pathSource,
                Exclusions = new List<Exclusion>() { exclusion }
            };

            //Arrange
            var exclusionFactoryMock = new Mock<IExclusionFactory>();
            var ExclusionControllerMock = new Mock<IExclusionController>();
            var readFilesService = new Mock<IReadFilesService>();

            var inputUserCommandsMock = new Mock<UserInputDTO>();

            exclusionFactoryMock.Setup(item => item.CreateExclusion(exclusionType, exclusionsValues)).Returns(extensionExclusions);

            readFilesService.Setup(item => item.GetFiles(pathSource)).Returns(laodLines);


            laodLines.Where(filePath => !extensionExclusions.Exclude(filePath)).ToList();


            ExclusionControllerMock.Setup(item => item.Process(It.IsAny<List<ExclusionBase>>(), laodLines)).Returns(laodLinesFiltered);


            //Act 
            var exclusionService = new ExclusionService(ExclusionControllerMock.Object, exclusionFactoryMock.Object, readFilesService.Object);


            exclusionService.RemoveExclusionsFromInput(inputUserCommands);
            //Assert


            Assert.NotNull(inputUserCommands.folderAndSubFilesToZip);

            Assert.True(inputUserCommands.folderAndSubFilesToZip.Length>0);

  

        }
    }
}
