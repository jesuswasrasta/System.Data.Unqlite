﻿#region Usings
using System.IO;
using System.Text;
using System.Threading;

using NUnit.Framework;
#endregion


namespace System.Data.Unqlite.Tests.Unit
{
	[TestFixture, Category("Unit"), Description("UnqliteDb tests")]
	public class UnqliteDbTests
	{
		#region Costants
		private const string InMemoryDatabase = ":mem:";
		#endregion


		# region Setup and Tear Down
		/// <summary>
		/// SetsUp is called once before each Test within the same TestFxiture
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			// Set up code here.
			// If this throws an exception no Test in the TestFixture are run.
		}

		/// <summary>
		/// TearsDown is called once after each Test within the same TestFixture.
		/// </summary>
		[TearDown]
		public void TearDown()
		{
			// Clear up code here.
			// Will not run if no tess are run due to [SetUp] throwing an exception
		}
		# endregion


		#region Key Value Store
		[Test, MaxTimeAttribute(2000)]
		public void UnqliteDb_KeyValue_Store()
		{
			var itemsCount = 1000;
			var databaseFile = Path.GetTempFileName();

			using (var unqliteDb = new UnqliteDb())
			{
				unqliteDb.Open(databaseFile, UnqliteOpenMode.CREATE);

				for (int i = 0; i < itemsCount; i++)
				{
					unqliteDb.SaveKeyValue(i.ToString(), i.ToString());
				}
			}
		}
		#endregion
	}
}
