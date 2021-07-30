namespace UnitTests
{
    using Application.Domain.DTOs;
    using Application.Domain.Enums;
    using Application.Domain.Exclusions;
    using Application.Domain.Exclusions.Interfaces;
    using Application.Domain.Outputs;
    using Application.Factory;
    using Application.Factory.Interfaces;
    using Application.Services;
    using Application.Services.Interfaces;
    using Moq;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;
    public class ParserTest
    {

        [Fact]
        public void ExclusionFactoryTest_Extension()
        {
            //Arrange
            var exclusionFactory = new Mock<IExclusionFactory>();

            var outputFactory = new Mock<IOutputFactory>();


            var userCommandsDTO = new UserCommandsDTO();

            var source = "c:\\perez";
            var output = "smtp";
            var destination = "lplperez@clix.pt";

            userCommandsDTO.Add(new KeyValuePair<string, string>("source", source));
            userCommandsDTO.Add(new KeyValuePair<string, string>("EFile", "benfica"));
            userCommandsDTO.Add(new KeyValuePair<string, string>("EFile", "sporting"));
            userCommandsDTO.Add(new KeyValuePair<string, string>("Name", "output_name"));
            userCommandsDTO.Add(new KeyValuePair<string, string>("output", "smtp"));
            userCommandsDTO.Add(new KeyValuePair<string, string>("destination", destination));

            var listValuesToExclude = new List<string> (){ "benfica", "sporting" };
            exclusionFactory.Setup(item => item.CreateExclusion("EFile", listValuesToExclude)).Returns(new Exclusion {ExclusionType = ExclusionType.EFile, Exclusions = listValuesToExclude });

            outputFactory.Setup(item => item.CreateOutputDestination(output, destination)).Returns(new OutputDestinationDTO { Destination =destination, Type = OutputType.SMTP });

            ////Act 
            var _userCommandToInputParser = new UserCommandToInputParser(exclusionFactory.Object, outputFactory.Object);

            var inputParsed = _userCommandToInputParser.Parse(userCommandsDTO);

            var exclusions = new List<Exclusion>();
            exclusions.Add(new Exclusion {
                ExclusionType = ExclusionType.EFile,
                Exclusions = new List<string>(){ "benfica", "sporting" }
            });

            //Assert
            Assert.Contains(inputParsed.Exclusions, x => exclusions.Any(y => x.ExclusionType == y.ExclusionType));

            Assert.Equal(source, inputParsed.Source);
            exclusionFactory.Verify(s => s.CreateExclusion(It.IsAny<string>(), It.IsAny<List<string>>()), Times.AtLeastOnce);

            outputFactory.Verify(s => s.CreateOutputDestination(It.IsAny<string>(), It.IsAny<string>()), Times.Once);


        }

    }
}
