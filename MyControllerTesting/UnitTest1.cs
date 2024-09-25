using System.Runtime.ExceptionServices;
using System.Xml.Linq;
using Microsoft.Identity.Client;
using Microsoft.VisualBasic;
using Moq;
using WeatherApi.Controllers;
using WeatherApi.Models;
using WeatherApi.Repo;
using Xunit.Abstractions;


namespace MyControllerTesting
{
    public class UnitTest1
    {

        private Mock<IRepo> _repoMock;
        private WeatherController _weatherController;
        private ITestOutputHelper _outputhelper; 
        public UnitTest1(ITestOutputHelper output)
        {
            _repoMock = new Mock<IRepo>();
            _weatherController = new WeatherController(_repoMock.Object);
            _outputhelper = output; 
        }

        [Fact]
       
        public void MockTesting_DeleteByGuid_method()
        {      
                var firstGuid = Guid.NewGuid();
                //how to return a task in unit testing 
                //  _repoMock.Setup(x => x.DeleteByGuid(Guid1)).Returns(Task.CompletedTask); 
                var result = _weatherController.DeleteByGuid(firstGuid);
                Assert.Equal(Task.CompletedTask, result);
            
      
        }

        [Fact]

        public void TestingForExceptions()
        {
         //   var exceptiontype = typeof(InvalidCastException);
         //   Assert.ThrowsAsync<InvalidCastException>(() => throw new InvalidCastException());
            var emptyGuid = Guid.Empty;
            _repoMock.Setup(x => x.DeleteByGuid(emptyGuid)).Throws(new Exception());
            var result = _weatherController.DeleteByGuid(emptyGuid);
            //_outputhelper.WriteLine("Sequnce contains new elements");
            // var exceptiontype = typeof(InvalidCastException);
            Assert.ThrowsAsync<Exception>(()=>result); 
        }

      //.ThrowsAsync(new InvalidOperationException());





        //refactor this code in the near future 
        [Fact]
        public async void MockTestingWatherController_PostMethod()
        {
            var InformationDTO = new InformationDTO();
            var Information = new WeatherApi.Models.Information(); 

            _repoMock.Setup(x=>x.Post(InformationDTO)).ReturnsAsync(Information);
            var result = await _weatherController.PostInformation(InformationDTO); 

            Assert.Equal(Information,result);
          
        }



        [Fact]
        public async void MockingTestingWeatherController_ReturnAllMethod()
        {

            List<InformationDTO> listinformationDTO = new List<InformationDTO>();
            listinformationDTO.Add(
                new InformationDTO
                {
                    Comments = "Food Truck",
                    Latitude = "44",
                    Longitude = "45",
                    DateTime = "8/31",
                    Guid = Guid.NewGuid()
                }
            );
            listinformationDTO.Add(
             new InformationDTO
             {
                 Comments = "Cookies and creme",
                 Latitude = "33",
                 Longitude = "99",
                 DateTime = "8/30",
                 Guid = Guid.NewGuid()
             }
           );

            _repoMock.Setup(x => x.GetAll()).ReturnsAsync(listinformationDTO);
            var controller = await _weatherController.ReturnAll();
            Assert.Equal(listinformationDTO, controller);
           
        }




    }
}