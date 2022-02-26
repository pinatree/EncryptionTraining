using dreamscape.EncryptionTraining.EncryptionLibrary.ViginereEncryption.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.Tests.ViginereEncryption.Helpers
{
    public class VigenereStringConverterTests
    {
        [Test]
        public void UppercaseConversionWorksCorrectly()
        {
            //All characters in lowercase
            string toConvert = "abcdefg";
            string expect = "ABCDEFG";
            Assert.AreEqual(expect, VigenereStringConverter.SetToUpperCase(toConvert));

            //Characters in both lower and upper case
            toConvert = "bcdABdfgC";
            expect = "BCDABDFGC";
            Assert.AreEqual(expect, VigenereStringConverter.SetToUpperCase(toConvert));

            //The crazy line does not throw exceptions and works out
            toConvert = " 6jf94$1! @#fddxАБ Вва";
            expect = " 6JF94$1! @#FDDXАБ ВВА";
            Assert.AreEqual(expect, VigenereStringConverter.SetToUpperCase(toConvert));
        }
    }
}
