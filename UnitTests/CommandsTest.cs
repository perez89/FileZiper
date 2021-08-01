namespace UnitTests
{
    using Application.Domain.DTOs;
    using Interface.Services;
    using Moq;
    using System.Linq;
    using Xunit;
    public class CommandsTest
    {

        [Fact]
        public void ExclusionFactoryTest_Extension()
        {
            //Arrange
            //-source C:\Users\Perez\Pictures\WC -EExtension png txt -EFolder Sporting -output localfile -destination c:\xpto
            var inputArguments = @"-source C:\Users\Perez\Pictures\WC -EExtension png txt -EFolder Sporting -output localfile -destination c:\xpto";


            string[] inputArgumentsArray = inputArguments.Split(' ');

            var exclusionFactory = new Mock<UserArgumentsHandler>();

            //act
            var commandsList = exclusionFactory.Object.Extract(inputArgumentsArray);
            var userCommands = new UserCommandsDTO(commandsList);
            //assert

            Assert.Equal(@"C:\Users\Perez\Pictures\WC", userCommands.Get("source").FirstOrDefault().Value, ignoreCase: true);

            Assert.True(userCommands.Get("EExtension").Count() == 2);

            Assert.True(userCommands.Get("EFolder").Count() == 1);

            Assert.True(userCommands.Get("EFile").Count() == 0);


            Assert.DoesNotContain("pdf", userCommands.GetValues("EExtension"));

            Assert.Equal(@"localfile", userCommands.Get("output").FirstOrDefault().Value, ignoreCase: true);

            Assert.Equal(@"c:\xpto", userCommands.Get("destination").FirstOrDefault().Value, ignoreCase: true);


        }

    }
}
