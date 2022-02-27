using dreamscape.EncryptionTraining.EncryptionLibrary.TranspositionEncryption.Helpers;
using NUnit.Framework;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.Tests.TranspositionEncryption.Helpers
{
    public class SpacePlaceholderTests
    {
        [Test]
        public void GetSpaceFilledTest_WorksCorrectly()
        {
            string original = "1234";
            string key = "qwe";
            string excpect = "1234  ";
            string returned = SpacePlaceholder.GetSpaceFilled(original, key.Length);
            Assert.AreEqual(excpect, returned);

            original = "1";
            key = "q";
            excpect = "1";
            returned = SpacePlaceholder.GetSpaceFilled(original, key.Length);
            Assert.AreEqual(excpect, returned);

            original = "12";
            key = "qwerty";
            excpect = "12    ";
            returned = SpacePlaceholder.GetSpaceFilled(original, key.Length);
            Assert.AreEqual(excpect, returned);

            original = "12345678";
            key = "qwert";
            excpect = "12345678  ";
            returned = SpacePlaceholder.GetSpaceFilled(original, key.Length);
            Assert.AreEqual(excpect, returned);
        }
    }
}
