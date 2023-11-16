using AlexandrKondratevKt4120.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace alexandr_kondratev_kt_41_20.Tests
{
    public class PrepodTest
    {
        [Fact]
        public void IsValidPrepodName_KT4120_True()
        {
            var testGroup = new Prepod
            {
                PrepodId = 1,
                PrepodName = "Филиппов Филипп Филиппович"
            };

            var result = testGroup.IsValidPrepodName();

            Assert.True(result);

        }
    }
}
