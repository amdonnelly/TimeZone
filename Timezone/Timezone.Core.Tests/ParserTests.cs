using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Timezone.Core.Tests
{
	[TestClass]
	public class ParserTests
	{
		[TestMethod]
		public void DisplayTime_ValidParameters()
		{
			Parser timeZoneParser = new Parser();
			string expectedOutput = "The time in the UK is 9:30 and the time in Amsterdam is 10:30";


			string output = timeZoneParser.DisplayTime("09:30", "Amsterdam");


			Assert.AreEqual(expectedOutput, output);
		}

		[TestMethod]
		public void DisplayTime_InvalidTime()
		{
			Parser timeZoneParser = new Parser();
			string expectedOutput = null;


			string output = timeZoneParser.DisplayTime("xx:30", "Amsterdam");


			Assert.AreEqual(expectedOutput, output);
		}

		[TestMethod]
		public void DisplayTime_InvalidLocation()
		{
			Parser timeZoneParser = new Parser();
			string expectedOutput = null;



			string output = timeZoneParser.DisplayTime("09:30", "Glasgow");


			Assert.AreEqual(expectedOutput, output);
		}
	}
}
