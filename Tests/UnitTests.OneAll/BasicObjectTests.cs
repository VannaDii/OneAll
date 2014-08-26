using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OneAll;
using OneAll.Users;

namespace UnitTests.OneAll
{
    [TestClass]
    public class BasicObjectTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var jsonData = System.IO.File.ReadAllText(@"..\..\Json\ReadUserDetails.json");
            Response<UserResult> userDetailResponse = null;
            userDetailResponse = userDetailResponse.FromJson(jsonData);

            Assert.IsNotNull(userDetailResponse.Request);
            Assert.IsNotNull(userDetailResponse.Request.Status);

            Assert.IsNotNull(userDetailResponse.Result);
            Assert.IsNotNull(userDetailResponse.Result.Data);
            Assert.IsNotNull(userDetailResponse.Result.Data.User);
            Assert.IsNotNull(userDetailResponse.Result.Data.User.Identities);
        }
    }
}
