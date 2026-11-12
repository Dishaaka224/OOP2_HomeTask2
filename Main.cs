using System;
using System.Linq.Expressions;
namespace HomeTask9;
class Program
{
    static void Main()
    {
        Thermostat livingRoom = new Thermostat("Living room:", 20, 23);
        Thermostat bedroom = new Thermostat("Bedroom", 24, 21);
        Thermostat office = new Thermostat("Office", 19, 19);

        // living room 2 marta yozamiz bedroom 1 marta
        livingRoom.AdjustOneDegree();
        livingRoom.AdjustOneDegree();
        bedroom.AdjustOneDegree();

        // yuq qiymatni tekshiruvchi kod
        bool result = livingRoom.SetTarget(31);
        Console.WriteLine($"Living room set target(31): {result}");
        Console.WriteLine();

        Thermostat[] all = { livingRoom, bedroom, office };
        foreach (Thermostat t in all)
        {
            Console.WriteLine($"{t.RoomName}: temperature {t.CurrentTemperature}, " + $"goal {t.TargetTemperature}, state {t.GetStatus()}");
        }

        // task 2
        Playlist mix = new Playlist("Study mix", 3);

        Song s1 = new Song("S01", "Focus", 210);
        Song s2 = new Song("S02", "Break", 185);
        Song s3 = new Song("S03", "Rewiev", 240);

        // uchtasini qushish uchun
        Console.WriteLine($"S01 qo'shish: {mix.AddSong(s1)}");
        Console.WriteLine($"S02 qo'shish: {mix.AddSong(s2)}");
        Console.WriteLine($"S03 qo'shish: {mix.AddSong(s3)}");

        Console.WriteLine($"Takroriy S02: {mix.AddSong(new Song("S02", "Break", 185))}");
// playsong(1) ikki marta true true beradi
        Console.WriteLine($"PlaySong(1): {mix.PlaySong(1)}");
        Console.WriteLine($"PlaySong(1): {mix.PlaySong(1)}");
//playsong(-1) playsong(3) false false beradi
        Console.WriteLine($"PlaySong(-1): {mix.PlaySong(-1)}");
        Console.WriteLine($"PlaySong(3): {mix.PlaySong(3)}");

        Console.WriteLine();
        mix.PrintSongs();
        Console.WriteLine($"Total duration: {mix.GetTotalDuration()} seconds");
// ikkinchi palylist 
        Playlist empty = new Playlist("Empty", 5);
        Console.WriteLine();
        empty.PrintSongs();
        Console.WriteLine($"Second Playlist total duration: {empty.GetTotalDuration()} seconds");
    }
}


