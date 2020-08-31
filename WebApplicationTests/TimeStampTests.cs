using System;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using WebApplication;
using WebApplication.Domain;
using Xunit;

namespace WebApplicationTests
{
    public class TimeStampTests
    {
        [Fact]
        public void OutputMessageIsInCorrectFormat()
        {
            var timeStamp = new DateTime(2020,07,29,15,46,37);
            var formattedDateTime = TimeStamp.FormatDate(timeStamp);
            
            Assert.Equal("3:46 PM on 29 July 2020", formattedDateTime);
        }
    }
}


