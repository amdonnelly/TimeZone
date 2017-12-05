using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Timezone.Core.Tests
{
	[TestClass]
	public class ReaderTests
	{
		[TestMethod]
		public void Reader_ValidContent()
		{
			StringBuilder fileContents = new StringBuilder();
			fileContents.AppendLine("09:30 Amsterdam");
			fileContents.AppendLine("17:29 Minsk");

			string expectedOutputLine1 = null;
			string expectedOutputLine2 = null;


			List<Tuple<string, string>> lTimes;
			using (Reader fileReader = new Reader())
			{
				lTimes = fileReader.Read(fileContents.ToString());
			}


			Assert.AreEqual(2, lTimes.Count);
			Assert.AreEqual("09:30", lTimes[0].Item1);
			Assert.AreEqual("Amsterdam", lTimes[0].Item2);
			Assert.AreEqual("17:29", lTimes[1].Item1);
			Assert.AreEqual("Minsk", lTimes[1].Item2);
		}
	}
}
