

namespace UnitTests
{
    using Application.Domain.Enums;
    using Application.Domain.Exclusions;
    using Application.Domain.Outputs;
    using Application.Factory;
    using Moq;
    using System.Collections.Generic;
    using Xunit;
    public class FactoryTests
    {

        [Fact]
        public void ExclusionFactoryTest_Extension()
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
            Assert.True(exclusionCreated.GetType() == typeof(ExtensionExclusion));

            Assert.False(exclusionCreated.Exclude(filePath));

            Assert.True(exclusionCreated.Exclude(filePathTxt));
            Assert.True(exclusionCreated.Exclude(filePathTPdf));

        }

        [Fact]
        public void ExclusionFactoryTest_EFile()
        {
          

            var filePathAustralia = "C:\\australia.png";

            var filePathFranca = "C:\\paises\\franca.png";

            var filePathTRussia = "C:\\paises\\russia";

            var filePathPortugal = "C:\\Portugal.png";

            var filePathAustralia2 = "C:\\paises\\Australia.";

            var filePathTTailandia = "C:\\paises\\tailandia.png";

            var exclusionType = ExclusionType.EFile;

            var listExclusionValues = new List<string>() {"australia","espanha","portugal" };

            //Arrange
            var exclusionFactoryMock = new Mock<ExclusionFactory>();     

            //Act 
            var createExclusion = exclusionFactoryMock.Object.CreateExclusion(exclusionType, listExclusionValues);

            //Assert
            Assert.True(createExclusion.GetType() == typeof(FileExclusion));

            Assert.True(createExclusion.Exclude(filePathAustralia));
            Assert.False(createExclusion.Exclude(filePathFranca));
            Assert.False(createExclusion.Exclude(filePathTRussia));
            Assert.True(createExclusion.Exclude(filePathPortugal));
            Assert.True(createExclusion.Exclude(filePathAustralia2));
            Assert.False(createExclusion.Exclude(filePathTTailandia));

        }




        [Fact]
        public void OutputFromArgumentFactoryTest_LocalFile()
        {
            //Arrange
            //Mock<IExclusionFactory> mock = 
            var outputFactory = new OutputFactory();
            var outTypeEnum = OutputType.FileShare;
            var destination = "c:\\xpto";
            var fileName = "";

            //Act 
            var outPutCreated = outputFactory.CreateOutputFromArguments(outTypeEnum, destination, fileName);


            //Assert
            Assert.True(outPutCreated.GetType() == typeof(FileShareOutput));

            Assert.True(outPutCreated.IsDestinationValid());



        }

        [Fact]
        public void OutputFromArgumentFactoryTest_SMTP()
        {
            //Arrange
            //Mock<IExclusionFactory> mock = 
            var outputFactory = new OutputFactory();
            var outTypeEnum = OutputType.SMTP;
            var destination1 = "lplpl@zerep.com";
            var fileName = "Benfica";

            //Act 
            var outPutCreated = outputFactory.CreateOutputFromArguments(outTypeEnum, destination1, fileName);


            //Assert
            Assert.True(outPutCreated.GetType() == typeof(SmtpOutput));

            Assert.True(outPutCreated.IsDestinationValid());

        }

        [Fact]
        public void OutputFromArgumentFactoryTest_SMTP_Wrong_email()
        {
            //Arrange
            //Mock<IExclusionFactory> mock = 
            var outputFactory = new OutputFactory();
            var outTypeEnum = OutputType.SMTP;
            var destination = "c:\\xpto";
            var fileName = "Benfica";

            //Act 
            var outPutCreated = outputFactory.CreateOutputFromArguments(outTypeEnum, destination, fileName);


            //Assert
            Assert.True(outPutCreated.GetType() == typeof(SmtpOutput));

            Assert.False(outPutCreated.IsDestinationValid());

        }
      
    }
}
