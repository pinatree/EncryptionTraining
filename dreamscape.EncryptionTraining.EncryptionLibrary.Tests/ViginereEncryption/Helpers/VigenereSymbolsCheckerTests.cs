using dreamscape.EncryptionTraining.EncryptionLibrary.ViginereEncryption.Helpers;
using NUnit.Framework;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.Tests.ViginereEncryption.Helpers
{
    public class VigenereSymbolsCheckerTests
    {
        [Test]
        public void CheckStrIsValidWorksCorrectly()
        {
            //----------EN language----------
            VigenereSymbolsChecker checker = new VigenereSymbolsChecker('A', 'Z');

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
            checker = new VigenereSymbolsChecker('А', 'Я');

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
    }
}
