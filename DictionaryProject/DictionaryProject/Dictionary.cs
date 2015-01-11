using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace DictionaryProject
{
    class Dictionary
    {
        Dictionary<string, string> Translations {set; get;} // Main translations database. Filled from file during initialisation
        Regex engWordRegex = new Regex(@"^[a-zA-Z]+$");     // for english words
        Regex rusWordRegex = new Regex(@"^[а-яА-Я]+$");     // for russian words
        Regex regx = new Regex(@"[^\s\?\.\!\,]+");          // for split centence to words
        Regex endOfSentenceRg = new Regex(@"[^\w]$");       // save last centence character for translated centence.
        string FileName {set; get;}                         // customiseable FileName

        /// <summary>
        /// You can create custom File during Initialization
        /// </summary>
        /// <param name="fileName"></param>
        public Dictionary(string fileName = "rus.txt")
        {
            FileName = fileName;
            Translations = new Dictionary<string, string>();
            FillTranslations();
        }

        /// <summary>
        /// Get KeyPair Dictionary with all Words
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> getWholeDictionary() {
            return Translations;
        }
        
        /// <summary>
        /// Init Menu
        /// </summary>
        public void InitDictionaryMenu()
        {
            Console.WriteLine("\tHello, i`m a English-to-Russian translator.");
            int res = 10;
            do
            {
                Console.WriteLine("\nWhat do you want me to do?\n\n 1) Add word to translator. \n 2) Tranlsate English sentence into Russian.\n 3) Show all Words\n 0) Exit.");
                string choseText = Console.ReadLine();
                int buff;
                if (choseText.Length > 0 && Int32.TryParse(choseText, out buff))
                {
                    res = Convert.ToInt32(choseText);

                    switch (res)
                    {
                        case 1:
                            Console.WriteLine("\nPlease, enter your word.");
                            string initWord = Console.ReadLine();
                            Console.WriteLine("\nPlease, enter translate.");
                            string initTranslate = Console.ReadLine();
                            if (isWordsCorrect(initWord, initTranslate) == false)
                            {
                                Console.WriteLine("\nError. Please, sure you entered correct English and Russian word and try again.");
                            }
                            else
                            {
                                AddToTranslations(initWord, initTranslate);
                            }
                            
                            break;
                        case 2:
                            Console.WriteLine("\nPlease, enter your sentence.");
                            string initText = Console.ReadLine();

                            string result = TranslateCentence(initText);
                            Console.WriteLine("Translation result: " + result);
                            break;
                        case 3:
                            Console.WriteLine("\n----= All words =----: ");
                            Dictionary<string, string> allItems = getWholeDictionary();
                            foreach (var pair in allItems)
                            {
                                Console.WriteLine(pair.Key + " : " + pair.Value);
                            }
                            break;
                        default:
                            break;
                    }
                }
            } while (res != 0);
        }

        /// <summary>
        /// Translate each word in sentense, returns sentence with translated words
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        private string TranslateCentence(string sentence)
        {
            MatchCollection words = regx.Matches(sentence);

            Console.WriteLine("Translate...");
            System.Threading.Thread.Sleep(1000);

            if (words.Count < 1)
            {
                Console.WriteLine("Sorry, there was nothing to translate.");
            }
            string result = "";
            for (int i = 0; i < words.Count; i++)
            {
                result += TranslateFromEngToRus(words[i].ToString()) + " ";
            }
            if (endOfSentenceRg.IsMatch(sentence))
            {
                result += endOfSentenceRg.Match(sentence);
            }
            return result;
        }

        /// <summary>
        /// Add English word and Rus translation. 
        /// If word present, user can update translation.
        /// Function updates current Dictionary and File.
        /// There are checkers of word presence and EN/RU language symbols in words.
        /// </summary>
        /// <param name="engWord"></param>
        /// <param name="ruWord"></param>
        private void AddToTranslations(string engWord, string ruWord)
        {
            
            if (Translations.ContainsKey(engWord.ToLower()) == true)
            {
                int chose = 0;
                do
                {
                    Console.WriteLine("This word already has translation - \"{0}\". Do you want to change it?\n1)Change\n2)Leave old translation", Translations[engWord.ToLower()]);
                    string choseText = Console.ReadLine();
                    chose = Convert.ToInt32(choseText);

                    switch (chose)
                    {
                        case 1:
                            Console.WriteLine("Please, enter russian word.");
                            string changetranslation = Console.ReadLine();
                            if (rusWordRegex.IsMatch(changetranslation) == false)
                            {
                                Console.WriteLine("Russian word is not correct. please, enter correct word.");
                            }
                            else
                            {
                                Translations[engWord.ToLower()] = changetranslation;
                                ChangeTranslationInFile(Translations[engWord.ToLower()], changetranslation);
                                Console.WriteLine("\nWord {0} sucessfully updated.", engWord);
                                chose = 2;
                            }
                            break;
                        case 2:

                            break;
                        default:
                            break;
                    }
                } while (chose != 2);
            }
            else
            {
                try
                {
                    using (FileStream fs = new FileStream(this.FileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                    {
                        try
                        {
                            BinaryWriter bw = new BinaryWriter(fs, Encoding.UTF8);
                            bw.Write(engWord);
                            bw.Write(ruWord);
                        }
                        catch (IOException)
                        {
                            Console.WriteLine("Write error");
                        }

                    }
                    Translations.Add(engWord, ruWord);
                    Console.WriteLine("\nWord {0} sucessfully added.", engWord);
                }
                catch (IOException)
                {
                    Console.WriteLine("Read error");
                }
            }
        }

        /// <summary>
        /// Change translation for one word.
        /// Function updates current dictionary and File
        /// </summary>
        /// <param name="engWordToChange"></param>
        /// <param name="newTranslation"></param>
        private void ChangeTranslationInFile(string engWordToChange, string newTranslation)
        {
            using (FileStream fs = new FileStream(this.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                BinaryReader br = new BinaryReader(fs, Encoding.UTF8);
                try
                {
                    for (; ; )
                    {
                        string engWord = br.ReadString();
                        
                        if(engWord == engWordToChange) {
                            BinaryWriter bw = new BinaryWriter(fs, Encoding.UTF8);
                            bw.Write(newTranslation);
                        }
                        
                    }
                }
                catch (EndOfStreamException)
                {
                    //Console.WriteLine("Finish File read");
                }
            }
        }

        /// <summary>
        /// return russian translation for english word
        /// </summary>
        /// <param name="engWord"></param>
        /// <returns></returns>
        private string TranslateFromEngToRus(string engWord)
        {
            string rusWord = "";

            if (Translations.ContainsKey(engWord.ToLower()) == true)
            {
                rusWord = Translations[engWord.ToLower()];
            }
            else if (engWordRegex.IsMatch(engWord) == false)
            {
                Console.WriteLine("This word is incorrect. Whis word will be not translated.");
                rusWord = engWord;
            } else {
                Console.WriteLine("We dont have translation for Word \"" + engWord + "\".");
                do
                {
                    Console.WriteLine("Please enter russian traslate for this word.");
                    rusWord = Console.ReadLine();
                } while (rusWord.Length == 0 && rusWordRegex.IsMatch(rusWord) == false);
                AddToTranslations(engWord.ToLower(), rusWord);
            }

            return rusWord;
        }

        /// <summary>
        /// Init main Dictionary
        /// Load to memory whole file with translations.
        /// </summary>
        private void FillTranslations()
        {
            using (FileStream fs = new FileStream(this.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                BinaryReader br = new BinaryReader(fs, Encoding.UTF8);
                try
                {
                    for (; ; )
                    {
                        string engWord = br.ReadString();
                        string ruWord = br.ReadString();

                        this.Translations.Add(engWord.ToLower(), ruWord);
                    }
                }
                catch (EndOfStreamException)
                {
                    //Console.WriteLine("Finish File read");
                }
            }
        }

        /// <summary>
        /// Check rusiian and English words for Correct Symbols
        /// </summary>
        /// <param name="engWord"></param>
        /// <param name="ruWord"></param>
        /// <returns></returns>
        private bool isWordsCorrect(string engWord, string ruWord)
        {
                if (rusWordRegex.IsMatch(ruWord) == false || engWordRegex.IsMatch(engWord) == false)
                {
                    return false;
                }
                else
                {
                    return true;
                }
                //Console.WriteLine("Russian word is not correct. please, enter correct word.");
        }
    }
}
