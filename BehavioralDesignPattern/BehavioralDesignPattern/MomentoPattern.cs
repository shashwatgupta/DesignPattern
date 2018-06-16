using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralDesignPattern
{
    class MomentoPattern
    {
        public static void Run()
        {
            SongList sl = new SongList();
            sl.IncreasePlayingIndex();
            sl.IncreasePlayingIndex();
            sl.IncreasePlayingLocation();
            CareTaker c = new CareTaker(sl);
            Momento m = c.CreateMomento();
            sl.IncreasePlayingIndex();
            c.SetMomento(m);
            Console.WriteLine(sl.ReadPlayingIndex());
        }
    }

    public class CareTaker
    {
        public CareTaker(SongList song)
        {
            this.song = song;
        }
        public Momento CreateMomento()
        {
            return this.song.GetMomento();
        }
        public void SetMomento( Momento m)
        {
            this.song.SetMomento(m);
        }


        private SongList song;
    }

    public class Momento
    {
        public int SongIndex;

        public int SongLocation;

        public void SetState(int songIndex, int songLocation)
        {
            this.SongIndex = songIndex;
            this.SongLocation = songLocation;
        }
    }

    public class SongList
    {
        public Momento GetMomento()
        {
            Momento m = new Momento();
            m.SetState(CurrentPlayingIndex, CurrentPlayingSongLocation);
            return m;
        }

        public void SetMomento(Momento m)
        {
            this.CurrentPlayingIndex = m.SongIndex;
            this.CurrentPlayingSongLocation = m.SongLocation;
        }

        public void IncreasePlayingIndex()
        {
            CurrentPlayingIndex++;
        }

        public int ReadPlayingIndex()
        {
           return  CurrentPlayingIndex;
        }

        public void IncreasePlayingLocation()
        {
            CurrentPlayingSongLocation++;
        }


        private int CurrentPlayingIndex;

        private int CurrentPlayingSongLocation ;
    }
}
