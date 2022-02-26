using dreamscape.EncryptionTraining.EncryptionLibrary.ViginereEncryption.Helpers;
using NUnit.Framework;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.Tests.ViginereEncryption.Helpers
{
    public class VigenereSymbolsHelperTests
    {
        [Test]
        public void CheckStrIsValidWorksCorrectly()
        {
            //----------EN language----------
            VigenereSymbolsHelper checker = new VigenereSymbolsHelper('A', 'Z');

            //Value string returns 'true'
            string toCheck = "AZFKDSFJDOSAFHNABDFASUHFDSHFDOSHFDS";
            Assert.IsTrue(checker.CheckStrIsValid(toCheck));

            //Lower-case string returns false
            toCheck = "hjdgfhjdgfhjfdgghjdfogdhfpgdfhgdfodasfads";
            Assert.IsFalse(checker.CheckStrIsValid(toCheck));

            //String with characters in both lower and upper case returns false
            toCheck = "hasdhasHOAISDHAShaoaisdhaaADHSASDOASDpasdjasPDHAPSIDhASPDIASd";
            Assert.IsFalse(checker.CheckStrIsValid(toCheck));

            //String with spaces returns false
            toCheck = "AZFKDSFJDOSAFHNA BDFASUHFDSHFDOSHFDS";
            Assert.IsFalse(checker.CheckStrIsValid(toCheck));

            //The crazy string returns false
            toCheck = " 6jf94$1! @#fddxАБ Вва";
            Assert.IsFalse(checker.CheckStrIsValid(toCheck));


            //----------RU language----------
            checker = new VigenereSymbolsHelper('А', 'Я');

            //Value string returns 'true'
            toCheck = "РАВЫАРВКРКЕВРВПАРКУПКУЫПРУЕПКУ";
            Assert.IsTrue(checker.CheckStrIsValid(toCheck));

            //Lower-case string returns false
            toCheck = "выафвапваыпварйфпавыапыва";
            Assert.IsFalse(checker.CheckStrIsValid(toCheck));

            //String with characters in both lower and upper case returns false
            toCheck = "ВФЫАОВЫПпщырваыпрРХрхшрфыВРфхыВРФВФЫРВХфырВрфыХФырвщшрфыВХФшыр";
            Assert.IsFalse(checker.CheckStrIsValid(toCheck));

            //String with spaces returns false
            toCheck = "РАВЫАРВКР КЕВРВПАРК УПКУЫПРУЕПКУ";
            Assert.IsFalse(checker.CheckStrIsValid(toCheck));

            //The crazy string returns false
            toCheck = " 6jf94$1! @#fddxАБ Вва";
            Assert.IsFalse(checker.CheckStrIsValid(toCheck));
        }

        [Test]
        public void GetSymbolWithOffsetWorksCorrectly()
        {
            VigenereSymbolsHelper checker = new VigenereSymbolsHelper('A', 'Z');

            //A + 1 = B
            Assert.AreEqual('B', checker.GetSymbolWithOffset('A', 1));

            //A + 2 = C
            Assert.AreEqual('C', checker.GetSymbolWithOffset('A', 2));

            //Z + 1 = A
            Assert.AreEqual('A', checker.GetSymbolWithOffset('Z', 1));

            //W + 5 = B
            Assert.AreEqual('B', checker.GetSymbolWithOffset('W', 5));

            //A + 26 = A
            Assert.AreEqual('A', checker.GetSymbolWithOffset('A', 26));

            //Z + 26 = Z
            Assert.AreEqual('Z', checker.GetSymbolWithOffset('Z', 26));

            //Z + 27 = A
            Assert.AreEqual('A', checker.GetSymbolWithOffset('Z', 27));

            //X + 52 = X
            Assert.AreEqual('X', checker.GetSymbolWithOffset('X', 52));

            //X + 53 = Y
            Assert.AreEqual('Y', checker.GetSymbolWithOffset('X', 53));

            //C + 262 = E
            Assert.AreEqual('E', checker.GetSymbolWithOffset('C', 262));
        }
    }
}
