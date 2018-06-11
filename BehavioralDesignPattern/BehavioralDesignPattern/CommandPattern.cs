using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralDesignPattern
{
    class CommandPattern
    {
        public static void Run()
        {
            TvRemote tv = new TvRemote();
            ChannelChange channel = new ChannelChange(tv);
            Volume volumeControl = new Volume(tv);
            Invoker invok = new Invoker();
            invok.StoreCommand(volumeControl);
            invok.StoreCommand(channel);
            invok.UpAllStoredCommand();
        }
    }


    public class Invoker
    {
        public List<ButtonCommand> x = new List<ButtonCommand>();

        public void StoreCommand(ButtonCommand y)
        {
            x.Add(y);
        }

        public void UpAllStoredCommand()
        {
            foreach (var item in x)
            {
                item.Up();
            }
        }
    }

    public class TvRemote
    {
        int CurrentVolume = 0;
        int CurrentChannel = 0;

        public void IncreaseChannel()
        {

            CurrentChannel++;
            Console.WriteLine(CurrentChannel);
        }

        public void DecreaseChannel()
        {
            CurrentChannel--;
            Console.WriteLine(CurrentChannel);
        }

        public void IncreaseVolume()
        {
            CurrentVolume++;
            Console.WriteLine(CurrentVolume);
        }

        public void DecreaseVolume()
        {
            CurrentVolume--;
            Console.WriteLine(CurrentVolume);
        }


    }

    public abstract class ButtonCommand
    {
        public abstract void Up();

        public abstract void Down();
    }

    public class Volume : ButtonCommand
    {
        public TvRemote _tvRemote;

        public Volume(TvRemote tv)
        {
            _tvRemote = tv;
        }


        public override void Up()
        {
            _tvRemote.IncreaseChannel();
        }

        public override void Down()
        {
            _tvRemote.DecreaseChannel();
        }
    }

    public class ChannelChange : ButtonCommand
    {
        public TvRemote _tvRemote;

        public ChannelChange(TvRemote tv)
        {
            _tvRemote = tv;
        }

        public override void Up()
        {
            _tvRemote.IncreaseVolume();
        }

        public override void Down()
        {
            _tvRemote.DecreaseVolume();
        }
    }

}
