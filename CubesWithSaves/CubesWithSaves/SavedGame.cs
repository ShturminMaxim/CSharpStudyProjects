using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CubesWithSaves
{
    [Serializable]
    class SavedGame
    {
        public int dropCount = 0;
        public int userScore = 0;
        public int computerScore = 0;
        public string savedCubes = "";

        public bool CanBeLoaded() {
            try
            {
                FileStream fs = new FileStream("save.dat", FileMode.Open, FileAccess.Read);
                fs.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool LoadGame()
        {
            FileStream fs = new FileStream("save.dat", FileMode.OpenOrCreate, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();

            try 
	        {	        
                SavedGame previousSavedGame = (SavedGame)bf.Deserialize(fs);
                this.dropCount = previousSavedGame.dropCount;
                this.userScore = previousSavedGame.userScore;
                this.computerScore = previousSavedGame.computerScore;
                this.savedCubes = previousSavedGame.savedCubes;
                fs.Close();
                return true;
	        }
	        catch (Exception ex)
	        {
		        Console.WriteLine(ex.Message);
                fs.Close();
                return false;
	        }
        }
        public void SaveGame(int savedropCount, int userScore, int computerScore, string savedCubes)
        {
            FileStream fs = new FileStream("save.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();

            this.dropCount = savedropCount;
            this.userScore = userScore;
            this.computerScore = computerScore;
            this.savedCubes = savedCubes;

            bf.Serialize(fs, this);

            fs.Close();
        }
    }
}
