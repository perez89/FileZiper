

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
            List<string> exclusionsValues = new List<string> { "png", "txt"};
            ExclusionType exclusion = ExclusionType.EExtension;
            var extensionExclusion = new ExtensionExclusion(exclusionsValues);

            var inputUserCommands = new UserInputDTO {

            };

            //Arrange

            var exclusionFactoryMock = new Mock<IExclusionFactory>();
            var inputUserCommandsMock = new Mock<UserInputDTO>();

            //ExclusionType type, IList<string> exclusions
            //exclusionFactoryMock.Setup(item => item.CreateExclusion(It.IsAny<ExclusionType>(), It.IsAny<List<string>>())).Returns(extensionExclusion);

            exclusionFactoryMock.Setup(item => item.CreateExclusion(exclusion, exclusionsValues)).Returns(extensionExclusion);

            //Act 
            var exclusionService = new ExclusionService(exclusionHandler.Object, exclusionFactory.Object);

            exclusionService.RemoveExclusionsFromInput(inputUserCommands.Object);


            exclusionService.RemoveExclusionsFromInput(ISetup.)


            //Assert


            Assert.NotNull(inputUserCommands.Object.folderAndSubFilesToZip);

            Assert.True(inputUserCommands.Object.folderAndSubFilesToZip.Length>0);

            //Assert.False(exclusionCreated.Exclude(filePath));

            //Assert.True(exclusionCreated.Exclude(filePathTxt));
            //Assert.True(exclusionCreated.Exclude(filePathTPdf));

        }
    }
}
