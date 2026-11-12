using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace HomeTask9;
// task 1 Thermostat 
    class Thermostat
    {
        private const int MinTarget = 16;
        private const int MaxTarget = 30;

        private string roomName;
        private int currentTemperature;
        private int targetTemperature;
// konstruktor
        public Thermostat(string roomName, int currentTemperature, int targetTemperature)
        {
            this.roomName = roomName;
            this.currentTemperature = currentTemperature;
            this.targetTemperature = targetTemperature;
        }
// propertyla (only you can read from uotside)
        public string RoomName
        {
            get { return roomName; }
        }

        public int CurrentTemperature
        {
            get { return currentTemperature; }
        }

        public int TargetTemperature
        {
            get { return targetTemperature; }
        }
// haroratni uzgartirish uchun kod 
        public bool SetTarget(int temperature)
        {
            if (temperature >= MinTarget && temperature <= MaxTarget)
            {
                targetTemperature = temperature;
                return true;
            }

            return false;
        }
// hozirgi haroratni 1 ga kupaytirish uchun 
        public void AdjustOneDegree()
        {
            if (currentTemperature < targetTemperature)
                currentTemperature++;
            else if (currentTemperature > targetTemperature)
                currentTemperature--;
        }

        public void AddjustOneDegree()
        {
            AdjustOneDegree();
            if (currentTemperature < targetTemperature)
                currentTemperature++;
            else if (currentTemperature > targetTemperature)
                currentTemperature--;
        }
//holatni qaytarish uchun
        public string GetStatus()
        {
            if (currentTemperature < targetTemperature)
                return "Heating just relax!";
            if (currentTemperature > targetTemperature)
                return "Cooling just relax";
            return "At target";
        }
}

// task 2 Song & Playlist 

    class Song
    {
        private string code;
        private string title;
        private int durationSeconds;
        private int playCount;

        public Song(string code, string title, int durationSeconds)
        {
            this.code = code;
            this.title = title;
            this.durationSeconds = durationSeconds;
            this.playCount = 0;
        }
    // tashqaridan uqish mumkun bugani 
        public string Code
        {
            get { return code;}
        }
        public string Title
        {
            get {return title;}
        }
        public int DurationSeconds
        {   
            get { return durationSeconds;}
        }
        public int PlayCount
        {
            get { return playCount;}
        }
        public void Play()
        {
            playCount++;
        }
        public string GetInfo()
        {
            return $"{code} - {title}, {durationSeconds} seconds, {playCount} times was performet";
        }
    }

    class Playlist
    {
        private Song[] songs;
        private int count;
        private string name;

        public Playlist(string name, int capacity)
        {
            this.name = name;
            songs = new Song[capacity];
            count = 0;
        }
        public string Name
        {
            get {return name;}
        }
        public bool AddSong(Song song)
        {
                if (count >= songs.Length)
                    return false;                 

                for (int i = 0; i < count; i++)
                {
                    if (songs[i].Code == song.Code)
                        return false;            
                }

                songs[count] = song;
                count++;
                return true;
        }
    public bool PlaySong(int index)
        {
            if (index < 0 || index >= count)
                return false;

            songs[index].Play();
            return true;
        }
    public int GetTotalDuration()
        {
            int total = 0;
            for (int i = 0; i < count; i++)
                total += songs[i].DurationSeconds;
            return total;
        }

        public void PrintSongs()
        {
            Console.WriteLine($"Playlist: {name}");
            for (int i = 0; i < count; i++)
                Console.WriteLine(songs[i].GetInfo());
        }
        
    }