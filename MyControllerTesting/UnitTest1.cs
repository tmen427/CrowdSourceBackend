using System.Runtime.ExceptionServices;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using Moq;
using WeatherApi.Controllers;
using WeatherApi.Models;
using WeatherApi.Repo;

namespace MyControllerTesting
{
    public class UnitTest1
    {

        private Mock<IRepo> _repoMock;
        private WeatherController _weatherController;
        public UnitTest1()
        {
            _repoMock = new Mock<IRepo>();
            _weatherController = new WeatherController(_repoMock.Object);
        }


        [Fact]
        public async void MockTestingWeatherController_ReturnJustONename_method()
        {

            //arrange 
            var Information = new WeatherApi.Models.Information();
            Information.Comments = "joey";


            _repoMock.Setup(x => x.GetBySingleName("joey")).ReturnsAsync(Information);

            var result = await _weatherController.ReturnJustOneName("joey");
            //assert
            Assert.Equal(Information, result);
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